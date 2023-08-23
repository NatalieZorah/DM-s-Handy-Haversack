using HaversackLibrary.Models.ActionModels.DiceModels;
using static HaversackLibrary.Enums;
using static HaversackLibrary.Structs;

namespace HaversackLibrary.Models.ActionModels.SpellCastingModels
{
    public class SpellModel
    {
        // TODO - Documentation
        public string Name { get; set; }
        public string Description { get; set; }
        public SpellLevel Level { get; set; }
        public AttackRange Range { get; set; }
        public bool HasScaling { get; set; }
        public SpellScaling? SpellScaling { get; set; }
        public AttackRollModel? AttackRoll { get; set; }
        public DamageRollModel? DamageRoll { get; set; }
        public int? ConcentrationDuration { get; set; }
        public AttributeType? SaveAttribute { get; set; }


        public SpellModel(string name,
            string description,
            SpellLevel level,
            AttackRange range,
            bool hasScaling,
            SpellScaling? spellScaling = null,
            AttackRollModel? attackRoll = null,
            DamageRollModel? damageRoll = null,
            int? concentrationDuration = null,
            AttributeType? saveAttribute = null)
        {
            Name = name;
            Description = description;
            Level = level;
            Range = range;
            HasScaling = hasScaling;
            SpellScaling = spellScaling;
            AttackRoll = attackRoll;
            DamageRoll = damageRoll;
            ConcentrationDuration = concentrationDuration;
            SaveAttribute = saveAttribute;
        }


    }
}
