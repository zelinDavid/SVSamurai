using UnityEngine;
using Util;
using Model;
using Const;
 
namespace Game
{
    public class ModelManager : SingletonBase<ModelManager>    
    {
         public EnemyModel EnemyModel{get;private set;} 

        public HumanSkillModel HumanSkillModel { get; private set; }

        public PlayerDataModel PlayerData { get; private set; }

        public SpawnEnemyModel SpawnEnemyModel { get; private set; }


         public void Init(){
            PlayerData = ConfigManager.Single.LoadJson<PlayerDataModel>(ConfigPath.PLAYER_CONFIG);
            HumanSkillModel = ConfigManager.Single.LoadJson<HumanSkillModel>(ConfigPath.HUMAN_SKILL_CONFIG);
            EnemyModel = ConfigManager.Single.LoadJson<EnemyModel>(ConfigPath.ENEMY_CONFIG);
            SpawnEnemyModel = ConfigManager.Single.LoadJson<SpawnEnemyModel>(ConfigPath.SPAWN_ENEMY_CONFIG);
            // Debug.Log("ModelManager:" + HumanSkillModel);
         }
    }
}
