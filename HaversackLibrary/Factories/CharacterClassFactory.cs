using HaversackLibrary.Models.CharacterModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Factories
{
    public class CharacterClassFactory
    {
        private Dictionary<string, ClassModel> CharacterClasses = new Dictionary<string, ClassModel>()
        {
            { "Artificer", new ClassModel("Artificer",DiceType.D8,3) },
            { "Barbarian", new ClassModel("Barbarian",DiceType.D12,3) },
            { "Bard", new ClassModel("Bard",DiceType.D8,3) },
            { "Bloodhunter", new ClassModel("Bloodhunter",DiceType.D10,3) },
            { "Cleric", new ClassModel("Cleric",DiceType.D8,1) },
            { "Druid", new ClassModel("Druid",DiceType.D8,2) },
            { "Fighter", new ClassModel("Fighter",DiceType.D10,3) },
            { "Monk", new ClassModel("Monk",DiceType.D8,3) },
            { "Paladin", new ClassModel("Paladin",DiceType.D10,3) },
            { "Ranger", new ClassModel("Ranger",DiceType.D10,3) },
            { "Rogue", new ClassModel("Rogue",DiceType.D8,3) },
            { "Sorcerer", new ClassModel("Sorcerer",DiceType.D6,1) },
            { "Warlock", new ClassModel("Warlock",DiceType.D8,1) },
            { "Wizard", new ClassModel("Wizard",DiceType.D6,2) },
        };

        /// <summary>
        /// CharacterClass factory method.
        /// </summary>
        /// <param name="className">The name of the class you would like to build.</param>
        /// <param name="level">Optional param for the starting level of the class. Defaults to 1.</param>
        /// <param name="subclass">Optional param for the subclass choice. Defaults to "None".</param>
        /// <returns>New instance of a ClassModel for the chosen class.</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public ClassModel CharacterClass(string className, int level = 1, string subclass = "None", bool isPrimaryClass = false)
        {
            if (CharacterClasses.TryGetValue(className, out var classModel))
            {
                return new ClassModel(
                    classModel.Name,
                    classModel.HitDice,
                    classModel.GearProficiencies,
                    classModel.SaveProficiencies,
                    classModel.SubclassAtLevel,
                    level,
                    subclass,
                    isPrimaryClass);
            }

            throw new KeyNotFoundException($"Character Class \"{className}\" not found.");
        }
    }
}
