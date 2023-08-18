using HaversackLibrary.Interfaces;
using System.Drawing;

namespace HaversackLibrary.Models.CharacterModels
{
    public class PassiveSenseModel : ICharacterSense
    {
        /// <summary>
        /// The name of this passive sense.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The range at which this sense applies.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// The constructor for a new passive sense.
        /// </summary>
        /// <param name="name">The name of the sense.</param>
        /// <param name="range">The range the sense works at.</param>
        public PassiveSenseModel(string name, int range)
        {
            Name = name;
            Range = range;
        }
    }
}
