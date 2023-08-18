using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaversackLibrary.Interfaces;
using HaversackLibrary.Wrappers;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public class DefenseModel
    {
        /// <summary>
        /// The defense being modified by the resistance type.
        /// </summary>
        /// <seealso cref="DamageTypeWrapper"/>
        /// <seealso cref="ConditionWrapper"/>
        /// <example>DamageTypeWrapper.DamageType.Force, ConditionWrapper.Condition.Blinded</example>
        public IDefenseType Defense { get; set; }
        /// <summary>
        /// Where this specific defense is sourced from.
        /// </summary>
        /// <example>Class, Race, Item</example>
        public string Source { get; set; }
        /// <summary>
        /// Defines whether this is a resistance, immunity, or vulnerability.
        /// </summary>
        public ResistanceType Type { get; set; }
        /// <summary>
        /// Constructs a new defense object.
        /// </summary>
        /// <param name="defense">
        /// Either a DamageType or a Condition that is modified by the resistance type.
        /// </param>
        /// <param name="source">
        /// The source of the defense. (race) or (background)
        /// </param>
        /// <param name="type">
        /// One of three modifiers applicable.
        /// </param>
        public DefenseModel(IDefenseType defense, string source, ResistanceType type)
        {
            Defense = defense;
            Source = source;
            Type = type;
        }
    }
}
