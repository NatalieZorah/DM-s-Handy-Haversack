using HaversackLibrary.Models.StatusModels;

namespace HaversackLibrary.Models.CharacterModels
{
    public class CharacterRaceModel
    {
        public string Name { get; set; }

        public List<CharacterFeatureModel> Features { get; set; }

        public List<LanguageModel> Languages { get; set; }

        public CharacterRaceModel(string name, List<CharacterFeatureModel> racialFeatures, List<LanguageModel> languages)
        {
            Name = name;
            Features = racialFeatures;
            Languages = languages;
        }
    }
}
