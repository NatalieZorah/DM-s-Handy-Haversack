namespace HaversackLibrary.Models.CharacterModels
{
    public class RaceModel
    {
        string Name { get; set; }
        public string Description { get; set; }
        public List<LanguageModel> Languages { get; set; }
        public List<CharacterFeatureModel> Features { get; set; }

        public RaceModel(string name,
            string description,
            List<LanguageModel> languages,
            List<CharacterFeatureModel> features)
        {
            Name = name;
            Description = description;
            Languages = languages;
            Features = features;
        }
    }
}
