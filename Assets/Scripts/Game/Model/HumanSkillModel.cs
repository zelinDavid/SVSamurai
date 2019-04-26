using System.Collections.Generic;
using UnityEngine;
using System;

namespace Model
{
    [Serializable]
    public class HumanSkillModel  
    {
        public List<SkillModel> skills;
    }

    [Serializable]
    public class SkillModel
    {
        public string Code;
        public int Level;
    }
}
