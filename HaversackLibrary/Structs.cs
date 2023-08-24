using HaversackLibrary.Models.ActionModels.DiceModels;

namespace HaversackLibrary
{
    public class Structs
    {
        public struct AttackRange
        {
            // TODO - Documentation
            public int Minimum { get; set; }
            public int Maximum { get; set; }
            public int AreaOfEffect { get; set; }

            public AttackRange(int maximum, int minimum = 0, int areaOfEffect = 0)
            {
                Minimum = minimum;
                Maximum = maximum;
                AreaOfEffect = areaOfEffect;
            }
        }

        public struct AttackOutputModel
        {
            /// <summary>
            /// The string value for the attack roll.
            /// </summary>
            public string AttackRoll { get; set; }
            /// <summary>
            /// The string value for the damage roll.
            /// </summary>
            public string DamageRoll { get; set; }
            /// <summary>
            /// Constructor for a new attack output model.
            /// </summary>
            /// <param name="attackRoll">The given string for the attack roll value.</param>
            /// <param name="damageRoll">The given string for the damage roll value.</param>
            public AttackOutputModel(string attackRoll, string damageRoll)
            {
                AttackRoll = attackRoll;
                DamageRoll = damageRoll;
            }
        }

        public struct DiceOutputModel
        {
            /// <summary>
            /// The string notation for the given dice roll.
            /// </summary>
            public string RollString { get; set; }
            /// <summary>
            /// The integer value of the dice roll.
            /// </summary>
            public int RollValue { get; set; }
            /// <summary>
            /// Constructor for a new dice output.
            /// </summary>
            /// <param name="rollString">The specific string for the dice roll.</param>
            /// <param name="rollValue">The value of the roll.</param>
            public DiceOutputModel(string rollString, int rollValue)
            {
                RollString = rollString;
                RollValue = rollValue;
            }
        }
    }
}
