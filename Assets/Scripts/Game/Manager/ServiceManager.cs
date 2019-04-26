using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Game.Service {
    public interface IServiceManager : IInitService, IExcuteService {

    }
    /*
        ManagerParent 
        属性：
            dictionary: 
                key:priority, v: hashSet[] IInitService;
            hashSet:
                v: IExecuteService
        构造函数：
            初始化两个属性；
            排序 initDictionary;     
     */
    public class ServiceManager : IServiceManager {
        Dictionary<int, HashSet<IInitService>> _initServices = new Dictionary<int, HashSet<IInitService>>();
        HashSet<IExcuteService> _excuteServices = new HashSet<IExcuteService>();

        public ServiceManager(GameParentManager parentManager) {

            var services = InitServices(parentManager);
            AddInitServices(services);
            AddExcuteServices(services);

            //foreach 字典，每一个键值对打印顺序和加入顺序一致，所以需要排序

            var list = from service in _initServices orderby service.Key select service;
            _initServices = list.ToDictionary(pair => pair.Key, pair=> pair.Value);
            
        }

        IInitService[] InitServices(GameParentManager parentManager) {
            IInitService[] services = {
                new FindObjectService()
            };
            return services;
        }

 
        void AddInitServices(IInitService[] services) {
            IInitService service;
            int priority;
            for (int i = 0; i < services.Length; i++) {
                service = services[i];
                priority = service.GetPriority();
                if (priority < 0)
                    continue;
                if (!_initServices.ContainsKey(priority)) {
                    _initServices.Add(priority, new HashSet<IInitService>());
                }
                _initServices[priority].Add(service);
            }
        }

        void AddExcuteServices(IInitService[] services) {
            IExcuteService service;
            for (int i = 0; i < services.Length; i++) {
                service = services[i] as IExcuteService;
                if(service == null) continue;
                _excuteServices.Add(service);
            }
        }

        public void Execute() {
            foreach (IExcuteService service in _excuteServices)
            {
                service.Execute();
            }
        }

        public int GetPriority() {
          return 0;
        }

        public void Init(Contexts contexts) {
           foreach (var  unit in _initServices)
           {
               foreach (var initService in unit.Value)
               {
                   initService.Init(contexts);
               }
           }
        }

    }
}