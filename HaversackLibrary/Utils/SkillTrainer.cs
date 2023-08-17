using HaversackLibrary.Factories;
using HaversackLibrary.Models.CharacterModels;
using static HaversackLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using HaversackLibrary.Models;
using HaversackLogic.Builders;

namespace HaversackLibrary.Utils
{
    // TODO - refactor to use Character models once Character model is complete
    public class SkillTrainer : CharacterTrainer
    {
        public SkillModel Skill { get; set; }

        public SkillTrainer(SkillModel skill,
            int sessionCount,
            List<AttributeModel> attributes,
            ProficiencyType PartnerProficiency = ProficiencyType.Normal
            ) : base(sessionCount, attributes)
        {
            Skill = skill;
            TrainingProgressionRolls = GetProgressionRolls(attributes, PartnerProficiency);
        }

        private Dictionary<string, int> GetProgressionRolls(List<AttributeModel> attributes, ProficiencyType partnerProficiency)
        {
            Dictionary<string, int> rolls = new Dictionary<string, int>();
            DiceRollerFactory roller = new DiceRollerFactory();

            int sessions = 0;
            int dieCount = 0;
            int partnerBonusDice = 0;

            switch (partnerProficiency)
            {
                case ProficiencyType.Normal:
                    partnerBonusDice = 0;
                    break;
                case ProficiencyType.Proficient:
                    partnerBonusDice = 1;
                    break;
                case ProficiencyType.Expert:
                    partnerBonusDice = 2;
                    break;
            }

            switch (Skill.Proficiency)
            {
                case ProficiencyType.Normal:
                    dieCount = 3;
                    break;
                case ProficiencyType.Proficient:
                    dieCount = 2;
                    break;
            }

            dieCount += partnerBonusDice;

            DiceModel progressionDice = new DiceModel(DiceType.D6, dieCount);

            while (sessions <= SessionCount)
            {
                int rolledValue = roller.Roll(progressionDice);
                int totalProgress = rolledValue;

                string sessionKey = $"Session {++sessions}: {rolledValue} = {totalProgress}";
                rolls.Add(sessionKey, totalProgress);
            }

            return rolls;
        }
    }
}
