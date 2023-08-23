using HaversackLibrary.Factories;
using static HaversackLibrary.Enums;
using HaversackLibrary.Models.ItemModels;
using HaversackLibrary.Models.CharacterModels;
using HaversackLibrary.Interfaces;

namespace HaversackLibrary.Models.StatusModels
{
    public class ProficienciesModel
    {
        // TODO - Documentation
        public List<SkillModel> SkillProficiencies { get; set; }

        public List<GearModel> GearProficiencies { get; set; }

        public ProficienciesModel(AttributeArrayModel attributes, List<IActorClassModel> classes)
        {
            SkillProficiencies = GenerateSkills(attributes);
            GearProficiencies = GenerateGear(classes);
        }

        private List<SkillModel> GenerateSkills(AttributeArrayModel attributes)
        {
            SkillFactory skillFactory = new SkillFactory();

            List<SkillModel> skillProficiencies = new List<SkillModel>();

            foreach (Skills skill in Enum.GetValues(typeof(Skills)))
            {
                skillProficiencies.Add(skillFactory.Skill(skill, attributes));
            }

            return skillProficiencies;
        }

        private SkillModel? GetSkillByName(Skills skill)
        {
            return SkillProficiencies.FirstOrDefault(skillModel => skillModel.Skill == skill);
        }

        public void SetSkillProficiency(Skills skill, ProficiencyType type)
        {
            var selectedSkill = GetSkillByName(skill);

            if (selectedSkill != null)
            {
                selectedSkill.Proficiency = type;
            }
        }

        private List<GearModel> GenerateGear(List<IActorClassModel> classes)
        {
            ProficienciesFactory factory = new ProficienciesFactory();

            List<GearModel> gearProficiencies = new List<GearModel>();

            classes.ForEach(cls =>
            {
                if (cls is ClassModel)
                {
                    gearProficiencies = gearProficiencies.Union(factory.GetClassGearProficiencies(cls.Name)).ToList();
                }
            });

            return gearProficiencies;
        }

        public void AddGearProficiency(string name, string description)
        {
            GearProficiencies.Add(new ProficienciesFactory().BuildGear(name, description));
        }
    }
}
