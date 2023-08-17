using HaversackLogic.Builders;

namespace HaversackLibrary.Models.CharacterModels
{
    public class HitPointModel
    {
        /// <summary>
        /// Represents the number of hitpoints granted by an average roll for all dice.
        /// </summary>
        /// <remarks>
        /// Calculated as half the die value plus one multipled by the number of dice in each HitDiceModel
        /// </remarks>
        public int Average { get; set; }
        /// <summary>
        /// Represents the maximum number of hit points possible, assuming max rolls on all dice.
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// Represents the bonus added to the total rolled value for each level.
        /// </summary>
        public int Bonus { get; set; }
        /// <summary>
        /// The actual number of hit points in this model, including the constitution modifier values.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// The list of total hit dice for the character.
        /// </summary>
        public List<HitDiceModel> HitDice { get; set; }

        public HitPointModel(List<HitDiceModel> hitDice, int constitutionModifier, int minimumRoll = 1, int? hitPoints = null)
        {
            HitDice = hitDice;
            Bonus = constitutionModifier;
            Average = FindAverageHp();
            Max = FindMaxPossibleHp();
            Value = hitPoints ?? RollHealth(minimumRoll);
        }

        private int FindAverageHp()
        {
            DiceRollerFactory roller = new DiceRollerFactory();
            int average = 0;

            HitDice.ForEach(hitDie =>
            {
                average += ((roller.GetDiceValue(hitDie.Die) / 2) + 1) * (hitDie.Count - 1) + (Bonus * hitDie.Count);
            });

            return average;
        }

        private int FindMaxPossibleHp()
        {
            DiceRollerFactory roller = new DiceRollerFactory();
            int max = 0;

            HitDice.ForEach(hitDie =>
            {
                max += roller.GetDiceValue(hitDie.Die) * hitDie.Count + (Bonus * hitDie.Count);
            });

            return max;
        }
        /// <summary>
        /// Rolls dice to determine health 
        /// </summary>
        /// <param name="minimum">Optional parameter for the minimum value each rolled die can be.</param>
        /// <returns></returns>
        public int RollHealth(int minimum = 1)
        {
            DiceRollerFactory roller = new DiceRollerFactory();

            int sum = 0;
            HitDice.ForEach(hitDie =>
            {
                if (hitDie.Count == 1 && hitDie.PrimaryClass)
                {
                    sum += roller.GetDiceValue(hitDie.Die) + Bonus;
                }
                if (hitDie.Count > 1 && hitDie.PrimaryClass)
                {
                    sum += (roller.Roll(hitDie.Die, minimum, 100, hitDie.Count - 1)) +
                        roller.GetDiceValue(hitDie.Die) + (Bonus * hitDie.Count);
                }
                sum += roller.Roll(hitDie, minimum, 100, hitDie.Count) + (Bonus * hitDie.Count);
            });
            return sum;
        }
    }
}
