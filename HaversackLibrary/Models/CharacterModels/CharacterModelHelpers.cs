using HaversackLibrary.Models.StatusModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public partial class CharacterModel
    {
        /// <summary>
        /// Updates the character name with the provided one.
        /// </summary>
        /// <remarks>Useful for when you need to add a last name, or correct spelling errors, etc.</remarks>
        /// <param name="newName">The replacement name for the character.</param>
        public void UpdateName(string newName) { Name = newName; }

        /// <summary>
        /// Updates the player name for the given character.
        /// </summary>
        /// <remarks>Useful for when player's change their name, or spelling errors occur.</remarks>
        /// <param name="newPlayerName">The replacement name for the player.</param>
        public void UpdatePlayerName(string newPlayerName) { PlayerName = newPlayerName; }

        /// <summary>
        /// Updates the character's armor class.
        /// </summary>
        /// <param name="newArmorClass">The new armor class for the character.</param>
        public void UpdateArmorClass(int newArmorClass) { ArmorClass = newArmorClass; }

        /// <summary>
        /// Updates the race for the character.
        /// </summary>
        /// <remarks>Useful for when someone gains vampirism or undeath, or for reincarnations.</remarks>
        /// <param name="newRace">The new race for the character.</param>
        public void UpdateRace(RaceModel newRace) { Race = newRace; }

        /// <summary>
        /// Adds a new character class to the list of classes if it isn't already present. 
        /// </summary>
        /// <param name="newClass">The new class to add to the list.</param>
        public void AddClass(ClassModel newClass)
        {
            if (!CharacterClassExists(newClass.Name))
            {
                ClassList.Add(newClass);
            }
        }

        /// <summary>
        /// Updates a class on the list of classes for this character.
        /// </summary>
        /// <param name="className">The class you wish to update.</param>
        /// <param name="levelUp">Optional bool for leveling up the chosen class.</param>
        /// <param name="subclassName">Optional string for adding a new subclass to the chosen class.</param>
        public void UpdateClass(string className, bool? levelUp = null, string? subclassName = null)
        {
            var targetClass = ClassList.SingleOrDefault(c => c.Name.Equals(className));

            if (targetClass != null)
            {
                if (levelUp.HasValue)
                {
                    targetClass.LevelUp();
                }

                if (subclassName != null)
                {
                    targetClass.SetSubclass(subclassName);
                }
                UpdateLevel();
            }
        }

        /// <summary>
        /// Adds a new movement to the list of movements if it isn't already present.
        /// </summary>
        /// <param name="newMovement">The movement to add to the list.</param>
        public void AddMovement(MovementModel newMovement)
        {
            if (!MovementExists(newMovement.Type))
            {
                Movements.Add(newMovement);
            }
        }

        /// <summary>
        /// Updates the chosen movement type with a new speed.
        /// </summary>
        /// <param name="movement">The movement type you wish to update.</param>
        /// <param name="newSpeed">The new speed for the movement.</param>
        public void UpdateMovement(MovementType movement, int newSpeed)
        {
            var targetMovement = Movements.SingleOrDefault(m => m.Type.Equals(movement));

            if (targetMovement != null)
            {
                targetMovement.Speed = newSpeed;
            }
        }

        /// <summary>
        /// Adds languages to the list of known languages for this character.
        /// </summary>
        /// <param name="language">The language to be added to the known List.</param>
        public void AddLanguage(LanguageModel language)
        {
            if (!LanguageExists(language.Language))
            {
                LanguageList.Add(language);
            }
        }

        /// <summary>
        /// Adds a defense to the list of defenses if it isn't already present
        /// </summary>
        /// <param name="defense"></param>
        public void AddDefense(DefenseModel defense)
        {
            if (!DefenseExists(defense.Defense))
            {
                DefenseList.Add(defense);
            }
        }

    }
}
