using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.StatusModels;

namespace HaversackLibrary.Models.ActionModels.SpellCastingModels
{
    public class SpellCastingModel : IActionModel
    {
        // TODO - Documentation
        public string Name { get; set; }
        public string Description { get; set; }
        public AttributeModel CastingAttribute { get; set; }
        public int CastingModifier { get; set; }
        public int SpellAttack { get; set; }
        public int SaveDC { get; set; }
        public SpellArrayModel SpellArray { get; set; }
        private int MiscelaneousCastingBonus { get; set; }
        private int ProficiencyBonus { get; set; }

        public SpellCastingModel(string name,
            string description,
            AttributeModel castingAttribute,
            int proficiencyBonus,
            int miscelaneousCastingBonus = 0)
        {
            Name = name;
            Description = description;
            CastingAttribute = castingAttribute;
            CastingModifier = castingAttribute.Modifier;
            MiscelaneousCastingBonus = miscelaneousCastingBonus;
            ProficiencyBonus = proficiencyBonus;
            SpellAttack = GenerateSpellAttack();
            SaveDC = GenerateSpellSaveDC();
        }

        private int GenerateSpellAttack()
        {
            return CastingModifier + ProficiencyBonus + MiscelaneousCastingBonus;
        }

        private int GenerateSpellSaveDC()
        {
            int baseDC = 8;
            return baseDC + ProficiencyBonus + CastingModifier + MiscelaneousCastingBonus;
        }
    }
}
