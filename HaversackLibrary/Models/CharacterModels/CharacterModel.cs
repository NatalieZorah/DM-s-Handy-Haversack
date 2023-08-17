using HaversackLibrary.Factories;
using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public class CharacterModel
    {
        /// <summary>
        /// Unique identifier for the character.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Represents the Name of the character.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the Name of the Player this Character belongs to.
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// The character's total level.
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// The character's race.
        /// </summary>
        public string Race { get; set; }
        /// <summary>
        /// The proficiency bonus calculated based off total level.
        /// </summary>
        public int ProficiencyBonus { get; set; }
        /// <summary>
        /// THe list of classes for this character.
        /// </summary>
        /// <seealso cref="ClassModel"/>
        public List<ClassModel> ClassList { get; set; }
        /// <summary>
        /// The list of all hit dice for this character.
        /// </summary>
        public List<HitDiceModel> HitDice { get; set; }
        /// <summary>
        /// The list of attributes for this character.
        /// </summary>
        /// <seealso cref="AttributeModel"/>
        public List<AttributeModel> Attributes { get; set; }
        /// <summary>
        /// The list of skills for this character.
        /// </summary>
        /// <seealso cref="SkillModel"/>
        public List<SkillModel> SkillList { get; set; }
        /// <summary>
        /// The list of gear proficiencies for this character.
        /// </summary>
        /// <seealso cref="GearModel"/>
        public List<GearModel> GearProficiencyList { get; set; }
        /// <summary>
        /// The list of languages this character knows.
        /// </summary>
        /// <seealso cref="LanguageModel"/>
        public List<LanguageModel> LanguageList { get; set; }
        /// <summary>
        /// The list of defenses for this character.
        /// </summary>
        /// <seealso cref="DefenseModel"/>
        public List<DefenseModel> DefenseList { get; set; }
        /// <summary>
        /// The constructor for building a specific character.
        /// </summary>
        /// <param name="name">The name for the new character.</param>
        /// <param name="level">The level for the new character.</param>
        public CharacterModel(string name, string playerName, string race, List<ClassModel> classList, List<AttributeModel> attributes)
        {
            Name = name;
            PlayerName = playerName;
            Race = race;
            ClassList = classList;
            Attributes = attributes;
            GearProficiencyList = new List<GearModel>();
            Level = GetCharacterLevel();
            ProficiencyBonus = GenerateProficiencyBonus();
            SkillList = GenerateSkills();
            HitDice = GenerateHitDice();
            LanguageList = GenerateLanguages();
            // TODO - GenerateDefenseModel()
        }

        /// <summary>
        /// Method for grabbing the proficiency bonus based on character level.
        /// </summary>
        /// <param name="level">The character's total level.</param>
        /// <returns>Proficiency bonus as an Integer.</returns>
        private int GenerateProficiencyBonus()
        {
            int proficiencyBonus;

            switch (Level)
            {
                case int n when n < 5:
                    proficiencyBonus = 2;
                    break;

                case int n when n < 9:
                    proficiencyBonus = 3;
                    break;

                case int n when n < 13:
                    proficiencyBonus = 4;
                    break;

                case int n when n < 17:
                    proficiencyBonus = 5;
                    break;

                default:
                    proficiencyBonus = 6;
                    break;
            }

            return proficiencyBonus;
        }

        /// <summary>
        /// Method for generating the full list of default skills.
        /// </summary>
        private List<SkillModel> GenerateSkills()
        {
            SkillFactory skillFactory = new SkillFactory();

            Dictionary<AttributeType, int> attributeModifiers = new Dictionary<AttributeType, int>();

            List<SkillModel> skillList = new List<SkillModel>();

            foreach (AttributeModel attr in Attributes) // Assigns modifier values to appropriate variable
            {
                attributeModifiers[attr.Name] = attr.Modifier;
            }

            foreach (Skills skill in Enum.GetValues(typeof(Skills)))
            {
                skillList.Add(skillFactory.Skill(skill, attributeModifiers));
            }

            return skillList;
        }

        /// <summary>
        /// Updates the provided character data, preserving previous values. 
        /// </summary>
        /// <param name="newClassList">
        /// The new ClassList to be applied when adding a class.
        /// </param>
        /// <param name="newAttributes">
        /// The new Attributes to be applied when increasing one or more.
        /// </param>
        /// <param name="newSkillList">
        /// The new SkillList to be applied when gaining proficiency in one or more.
        /// </param>
        /// <param name="newGearProficiencies">
        /// The new gear proficiencies to be added when gaining proficiency.
        /// </param>
        /// <param name="newLangaugeList">
        /// The new language list to be updated when learning a new language.
        /// </param>
        /// <param name="newDefenseModels">
        /// The new list of defenses to be updated when appropriate.
        /// </param>
        public void UpdateCharacter(
            List<ClassModel>? newClassList = null,
            List<AttributeModel>? newAttributes = null,
            List<SkillModel>? newSkillList = null,
            List<GearModel>? newGearProficiencies = null,
            List<LanguageModel>? newLangaugeList = null,
            List<DefenseModel>? newDefenseModels = null)
        {
            ClassList = newClassList ?? ClassList;
            Attributes = newAttributes ?? Attributes;
            SkillList = newSkillList ?? SkillList;
            GearProficiencyList = newGearProficiencies ?? GearProficiencyList;
            LanguageList = newLangaugeList ?? LanguageList;
            DefenseList = newDefenseModels ?? DefenseList;
            Level = GetCharacterLevel();
        }

        /// <summary>
        /// Generates the overall character level from the sum total of each class level.
        /// </summary>
        private int GetCharacterLevel()
        {
            return ClassList.Sum(c => c.Level);
        }

        /// <summary>
        /// Generates the list of Hit Dice for this Character.
        /// </summary>
        private List<HitDiceModel> GenerateHitDice()
        {
            List<HitDiceModel> hitDice = new List<HitDiceModel>();

            foreach (ClassModel c in ClassList)
            {
                hitDice.Add(new HitDiceModel(c.HitDice, c.IsPrimaryClass, c.Level));
            }

            return hitDice;
        }


        private List<LanguageModel> GenerateLanguages()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds languages to the list of known languages for this character, or adds "Common" if it isn't present.
        /// </summary>
        /// <param name="language">The language to be added to the known List.</param>
        private void AddLanguage(LanguageModel? language = null)
        {
            if (language == null && !LanguageList.Any(lang =>
                lang.Language.Equals("Common", StringComparison.OrdinalIgnoreCase)))
            {
                LanguageList.Add(new LanguageModel("Common", Name));
            }
            else if (language != null && !LanguageList.Any(lang =>
                lang.Language.Equals(language.Language, StringComparison.OrdinalIgnoreCase)))
            {
                LanguageList.Add(language);
            }
        }

        private void AddDefense(DefenseModel? defense = null)
        {

        }
    }
}
