using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.ActionModels.SpellCastingModels
{
    public class SpellArrayModel
    {
        public Dictionary<int, int> SpellSlots { get; set; }
        public Dictionary<SpellLevel, SpellModel> KnownSpells { get; set; }
    }
}