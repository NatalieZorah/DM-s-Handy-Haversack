using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.StatusModels;

namespace HaversackLibrary.Models.CharacterModels
{
    public class RaceModel
    {
        /// <summary>
        /// The name for the race.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The main description for the race.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The list of languages given by the race.
        /// </summary>
        /// <seealso cref="LanguageModel"/>
        public List<LanguageModel> Languages { get; set; }
        /// <summary>
        /// The list of features given by this race.
        /// </summary>
        /// <seealso cref="CharacterFeatureModel"/>
        public List<CharacterFeatureModel> Features { get; set; }
        /// <summary>
        /// The list of defenses granted by this race.
        /// </summary>
        /// <seealso cref="DefenseModel"/>
        public List<DefenseModel> Defenses { get; set; }
        /// <summary>
        /// The list of passive senses this race grants.
        /// </summary>
        public List<ICharacterSense> PassiveSenses { get; set; }

        /// <summary>
        /// Constructor for building a new race.
        /// </summary>
        /// <param name="name">String name for the race.</param>
        /// <param name="description">String description of the race.</param>
        /// <param name="languages">List of LanguageModels the race knows.</param>
        /// <param name="features">List of FeatureModels the race has.</param>
        /// <param name="defenses">List of DefenseModels the race grants.</param>
        public RaceModel(string name,
            string description,
            List<LanguageModel> languages,
            List<CharacterFeatureModel> features,
            List<DefenseModel> defenses,
            List<ICharacterSense> passiveSenses)
        {
            Name = name;
            Description = description;
            Languages = languages;
            Features = features;
            Defenses = defenses;
            PassiveSenses = passiveSenses;
        }
    }
}
