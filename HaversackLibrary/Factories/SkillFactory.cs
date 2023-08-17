using HaversackLibrary.Models.CharacterModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Factories
{
    public class SkillFactory
    {
        private Dictionary<Skills, SkillModel> CharacterSkills = new Dictionary<Skills, SkillModel>()
        {
            { Skills.Acrobatics, new SkillModel(Skills.Acrobatics, AttributeType.Dexterity) },
            { Skills.Animal_Handling, new SkillModel(Skills.Animal_Handling, AttributeType.Wisdom) },
            { Skills.Arcana, new SkillModel(Skills.Arcana, AttributeType.Intelligence) },
            { Skills.Athletics, new SkillModel(Skills.Athletics, AttributeType.Strength) },
            { Skills.Deception, new SkillModel(Skills.Deception, AttributeType.Charisma) },
            { Skills.History, new SkillModel(Skills.History, AttributeType.Intelligence) },
            { Skills.Insight, new SkillModel(Skills.Insight, AttributeType.Wisdom) },
            { Skills.Intimidation, new SkillModel(Skills.Intimidation, AttributeType.Charisma) },
            { Skills.Investigation, new SkillModel(Skills.Investigation, AttributeType.Intelligence) },
            { Skills.Medicine, new SkillModel(Skills.Medicine, AttributeType.Wisdom) },
            { Skills.Nature, new SkillModel(Skills.Nature, AttributeType.Intelligence) },
            { Skills.Perception, new SkillModel(Skills.Perception, AttributeType.Wisdom) },
            { Skills.Performance, new SkillModel(Skills.Performance, AttributeType.Charisma) },
            { Skills.Persuasion, new SkillModel(Skills.Persuasion, AttributeType.Charisma) },
            { Skills.Religion, new SkillModel(Skills.Religion, AttributeType.Intelligence) },
            { Skills.Sleight_of_Hand, new SkillModel(Skills.Sleight_of_Hand, AttributeType.Dexterity) },
            { Skills.Stealth, new SkillModel(Skills.Stealth, AttributeType.Dexterity) },
            { Skills.Survival, new SkillModel(Skills.Survival, AttributeType.Wisdom) },
        };

        public SkillModel Skill(Skills skill, int attributeModifier, ProficiencyType proficiency = ProficiencyType.Normal)
        {
            if (CharacterSkills.TryGetValue(skill, out var skillModel))
            {
                return new SkillModel(skillModel.Skill, skillModel.Attribute, attributeModifier, proficiency);
            }
            throw SkillNotFoundException(skill);
        }

        public SkillModel Skill(Skills skill, Dictionary<AttributeType, int> attributeModifiers, ProficiencyType proficiency = ProficiencyType.Normal)
        {
            if (CharacterSkills.TryGetValue(skill, out var skillModel))
            {
                if (attributeModifiers.TryGetValue(skillModel.Attribute, out var modifier))
                {
                    return Skill(skillModel.Skill, modifier, proficiency);
                }
                throw new KeyNotFoundException("Attribute not found.");
            }

            throw SkillNotFoundException(skill);
        }

        public AttributeType GetSkillAttribute(Skills skill)
        {
            if (CharacterSkills.TryGetValue(skill, out var skillModel))
            {
                return skillModel.Attribute;
            }
            throw SkillNotFoundException(skill);
        }

        private Exception SkillNotFoundException(Skills skill)
        {
            throw new KeyNotFoundException($"Skill \"{skill}\" not found.");
        }
    }
}
