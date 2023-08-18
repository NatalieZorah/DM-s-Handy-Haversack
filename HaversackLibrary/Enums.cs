using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaversackLibrary
{
    public static class Enums
    {
        /// <summary>
        /// The list of all Character attributes.
        /// </summary>
        public enum AttributeType
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }

        /// <summary>
        /// The list of all dice used by classes and rolling.
        /// </summary>
        public enum DiceType
        {
            D4,
            D6,
            D8,
            D10,
            D12,
            D20,
            D100
        }

        /// <summary>
        /// The list of resistance types available to characters.
        /// </summary>
        public enum ResistanceType
        {
            Vulnerability,
            Resistance,
            Immunity
        }

        /// <summary>
        /// The list of gear types available to characters.
        /// </summary>
        public enum GearType
        {
            Tool,
            Weapon,
            Armor
        }

        /// <summary>
        /// The list of all possible skills available to characters.
        /// </summary>
        public enum Skills
        {
            Acrobatics,
            Animal_Handling,
            Arcana,
            Athletics,
            Deception,
            History,
            Insight,
            Intimidation,
            Investigation,
            Medicine,
            Nature,
            Perception,
            Performance,
            Persuasion,
            Religion,
            Sleight_of_Hand,
            Stealth,
            Survival
        }

        /// <summary>
        /// The list of all passive skills a character will have.
        /// </summary>
        public enum PassiveSkill
        {
            Perception,
            Investigation,
            Insight
        }

        /// <summary>
        /// The list of all possible conditions.
        /// </summary>
        public enum Condition
        {
            Blinded,
            Charmed,
            Deafened,
            Exhaustion,
            Frightened,
            Grappled,
            Incapacitated,
            Invisible,
            Paralyzed,
            Petrified,
            Poisoned,
            Prone,
            Restrained,
            Stunned,
            Unconscious
        }

        /// <summary>
        /// The list of all damage types.
        /// </summary>
        public enum DamageType
        {
            Acid,
            Bludgeoning,
            Cold,
            Fire,
            Force,
            Lightning,
            Necrotic,
            Piercing,
            Poison,
            Psychic,
            Radiant,
            Slashing,
            Thunder
        }

        /// <summary>
        /// The list of all movement types.
        /// </summary>
        public enum MovementType
        {
            Walking,
            Flying,
            Burrowing,
            Swimming,
            Climbing
        }

        /// <summary>
        /// The list of all proficiency states.
        /// </summary>
        public enum ProficiencyType
        {
            Normal,
            Proficient,
            Expert
        }

        /// <summary>
        /// The list of all creature types.
        /// </summary>
        public enum CreatureType
        {
            Abberation,
            Beast,
            Celestial,
            Construct,
            Dragon,
            Elemental,
            Fey,
            Fiend,
            Giant,
            Humanoid,
            Monstrosity,
            Ooze,
            Plant,
            Undead
        }
    }
}
