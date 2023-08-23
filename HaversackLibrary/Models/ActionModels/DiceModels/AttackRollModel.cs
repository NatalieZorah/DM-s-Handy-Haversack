using HaversackLibrary.Models.StatusModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.ActionModels.DiceModels
{
    public class AttackRollModel : DiceModel
    {
        // TODO - Documentation
        // TODO - Possible refactoring???
        public int ToHitModifier { get; set; }

        public AttackRollModel(int toHitModifier) : base(DiceType.D20)
        {
            ToHitModifier = toHitModifier;
        }
    }
}
