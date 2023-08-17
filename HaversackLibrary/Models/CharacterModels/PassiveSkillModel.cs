using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public class PassiveSkillModel
    {
        /// <summary>
        /// The passive skill in question.
        /// </summary>
        public Skills PassiveSkill { get; set; }
        /// <summary>
        /// The value of the passive sense.
        /// </summary>
        public int Value { get; set; }

        public PassiveSkillModel(SkillModel skill, int miscelaneousBonus = 0)
        {
            PassiveSkill = skill.Skill;
            Value = (10 + skill.Bonus + miscelaneousBonus);
        }
    }
}
