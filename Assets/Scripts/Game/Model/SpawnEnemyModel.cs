using System.Collections.Generic;
using UnityEngine;
using System;

namespace Model
{
    [Serializable]
    public class SpawnEnemyModel   
    {
        public List<LevelModel> Levels;   
    }

    [Serializable]
    public class LevelModel
    {
        public List<PointModel> PointList;
    }

    [Serializable]
    public class PointModel
    {
        public string PointId;
        public int EnemyId;
    }
}
