using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Service
{
    public interface IServiceManager:IInitService,IExcuteService {
        
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
    public class ServiceManager : IServiceManager     
    {
        Dictionary<int, HashSet<IInitService>> _initServices = new Dictionary<int, HashSet<IInitService>>();
        HashSet<IExcuteService> _excuteServices = new HashSet<IExcuteService>();

        public ServiceManager()
        {
            
        }

        IInitService[] GetServices(){
            IInitService[] services = {
                    new FindObjectService()
            };
            return services;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public int GetPriority()
        {
            throw new System.NotImplementedException();
        }

        public void Init(Contexts contexts)
        {
            throw new System.NotImplementedException();
        }

         
    }
}
