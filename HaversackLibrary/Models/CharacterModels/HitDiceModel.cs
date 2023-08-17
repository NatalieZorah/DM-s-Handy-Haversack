using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.CharacterModels
{
    public class HitDiceModel : DiceModel
    {
        /// <summary>
        /// Designates this model as belonging to the primary class for the character.
        /// </summary>
        public bool PrimaryClass { get; set; }
        /// <summary>
        /// Constructor for a class' hit dice, based on ClassName and Level.
        /// </summary>
        /// <param name="hitDie">The specific die used as a hit die.</param>
        /// <param name="level">The level in the class for which you are tring to find the hit dice.</param>
        /// <seealso cref="DiceModel"/>
        public HitDiceModel(DiceType hitDie, bool primaryClass = false, int level = 1) : base(hitDie, level)
        {
            PrimaryClass = primaryClass;
        }
    }
}
