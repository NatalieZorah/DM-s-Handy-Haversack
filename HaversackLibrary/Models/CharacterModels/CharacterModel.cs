using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.StatusModels;

namespace HaversackLibrary.Models.CharacterModels
{
    public partial class CharacterModel
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
        public AttributeArrayModel Attributes { get; set; }
        /// <summary>
        /// List of all movement types and their speeds.
        /// </summary>
        public List<MovementModel> Movements { get; set; }
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
        /// All proficiencies for this character.
        /// </summary>
        public ProficienciesModel Proficiencies { get; set; }
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
            AttributeArrayModel attributes,
            List<MovementModel> movements,
            bool hitPointRollOrAverage = false)
        {
            Name = name;
            PlayerName = playerName;
            ArmorClass = armorClass;
            Race = race;
            ClassList = classList;
            Attributes = attributes;
            Movements = movements;
            ProficiencyBonus = GenerateProficiencyBonus();
            Level = GenerateCharacterLevel();
            HitPoints = GenerateHitPoints(hitPointRollOrAverage);
            Proficiencies = GenerateProficiencies();
            LanguageList = GenerateLanguages();
            DefenseList = GenerateDefenses();
            PassiveSenses = GeneratePassiveSenses();
            GenerateSaves();
        }
    }
}
