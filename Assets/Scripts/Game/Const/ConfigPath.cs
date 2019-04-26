using System.Net.Mime;

using UnityEngine;

namespace Const {
    public class ConfigPath {
        public static readonly string PLAYER_CONFIG = Application.streamingAssetsPath + "/Player.json";
        public static readonly string HUMAN_SKILL_CONFIG = Application.streamingAssetsPath + "/HumanSkill.json";

        public static readonly string ENEMY_CONFIG = Application.streamingAssetsPath + "/Enemy.json";

        public static readonly string SPAWN_ENEMY_CONFIG = Application.streamingAssetsPath + "/SpawnEnemy.json";

    }
}