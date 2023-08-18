namespace HaversackLibrary.Models.CharacterModels
{
    public class CharacterFeatureModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CharacterFeatureModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
