using static HaversackLibrary.Enums;
using HaversackLibrary.Models.ItemModels;
using HaversackLibrary.Factories;
using HaversackLibrary.Models.StatusModels;
using HaversackLibrary.Interfaces;

namespace HaversackLibrary.Models.CharacterModels
{
    public class ClassModel : IActorClassModel
    {
        /// <summary>
        /// Represents the specific name of the class.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the level for this instance of the class.
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Represents the name of the subclass, if applicable.
        /// </summary>
        public string Subclass { get; set; }
        /// <summary>
        /// Represents the specific hit die this character class uses.
        /// </summary>
        public DiceType HitDice { get; set; }
        /// <summary>
        /// Represents the list of gear proficiences for the given class. 
        /// </summary>
        public List<GearModel> GearProficiencies { get; set; }
        /// <summary>
        /// Represents the list of save proficiencies for the given class.
        /// </summary>
        public List<AttributeType> SaveProficiencies { get; set; }
        /// <summary>
        /// Represents the level at which the class can gain a subclass.
        /// </summary>
        public int SubclassAtLevel { get; set; }
        /// <summary>
        /// Denotes whether this is the primary class or not.
        /// </summary>
        public bool IsPrimaryClass { get; set; }

        /// <summary>
        /// Constructor for base ClassModels, used in factory class to define default values.
        /// </summary>
        /// <param name="name">The class Name.</param>
        /// <param name="hitDiceType">The hit die the class uses.</param>
        /// <param name="subclassAtLevel">The level the class recieves its subclass at.</param>
        public ClassModel(string name, DiceType hitDiceType, int subclassAtLevel)
        {
            ProficienciesFactory profs = new ProficienciesFactory();

            Name = name;
            Level = 1;
            HitDice = hitDiceType;
            GearProficiencies = profs.GetClassGearProficiencies(name);
            SaveProficiencies = profs.GetClassSaveProficiencies(name);
            SubclassAtLevel = subclassAtLevel;
            Subclass = SetSubclass("None");
            IsPrimaryClass = false;
        }
        /// <summary>
        /// Primary constructor for Character Classes.
        /// </summary>
        /// <remarks>
        /// The output of the CharacterClassFactory will be generated with this constructor.
        /// </remarks>
        /// <param name="name">The class Name.</param>
        /// <param name="hitDiceType">The hit die the class uses.</param>
        /// <param name="gearProficiencies">The gear proficiencies for this class.</param>
        /// <param name="saveProficiencies">The save proficiencies for this class.</param>
        /// <param name="subclassAtLevel">The level the class recieves its subclass at.</param>
        /// <param name="level">The level attained in this specific class.</param>
        /// <param name="subclass">The name of the Subclass for this class.</param>
        /// <param name="isPrimaryClass">Denotes whether this is the primary class for the character or not.</param>
        public ClassModel(
            string name,
            DiceType hitDiceType,
            List<GearModel> gearProficiencies,
            List<AttributeType> saveProficiencies,
            int subclassAtLevel,
            int level = 1,
            string subclass = "None",
            bool isPrimaryClass = false)
        {
            Name = name;
            Level = level;
            HitDice = hitDiceType;
            GearProficiencies = gearProficiencies;
            SaveProficiencies = saveProficiencies;
            SubclassAtLevel = subclassAtLevel;
            Subclass = SetSubclass(subclass);
            IsPrimaryClass = isPrimaryClass;
        }



        /// <summary>
        /// Generates the Hit Dice Model for this class.
        /// </summary>
        /// <example> 3D10 </example>
        /// <returns>HitDiceModel</returns>
        public HitDiceModel GetHitDice()
        {
            return new HitDiceModel(HitDice, IsPrimaryClass, Level);
        }

        private bool CanHaveSubclass()
        {
            if (Level >= SubclassAtLevel)
            {
                return true;
            }
            return false;
        }

        public string SetSubclass(string subclassName)
        {
            if (CanHaveSubclass())
            {
                return subclassName;
            }
            return "Unavailable";
        }

        public void SetClassLevel(int level)
        {
            Level = level;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}
