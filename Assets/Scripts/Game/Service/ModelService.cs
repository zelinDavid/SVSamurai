using System.Collections.Generic;
using Manager;
using Model;
using Module;


namespace Game.Service
{
    public interface IModelService: IInitService {
        
    }

    public interface IConfigModelService : IModelService {
        
    }

    /// <summary>
    /// 配置数据服务
    /// </summary>
    public class ConfigModelService : IConfigModelService
    {
        public ConfigModelService()
        {

        }

        public int GetPriority()
        {
            return 0; 
        }

        public void Init(Contexts contexts)
        {
            InitHumanSkillCoding(contexts);
        }

        private void InitHumanSkillCoding(Contexts contexts){
            var skillList = GEtValidList();
            var maxLength = GetMaxLength(skillList);
            contexts.game.SetGameHumanSkillConfig(skillList,maxLength);

        }
        
        private int GetMaxLength(List<ValidHumanSkill> skills){
            int maxLength = 0;
            foreach (ValidHumanSkill skill in skills)
            {
                if (skill.Code.ToString().Length > maxLength)
                {
                    maxLength = skill.Code.ToString().Length;
                }
            }
            return maxLength;
        }

        private List<ValidHumanSkill> GEtValidList(){
            SkillCodeModule skillCodeModule  = new SkillCodeModule();
            var skills = ModelManager.Single.HumanSkillModel.skills;
            List<ValidHumanSkill> skillList = new List<ValidHumanSkill>();

            int temCode = 0;
            foreach (SkillModel skillModel in skills)
            {
                if (skillModel.Level <= (int)DataManager.Single.LevelIndex)
                {
                    temCode = skillCodeModule.GetSkillCode(skillModel.Code, "", "");
                    skillList.Add(new ValidHumanSkill(temCode));
                }
            }
           return skillList;
        }


    }
}