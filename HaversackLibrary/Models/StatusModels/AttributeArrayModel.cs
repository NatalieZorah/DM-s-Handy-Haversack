using HaversackLibrary.Models.CharacterModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.StatusModels
{
    public class AttributeArrayModel
    {
        /// <summary>
        /// The Strength attribute for this array.
        /// </summary>
        public AttributeModel Strength { get; set; }
        /// <summary>
        /// The Dexterity attribute for this array.
        /// </summary>
        public AttributeModel Dexterity { get; set; }
        /// <summary>
        /// The Constitution attribute for this array.
        /// </summary>
        public AttributeModel Constitution { get; set; }
        /// <summary>
        /// The Intelligence attribute for this array.
        /// </summary>
        public AttributeModel Intelligence { get; set; }
        /// <summary>
        /// The Wisdom attribute for this array.
        /// </summary>
        public AttributeModel Wisdom { get; set; }
        /// <summary>
        /// The Charisma attribute for this array.
        /// </summary>
        public AttributeModel Charisma { get; set; }

        /// <summary>
        /// Constructor for the Attribute array.
        /// </summary>
        /// <param name="strength">Strength score value.</param>
        /// <param name="dexterity">Dexterity score value.</param>
        /// <param name="constitution">Constitution score value.</param>
        /// <param name="intelligence">Intelligence score value.</param>
        /// <param name="wisdom">Wisdom score value.</param>
        /// <param name="charisma">Charisma score value.</param>
        public AttributeArrayModel(
            int strength,
            int dexterity,
            int constitution,
            int intelligence,
            int wisdom,
            int charisma)
        {
            Strength = new AttributeModel(AttributeType.Strength, strength);
            Dexterity = new AttributeModel(AttributeType.Dexterity, dexterity);
            Constitution = new AttributeModel(AttributeType.Constitution, constitution);
            Intelligence = new AttributeModel(AttributeType.Intelligence, intelligence);
            Wisdom = new AttributeModel(AttributeType.Wisdom, wisdom);
            Charisma = new AttributeModel(AttributeType.Charisma, charisma);
        }

        /// <summary>
        /// Sets the save proficiency for a given attribute.
        /// </summary>
        /// <param name="attribute">The attribute being set.</param>
        /// <param name="proficiency">Default true boolean for save proficiency.</param>
        public void SetSaveProficiency(AttributeType attribute, bool proficiency = true)
        {
            GetAttributeByName(attribute).SaveProficiency = proficiency;
        }

        /// <summary>
        /// Returns the requested attribute by its name.
        /// </summary>
        /// <param name="attribute">The attribute you are looking for.</param>
        /// <returns>AttributeModel for requested attribute.</returns>
        private AttributeModel GetAttributeByName(AttributeType attribute)
        {
            AttributeModel model = new AttributeModel();
            switch (attribute)
            {
                case AttributeType.Strength:
                    model = Strength;
                    break;
                case AttributeType.Dexterity:
                    model = Dexterity;
                    break;
                case AttributeType.Constitution:
                    model = Constitution;
                    break;
                case AttributeType.Intelligence:
                    model = Intelligence;
                    break;
                case AttributeType.Wisdom:
                    model = Wisdom;
                    break;
                case AttributeType.Charisma:
                    model = Charisma;
                    break;
            }
            return model;
        }

        /// <summary>
        /// Finds the attribue modifier for the chosen attribute.
        /// </summary>
        /// <param name="attribute">The attribute to query</param>
        /// <returns>Integer value of chosen attribute.</returns>
        public int GetAttributeModifierByName(AttributeType attribute)
        {
            return GetAttributeByName(attribute).Modifier;
        }

        public void UpdateAttribute(AttributeModel attribute, int? value = null, bool? isProficient = null)
        {
            attribute.Value = value ?? attribute.Value;
            attribute.SaveProficiency = isProficient ?? attribute.SaveProficiency;
            attribute.UpdateModifier();
        }
    }
}
