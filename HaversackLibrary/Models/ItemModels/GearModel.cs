using HaversackLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.ItemModels
{
    public class GearModel
    {
        /// <summary>
        /// The short name for the item.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the type of this specific gear.
        /// </summary>
        public GearType Type { get; set; }
        /// <summary>
        /// The description for this gear item.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Designates whether the character has proficiency with this item.
        /// </summary>
        public bool Proficiency { get; set; }

        public GearModel(string name, GearType type, string description = "PLACEHOLDER", bool proficiency = true)
        {
            Name = name;
            Type = type;
            Description = description;
            Proficiency = proficiency;
        }
    }
}
