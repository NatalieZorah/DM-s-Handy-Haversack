using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaversackLogic;
using Newtonsoft.Json;
using HaversackLibrary.Models.CharacterModels;
using HaversackLibrary.Factories;

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
    }
}
