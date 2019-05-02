using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using Model;
namespace Game
{
    [Game, Unique]
    public class HumanSkillConfig: IComponent
    {
        public List<ValidHumanSkill> ValidHumanSkills;

        public int LengthMax;
     }
}
