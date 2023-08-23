namespace HaversackLibrary.Models.StatusModels
{
    public class LanguageModel
    {
        /// <summary>
        /// The name of the language.
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// The source of that language's knowledge.
        /// </summary>
        /// <example>Race, Background</example>
        public string Source { get; set; }
        /// <summary>
        /// The constructor for any languages the character knows.
        /// </summary>
        /// <param name="language">The name of the language.</param>
        /// <param name="source">Where the character knows the language from.</param>
        public LanguageModel(string language, string source)
        {
            Language = language;
            Source = source;
        }
    }
}
