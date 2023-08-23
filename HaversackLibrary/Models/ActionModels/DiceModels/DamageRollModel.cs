using HaversackLibrary.Models.StatusModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.ActionModels.DiceModels
{
    public class DamageRollModel : DiceModel
    {
        // TODO - Documentation
        public int Modifier { get; set; }

        public DamageRollModel(DiceType damageDie, int count, int modifier = 0) : base(damageDie, count)
        {
            Modifier = modifier;
        }
    }
}
