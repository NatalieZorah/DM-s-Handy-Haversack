using HaversackLibrary.Models;
using HaversackLibrary.Models.CharacterModels;
using HaversackLogic.Builders;
using static HaversackLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaversackLibrary.Models.StatusModels;

namespace HaversackLibrary.Utils
{
    // TODO - Refactor to use CharacterModel once completed
    public class CharacterTrainer
    {
        public int SessionCount { get; set; }

        public int DifficultyCheck { get; set; }

        public Dictionary<string, int> TrainingProgressionRolls { get; set; }

        public CharacterTrainer(int sessionCount, List<AttributeModel> attributes)
        {
            SessionCount = sessionCount;
            DifficultyCheck = CalculateDifficulty(attributes);
            TrainingProgressionRolls = GetProgressionRolls(attributes);
        }

        private int CalculateDifficulty(List<AttributeModel> attributes)
        {
            int difficulty = attributes[0].Value + attributes[0].Modifier;

            if (attributes.Count > 1)
            {
                difficulty -= attributes[1].Modifier;
            }

            return difficulty;
        }

        private Dictionary<string, int> GetProgressionRolls(List<AttributeModel> attributes)
        {
            Dictionary<string, int> rolls = new Dictionary<string, int>();
            DiceRollerFactory roller = new DiceRollerFactory();

            int sessions = 0;
            int rollBonus = 0;
            int dieCount = 6 - attributes[0].Modifier;
            DiceModel progressionDice = new DiceModel(DiceType.D8, dieCount);

            if (attributes.Count > 1)
            {
                int modifier = attributes[1].Modifier;
                rollBonus = (modifier + 1) / 2;
                rollBonus = Math.Max(rollBonus, 1) * dieCount;
            }

            while (sessions <= SessionCount)
            {
                int rolledValue = roller.Roll(progressionDice);
                int totalProgress = rolledValue + rollBonus;

                string sessionKey = $"Session {++sessions}: {rolledValue} + {rollBonus} = {totalProgress}";
                rolls.Add(sessionKey, totalProgress);
            }

            return rolls;
        }
    }
}
