using HaversackLibrary.Models.StatusModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public partial class CharacterModel
    {
        public void UpdateName(string newName) { Name = newName; }

        public void UpdatePlayerName(string newPlayerName) { PlayerName = newPlayerName; }

        public void UpdateArmorClass(int newArmorClass) { ArmorClass = newArmorClass; }

        public void UpdateRace(RaceModel newRace) { Race = newRace; }

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
            if (CanAddLanguage(language.Language))
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
            if (CanAddDefense(defense.Defense))
            {
                DefenseList.Add(defense);
            }
        }

    }
}
