using HaversackLibrary.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HaversackLibrary.Enums;
using System.Xml.Linq;
using HaversackLibrary.Models.ItemModels;

namespace HaversackLibrary.Models.CharacterModels
{
    public class ProficienciesModel
    {
        public List<SkillModel> SkillProficiencies { get; set; }

        public List<GearModel> GearProficiencies { get; set; }

        public List<AttributeType> SaveProficiencies { get; set; }

        public ProficienciesModel(List<AttributeModel> attributes, List<ClassModel> classes)
        {
            SkillProficiencies = GenerateSkills(attributes);
            GearProficiencies = GenerateGear(classes);
            SaveProficiencies = GenerateSaves(classes);
        }

        private List<SkillModel> GenerateSkills(List<AttributeModel> attributes)
        {
            SkillFactory skillFactory = new SkillFactory();

            Dictionary<AttributeType, int> attributeModifiers = new Dictionary<AttributeType, int>();
            List<SkillModel> skillProficiencies = new List<SkillModel>();

            foreach (AttributeModel attr in attributes) // Assigns modifier values to appropriate variable
            {
                attributeModifiers[attr.Name] = attr.Modifier;
            }

            foreach (Skills skill in Enum.GetValues(typeof(Skills)))
            {
                skillProficiencies.Add(skillFactory.Skill(skill, attributeModifiers));
            }

            return skillProficiencies;
        }

        private List<GearModel> GenerateGear(List<ClassModel> classes)
        {
            ProficienciesFactory factory = new ProficienciesFactory();

            List<GearModel> gearProficiencies = new List<GearModel>();

            classes.ForEach(cls =>
            {
                gearProficiencies = gearProficiencies.Union(factory.GetClassGearProficiencies(cls.Name)).ToList();
            });

            return gearProficiencies;
        }

        private List<AttributeType> GenerateSaves(List<ClassModel> classes)
        {
            ProficienciesFactory factory = new ProficienciesFactory();

            List<AttributeType> saves = new List<AttributeType>();
            classes.ForEach(cls =>
            {
                if (cls.IsPrimaryClass)
                {
                    saves = factory.GetClassSaveProficiencies(cls.Name);
                }
            });

            return saves;
        }
    }
}
