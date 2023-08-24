﻿using HaversackLibrary.Models.StatusModels;
using static HaversackLibrary.Structs;
using static HaversackLibrary.Enums;

namespace HaversackLogic.Builders
{
    public class DiceRollerFactory
    {
        /// <summary>
        /// Constructor for the DiceRoller Object to allow for multiple instances.
        /// </summary>
        public DiceRollerFactory() { }
        /// <summary>
        /// Provides the number of die faces.
        /// </summary>
        /// <param name="die">The die you are looking to get the faces of.</param>
        /// <returns>Max Integer value the die can roll.</returns>
        public int GetDiceValue(DiceType die)
        {
            switch (die)
            {
                case DiceType.D4: return 4;
                case DiceType.D6: return 6;
                case DiceType.D8: return 8;
                case DiceType.D10: return 10;
                case DiceType.D12: return 12;
                case DiceType.D20: return 20;
                case DiceType.D100: return 100;
                default: return 0;
            }
        }

        /// <summary>
        /// Provides the average value roll for a given die.
        /// </summary>
        /// <param name="die">The die you want the average value of.</param>
        /// <returns>Integer value of the average roll.</returns>
        public int GetDiceAverage(DiceType die)
        {
            return (GetDiceValue(die) / 2) + 1;
        }

        /// <summary>
        /// Returns a pseudo-random number as a rolled die.
        /// </summary>
        /// <param name="die">The die you are looking to roll.</param>
        /// <param name="min">The minimum value to return for rolls with that logic.</param>
        /// <param name="maximum">The maximum value to return for rolls with that logic.</param>
        /// <returns>Pseudo-random Integer value between the die faces and min.</returns>
        private int RollDice(DiceType die, int minimum, int maximum)
        {
            if (maximum > GetDiceValue(die))
            {
                maximum = GetDiceValue(die);
            }

            Random rnd = new Random();
            return rnd.Next(minimum, maximum);
        }

        /// <summary>
        /// Rolls a single die.
        /// </summary>
        /// <param name="die">Takes a single DieType as an input to roll.</param>
        /// <param name="minimum">The minimum value the roll should return.</param>
        /// <param name="maximum">The maximum value the roll should return.</param>
        /// <param name="itterations">The number of times to roll the dice.</param>
        /// <param name="advantage">Rolls the dice twice and returns the higher value.</param>
        /// <param name="disadvantage">Rolls the dice twice and returns the lower value.</param>
        /// <returns>Integer value of the roll after modifiers</returns>
        public DiceOutputModel Roll(DiceType die, int minimum = 1, int maximum = 100, int itterations = 1, bool advantage = false, bool disadvantage = false)
        {
            int sum = 0;
            string rollString = string.Empty;

            int rollOne = RollDice(die, minimum, maximum);
            int rollTwo = RollDice(die, minimum, maximum);

            if (advantage && !disadvantage)
            {
                sum += Math.Max(rollOne, rollTwo);
                rollString = $"2{Enum.GetName(die)}adv ({Math.Max(rollOne, rollTwo)},~~{Math.Min(rollOne, rollTwo)}~~) = `{sum}`";
            }
            if (disadvantage && !advantage)
            {
                sum += Math.Min(rollOne, rollTwo);
                rollString = $"2{Enum.GetName(die)}dis ({Math.Min(rollOne, rollTwo)},~~{Math.Max(rollOne, rollTwo)}~~) = `{sum}`";
            }

            if (!advantage && !disadvantage)
            {
                int rollValue;
                rollString = $"{itterations}{Enum.GetName(die)} (";
                for (int i = 0; i < itterations; i++)
                {
                    rollValue = RollDice(die, minimum, maximum);
                    rollString += $"{rollValue},";
                    sum += rollValue;
                }
                rollString += $") = `{sum}`";
            }
            return new DiceOutputModel(rollString, sum);
        }

        /// <summary>
        /// Rolls a single die a number of times equal to the count provided.
        /// </summary>
        /// <param name="dieModel">Takes a single DieModel as an input to roll.</param>
        /// <param name="minimum">The minimum value the roll should return.</param>
        /// <param name="maximum">The maximum value the roll should return.</param>
        /// <param name="itterations">The number of times to roll the dice.</param>
        /// <param name="advantage">Rolls the dice twice and returns the higher value.</param>
        /// <param name="disadvantage">Rolls the dice twice and returns the lower value.</param>
        /// <returns>Integer value of the roll after modifiers</returns>
        public DiceOutputModel Roll(DiceModel dieModel, int minimum = 1, int maximum = 100, int itterations = 1, bool advantage = false, bool disadvantage = false)
        {
            DiceOutputModel tempRoll;

            string rollString = string.Empty;
            int sum = 0;

            for (int i = 0; i < itterations; i++)
            {
                tempRoll = Roll(dieModel.Die, minimum, maximum, dieModel.Count, advantage, disadvantage);
                rollString += $"{tempRoll.RollString} \n";
                sum += tempRoll.RollValue;
            }

            return new DiceOutputModel(rollString, sum);
        }

        /// <summary>
        /// Rolls multiple dice pulled from the provided list.
        /// </summary>
        /// <param name="diceModels">Takes a List of DiceModel(s) as an input to roll as a group.</param>
        /// <param name="minimum">The minimum value the roll should return.</param>
        /// <param name="maximum">The maximum value the roll should return.</param>
        /// <param name="itterations">The number of times to roll the dice.</param>
        /// <param name="advantage">Rolls the dice twice and returns the higher value.</param>
        /// <param name="disadvantage">Rolls the dice twice and returns the lower value.</param>
        /// <returns>Integer value of the roll after modifiers</returns>
        public DiceOutputModel Roll(List<DiceModel> diceModels, int minimum = 1, int maximum = 100, bool advantage = false, bool disadvantage = false)
        {

            return diceModels.ForEach(die => Roll(die, minimum, maximum, die.Count, advantage, disadvantage));
        }


    }
}
