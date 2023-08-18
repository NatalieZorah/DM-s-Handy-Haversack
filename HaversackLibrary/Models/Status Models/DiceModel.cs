using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models
{
    public class DiceModel
    {
        /// <summary>
        /// Represents the die you are looking to model.
        /// </summary>
        public DiceType Die { get; set; }
        /// <summary>
        /// Holds the quantity of the die in question.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Constructs the DiceModel for rolling later.
        /// </summary>
        /// <param name="die"></param>
        /// <param name="count"></param>
        public DiceModel(DiceType die, int count = 1)
        {
            Die = die;
            Count = count;
        }

    }
}
