using HaversackLibrary.Factories;
using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.StatusModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public partial class CharacterModel
    {

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
        private ProficienciesModel GenerateProficiencies()
        {
            return new ProficienciesModel(Attributes, ClassList);
        }

        /// <summary>
        /// Generates the overall character level from the sum total of each class level.
        /// </summary>
        private int GenerateCharacterLevel()
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
        /// Generages hit points for this character.
        /// </summary>
        /// <param name="hitPointRollOrAverage">Boolean for whether to use the average roll when it is higher than the roll.</param>
        /// <returns>HitPointModel</returns>
        private HitPointModel GenerateHitPoints(bool hitPointRollOrAverage)
        {
            return new HitPointModel(GenerateHitDice(), Attributes.GetAttributeModifierByName(AttributeType.Constitution), hitPointRollOrAverage);
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
        /// Generates the full list of passive senses this character has.
        /// </summary>
        /// <returns>List of ICharacterSense including passive skills and senses.</returns>
        private List<ICharacterSense> GeneratePassiveSenses()
        {
            List<ICharacterSense> characterSenses = new List<ICharacterSense>();

            Skills[] skills = new Skills[3] { Skills.Insight, Skills.Investigation, Skills.Perception };

            Proficiencies.SkillProficiencies.ForEach(skill =>
            {
                if (skills.Contains(skill.Skill))
                {
                    characterSenses.Add(new PassiveSkillModel(skill));
                }
            });

            Race.PassiveSenses.ForEach(sense => characterSenses.Add(sense));

            return characterSenses;
        }

        /// <summary>
        /// Generates the save prooficiencies based on the primary character class.
        /// </summary>
        private void GenerateSaves()
        {
            ProficienciesFactory factory = new ProficienciesFactory();

            ClassList.ForEach(cls =>
            {
                if (cls.IsPrimaryClass)
                {
                    factory.GetClassSaveProficiencies(cls.Name).ForEach(proficiency =>
                    {
                        Attributes.SetSaveProficiency(proficiency);
                    });
                }
            });
        }

        /// <summary>
        /// Updates the character's level and subsequent relevant values.
        /// </summary>
        private void UpdateLevel()
        {
            Level = GenerateCharacterLevel();
            ProficiencyBonus = GenerateProficiencyBonus();
            PassiveSenses = GeneratePassiveSenses();
            // TODO - Refactor for better functionality
            HitPoints = GenerateHitPoints(true);
        }
    }
}
