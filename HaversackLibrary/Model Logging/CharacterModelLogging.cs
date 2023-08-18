using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaversackLogic;
using Newtonsoft.Json;
using HaversackLibrary.Models.CharacterModels;
using HaversackLibrary.Factories;
using static HaversackLibrary.Enums;
using HaversackLibrary.Wrappers;
using HaversackLibrary.Interfaces;
using HaversackLibrary.Models.StatusModels;

namespace HaversackLibrary.Model_Logging
{
    public class CharacterModelLogging
    {
        public static void BuildTestClasses()
        {
            CharacterClassFactory classBuilder = new CharacterClassFactory();

            List<string> dndClasses = new List<string>
            {
                "Artificer",
                "Barbarian",
                "Bard",
                "Bloodhunter",
                "Cleric",
                "Druid",
                "Fighter",
                "Monk",
                "Paladin",
                "Ranger",
                "Rogue",
                "Sorcerer",
                "Warlock",
                "Wizard"
            };

            Logging.TestMessage("Building Test Classes..");

            dndClasses.ForEach(c =>
            {
                Logging.TestMessage($"{c}: ");
                Logging.TestMessage(JsonConvert.SerializeObject(classBuilder.CharacterClass(c)));
                Logging.TestMessage(JsonConvert.SerializeObject(classBuilder.CharacterClass(c, 1, "TEST SUBCLASS", true)));
                Logging.TestMessage(JsonConvert.SerializeObject(classBuilder.CharacterClass(c, 2, "TEST SUBCLASS")));
                Logging.TestMessage(JsonConvert.SerializeObject(classBuilder.CharacterClass(c, 4, "TEST SUBCLASS", true)));
                Console.WriteLine();
            });
        }

        public static void BuildTestCharacter()
        {
            CharacterClassFactory classBuilder = new CharacterClassFactory();

            string name = "Zethrie";
            string playerName = "NatalieZorah";
            int armorClass = 18;

            RaceModel race = new RaceModel(
                "Succubus",
                "TESTING ONLY",
                new List<LanguageModel>()
                {
                    new LanguageModel("Elvish", "Succubus"),
                    new LanguageModel("Abyssal", "Succubus"),
                    new LanguageModel("Infernal", "Succubus")
                },
                new List<CharacterFeatureModel>()
                {
                    new CharacterFeatureModel("TEST NAME 1", "TEST FEATURE 1"),
                    new CharacterFeatureModel("TEST NAME 2", "TEST FEATURE 2"),
                    new CharacterFeatureModel("TEST NAME 3", "TEST FEATURE 3"),
                },
                new List<DefenseModel>()
                {
                    new DefenseModel(new DamageTypeWrapper(DamageType.Radiant), "Succubus", ResistanceType.Vulnerability),
                    new DefenseModel(new ConditionWrapper(Condition.Charmed), "Succubus", ResistanceType.Immunity)
                },
                new List<ICharacterSense>()
                {
                    new PassiveSenseModel("Darkvision", 120)
                });

            List<ClassModel> classes = new List<ClassModel>() {
                classBuilder.CharacterClass("Sorcerer", 12, "Psion Soul", true),
                classBuilder.CharacterClass("Paladin")
            };

            AttributeArrayModel attributes = new AttributeArrayModel(10, 18, 16, 13, 14, 20);

            List<MovementModel> movements = new List<MovementModel>()
            {
                new MovementModel(MovementType.Walking, 30),
                new MovementModel(MovementType.Flying, 40)
            };

            CharacterModel character1 = new CharacterModel(name, playerName, armorClass, race, classes, attributes, movements, true);

            Logging.TestMessage(JsonConvert.SerializeObject(character1));
        }
    }
}
