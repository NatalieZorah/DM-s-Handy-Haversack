using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public class SkillModel
    {
        /// <summary>
        /// The specific skill in question.
        /// </summary>
        public Skills Skill { get; set; }
        /// <summary>
        /// The attribute the skill is associated with.
        /// </summary>
        /// <remarks>
        /// The skill would pull the modifier from the character's attribute to calculate
        /// the bonus to its roll.
        /// </remarks>
        /// <example>Athletics -> Strength</example>
        /// <seealso cref="AttributeType"/>
        public AttributeType Attribute { get; set; }
        /// <summary>
        /// Denotes whether the character has proficiency or expertise with the skill and would add that
        /// bonus to their roll as well.
        /// </summary>
        public ProficiencyType Proficiency { get; set; }
        /// <summary>
        /// The bonus added to the roll of the dice.
        /// </summary>
        public int Bonus { get; set; }

        public SkillModel(Skills skill, AttributeType attribute, int bonus = 0, ProficiencyType proficiency = ProficiencyType.Normal)
        {
            Skill = skill;
            Attribute = attribute;
            Proficiency = proficiency;
            Bonus = bonus;
        }
    }
}
