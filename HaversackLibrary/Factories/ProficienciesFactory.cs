using HaversackLibrary.Models.ItemModels;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Factories
{
    public class ProficienciesFactory
    {
        private Dictionary<string, List<AttributeType>> SaveProficiencies = new Dictionary<string, List<AttributeType>>() {
            { "Artificer", new List<AttributeType>() {AttributeType.Constitution, AttributeType.Intelligence } },
            { "Barbarian", new List<AttributeType>() {AttributeType.Constitution, AttributeType.Strength } },
            { "Bard", new List < AttributeType > () { AttributeType.Dexterity, AttributeType.Charisma } },
            { "Bloodhunter", new List < AttributeType > () { AttributeType.Strength, AttributeType.Intelligence } },
            { "Cleric", new List<AttributeType>() {AttributeType.Wisdom, AttributeType.Charisma } },
            { "Druid", new List < AttributeType > () { AttributeType.Wisdom, AttributeType.Intelligence } },
            { "Fighter", new List < AttributeType > () { AttributeType.Constitution, AttributeType.Strength } },
            { "Monk", new List < AttributeType > () { AttributeType.Strength, AttributeType.Dexterity } },
            { "Paladin", new List < AttributeType > () { AttributeType.Wisdom, AttributeType.Charisma } },
            { "Ranger", new List < AttributeType > () { AttributeType.Wisdom, AttributeType.Dexterity } },
            { "Rogue", new List < AttributeType > () { AttributeType.Dexterity, AttributeType.Intelligence }  },
            { "Sorcerer", new List < AttributeType > () { AttributeType.Constitution, AttributeType.Charisma } },
            { "Warlock", new List < AttributeType > () { AttributeType.Wisdom, AttributeType.Charisma } },
            { "Wizard", new List < AttributeType > () { AttributeType.Wisdom, AttributeType.Intelligence } }
        };

        private Dictionary<string, GearModel> GearModels = new Dictionary<string, GearModel>()
        {
            {"Artisan's Tool", new GearModel("Artisan's Tool of your choice.", GearType.Tool) },
            {"Musical Instrument", new GearModel("Musical Instrument of your choice.", GearType.Tool) },
            {"Weapons", new GearModel("Weapons of a specific kind.", GearType.Weapon) },
            {"Light Armor", new GearModel("Light Armor", GearType.Armor) },
            {"Medium Armor", new GearModel("Medium Armor", GearType.Armor) },
            {"Heavy Armor", new GearModel("Heavy Armor", GearType.Armor) },
            {"Shields", new GearModel("Shields", GearType.Armor) },
            {"Simple Weapons", new GearModel("Simple Weapons", GearType.Weapon) },
            {"Martial Weapons", new GearModel("Martial Weapons", GearType.Weapon) },
            {"Firearms", new GearModel("Firearms", GearType.Weapon) },
            {"Alchemist's Tools", new GearModel("Alchemist's Tools", GearType.Tool)},
            {"Brewer's Tools", new GearModel("Brewer's Tools", GearType.Tool)},
            {"Calligrapher's Tools", new GearModel("Calligrapher's Tools", GearType.Tool)},
            {"Carpenter's Tools", new GearModel("Carpenter's Tools", GearType.Tool)},
            {"Cartographer's Tools", new GearModel("Cartographer's Tools", GearType.Tool)},
            {"Cobbler's Tools", new GearModel("Cobbler's Tools", GearType.Tool)},
            {"Cook's Utensils", new GearModel("Cook's Utensils", GearType.Tool)},
            {"Glassblower's Tools", new GearModel("Glassblower's Tools", GearType.Tool)},
            {"Jeweler's Tools", new GearModel("Jeweler's Tools", GearType.Tool)},
            {"Leatherworker's Tools", new GearModel("Leatherworker's Tools", GearType.Tool)},
            {"Mason's Tools", new GearModel("Mason's Tools", GearType.Tool)},
            {"Painter's Tools", new GearModel("Painter's Tools", GearType.Tool)},
            {"Potter's Tools", new GearModel("Potter's Tools", GearType.Tool)},
            {"Smith's Tools", new GearModel("Smith's Tools", GearType.Tool)},
            {"Tinker's Tools", new GearModel("Tinker's Tools", GearType.Tool)},
            {"Weaver's Tools", new GearModel("Weaver's Tools", GearType.Tool)},
            {"Woodcarver's Tools", new GearModel("Woodcarver's Tools", GearType.Tool)},
            {"Disguise Kit", new GearModel("Disguise Kit", GearType.Tool)},
            {"Forgery Kit", new GearModel("Forgery Kit", GearType.Tool)},
            {"Gaming Set", new GearModel("Gaming Set", GearType.Tool)},
            {"Herbalism Kit", new GearModel("Herbalism Kit", GearType.Tool)},
            {"Vehicles", new GearModel("Vehicles", GearType.Tool)},
            {"Musical Instruments", new GearModel("Musical Instruments", GearType.Tool)},
            {"Navigator's Tools", new GearModel("Navigator's Tools", GearType.Tool)},
            {"Poisoner's Kit", new GearModel("Poisoner's Kit", GearType.Tool)},
            {"Thieve's Tools", new GearModel("Thieve's Tools", GearType.Tool)},
        };

        private Dictionary<string, List<GearModel>> ClassGearProficiencies;

        public ProficienciesFactory()
        {
            ClassGearProficiencies = InitializeClassGearDictionary();
        }
        private Dictionary<string, List<GearModel>> InitializeClassGearDictionary()
        {
            return new Dictionary<string, List<GearModel>>()
            {
                {"Artificer", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Tinker's Tools"),
                        BuildGear("Thieve's Tools"),
                        BuildGear("Artisan's Tool")
                    } },
            { "Barbarian", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Martial Weapons")
                    } },
            { "Bard", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Weapons", "ONLY: hand crossbows, longswords, rapiers, shortswords"),
                        BuildGear("Musical Instrument", "1"),
                        BuildGear("Musical Instrument", "2"),
                        BuildGear("Musical Instrument", "3")
                    } },
            { "Bloodhunter", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Martial Weapons"),
                        BuildGear("Alchemist's Tools")
                    } },
            { "Cleric", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                    } },
            { "Druid", new List<GearModel>()
                    {
                        BuildGear("Light Armor", "ONLY: non-metalic"),
                        BuildGear("Medium Armor", "ONLY: non-metalic"),
                        BuildGear("Shields", "ONLY: non-metalic"),
                        BuildGear("Weapons", "Clubs, daggers, darts, javelins, maces, quarterstaffs, scimitars, sickles, slings, spears"),
                        BuildGear("Herbalism Kit")
                    } },
            { "Fighter", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Heavy Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Martial Weapons"),
                    } },
            { "Monk", new List<GearModel>()
                    {
                        BuildGear("Simple Weapons"),
                        BuildGear("Weapons", "Shortswords"),
                        BuildGear("Artisan's Tool")
                    } },
            { "Paladin", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Heavy Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Martial Weapons"),
                    } },
            { "Ranger", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Medium Armor"),
                        BuildGear("Shields"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Martial Weapons"),
                    } },
            { "Rogue", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Simple Weapons"),
                        BuildGear("Weapons", "ONLY: hand crossbows, longswords, rapiers, shortswords"),
                        BuildGear("Thieve's Tools")
                    } },
            { "Sorcerer", new List<GearModel>()
                    {
                        BuildGear("Weapons", "Daggers, darts, slings, quarterstaffs, light crossbows")
                    } },
            { "Warlock", new List<GearModel>()
                    {
                        BuildGear("Light Armor"),
                        BuildGear("Simple Weapons")
                    } },
            { "Wizard", new List<GearModel>()
                    {
                        BuildGear("Weapons", "Daggers, darts, slings, quarterstaffs, light crossbows")
                    } }
            };
        }


        public GearModel BuildGear(string name, string description = "PLACEHOLDER", bool proficiency = true)
        {
            if (GearModels.TryGetValue(name, out var model))
            {
                return new GearModel(model.Name, model.Type, description, proficiency);
            }

            throw new KeyNotFoundException($"Gear Model {name} not found.");
        }

        public List<GearModel> GetClassGearProficiencies(string name)
        {
            if (ClassGearProficiencies.TryGetValue(name, out var model))
            {
                return model;
            }

            throw new KeyNotFoundException($"Gear list for {name} not found.");
        }

        public List<AttributeType> GetClassSaveProficiencies(string name)
        {
            if (SaveProficiencies.TryGetValue(name, out var model))
            {
                return model;
            }

            throw new KeyNotFoundException($"Save proficiencies for {name} not found.");
        }
    }
}

