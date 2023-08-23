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

        public struct SpellScaling
        {
            // TODO - Documentation
            public string Description { get; set; }
            public DamageRollModel? DamageModifier { get; set; }

            public SpellScaling(string description, DamageRollModel? damageModifier = null)
            {
                Description = description;
                DamageModifier = damageModifier;
            }
        }
    }
}
