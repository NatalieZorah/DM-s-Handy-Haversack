using HaversackLibrary.Factories;
using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.ItemModels;
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
        /// The character's armor class.
        /// </summary>
        public int ArmorClass { get; set; }
        /// <summary>
        /// The character's race.
        /// </summary>
        public RaceModel Race { get; set; }
        /// <summary>
        /// THe list of classes for this character.
        /// </summary>
        /// <seealso cref="ClassModel"/>
        public List<ClassModel> ClassList { get; set; }
        /// <summary>
        /// The list of attributes for this character.
        /// </summary>
        /// <seealso cref="AttributeModel"/>
        public List<AttributeModel> Attributes { get; set; }
        /// <summary>
        /// The proficiency bonus calculated based off total level.
        /// </summary>
        public int ProficiencyBonus { get; set; }
        /// <summary>
        /// The character's total level.
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// The total HitPoints for this character.
        /// </summary>
        public HitPointModel HitPoints { get; set; }
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
        /// The list of passive skills and senses this character has.
        /// </summary>
        public List<ICharacterSense> PassiveSenses { get; set; }
        /// <summary>
        /// The constructor for building a specific character.
        /// </summary>
        /// <param name="name">The name for the new character.</param>
        /// <param name="level">The level for the new character.</param>
        public CharacterModel(string name,
            string playerName,
            int armorClass,
            RaceModel race,
            List<ClassModel> classList,
            List<AttributeModel> attributes,
            bool hitPointRollOrAverage = false)
        {
            Name = name;
            PlayerName = playerName;
            ArmorClass = armorClass;
            Race = race;
            ClassList = classList;
            Attributes = attributes;
            ProficiencyBonus = GenerateProficiencyBonus();
            Level = GetCharacterLevel();
            HitPoints = GenerateHitPoints(hitPointRollOrAverage);
            SkillList = GenerateSkills();
            GearProficiencyList = new List<GearModel>();
            LanguageList = GenerateLanguages();
            DefenseList = GenerateDefenses();
            PassiveSenses = GeneratePassiveSenses();
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

        /// <summary>
        /// Finds the attribue modifier for the chosen attribute.
        /// </summary>
        /// <param name="attribute">The attribute to query</param>
        /// <returns>Integer value of chosen attribute.</returns>
        public int GetAttributeModifierByName(AttributeType attribute)
        {
            AttributeModel? attributeModel = Attributes.FirstOrDefault(attr => attr.Name == attribute);
            return attributeModel != null ? attributeModel.Modifier : 0;
        }

        /// <summary>
        /// Generages hit points for this character.
        /// </summary>
        /// <param name="hitPointRollOrAverage">Boolean for whether to use the average roll when it is higher than the roll.</param>
        /// <returns>HitPointModel</returns>
        private HitPointModel GenerateHitPoints(bool hitPointRollOrAverage)
        {
            return new HitPointModel(GenerateHitDice(), GetAttributeModifierByName(AttributeType.Constitution), hitPointRollOrAverage);
        }

        /// <summary>
        /// Generates the list of languages this character knows.
        /// </summary>
        /// <returns>A List of LanguageModels that the character knows.</returns>
        private List<LanguageModel> GenerateLanguages()
        {
            List<LanguageModel> languages = new List<LanguageModel>();

            if (CanAddLanguage("Common"))
            {
                languages.Add(new LanguageModel("Common", Race.Name));
            }

            ClassList.ForEach(clazz =>
            {
                if (clazz.Name == "Druid" && CanAddLanguage("Druidic"))
                {
                    languages.Add(new LanguageModel("Druidic", clazz.Name));
                }

                if (clazz.Name == "Rogue" && CanAddLanguage("Thieve's Cant"))
                {
                    languages.Add(new LanguageModel("Thieve's Cant", clazz.Name));
                }
            });

            Race.Languages.ForEach(lang =>
            {
                if (CanAddLanguage(lang.Language))
                {
                    languages.Add(lang);
                }
            });

            return languages;
        }

        /// <summary>
        /// Checks whether the given language exists within the list of known languages.
        /// </summary>
        /// <param name="language">The name of the language you are looking for.</param>
        /// <returns>True when langauge is not present, false if it is.</returns>
        private bool CanAddLanguage(string language)
        {
            if (LanguageList == null) { return true; }
            return !LanguageList.Any(lang => lang.Language.Equals(language, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Adds languages to the list of known languages for this character.
        /// </summary>
        /// <param name="language">The language to be added to the known List.</param>
        public void AddLanguage(LanguageModel language)
        {
            if (CanAddLanguage(language.Language))
            {
                LanguageList.Add(language);
            }
        }

        /// <summary>
        /// Generates the list of defenses this character has.
        /// </summary>
        /// <returns>A List of DefenseModel.</returns>
        private List<DefenseModel> GenerateDefenses()
        {
            List<DefenseModel> defenses = new List<DefenseModel>();
            Race.Defenses.ForEach(defense =>
            {
                if (CanAddDefense(defense.Defense))
                {
                    defenses.Add(defense);
                }
            });
            return defenses;
        }

        /// <summary>
        /// Checks whether a given defense is already present within the characters list of defenses.
        /// </summary>
        /// <param name="defense">The name of the defense.</param>
        /// <returns>True when the defense isn't on the known list, false if it is.</returns>
        private bool CanAddDefense(IDefenseType defense)
        {
            if (DefenseList == null) { return true; }
            return !DefenseList.Any(def => def.Defense.Equals(defense));
        }

        /// <summary>
        /// Adds a defense to the list of defenses if it isn't already present
        /// </summary>
        /// <param name="defense"></param>
        public void AddDefense(DefenseModel defense)
        {
            if (CanAddDefense(defense.Defense))
            {
                DefenseList.Add(defense);
            }
        }

        /// <summary>
        /// Generates the full list of passive senses this character has.
        /// </summary>
        /// <returns>List of ICharacterSense including passive skills and senses.</returns>
        private List<ICharacterSense> GeneratePassiveSenses()
        {
            List<ICharacterSense> characterSenses = new List<ICharacterSense>();

            Skills[] skills = new Skills[3] { Skills.Insight, Skills.Investigation, Skills.Perception };

            SkillList.ForEach(skill =>
            {
                if (skills.Contains(skill.Skill))
                {
                    characterSenses.Add(new PassiveSkillModel(skill));
                }
            });

            Race.PassiveSenses.ForEach(sense => characterSenses.Add(sense));

            return characterSenses;
        }
    }
}
