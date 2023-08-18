using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.StatusModels
{
    public class AttributeModel
    {
        /// <summary>
        /// The specific attribute being referenced.
        /// </summary>
        public AttributeType Name { get; set; }
        /// <summary>
        /// Boolean value for saving throw proficiency with the attribute.
        /// </summary>
        public bool SaveProficiency { get; set; }
        /// <summary>
        /// The attribute score, which is an integer between 3 and 30.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// The attribute modifier, calculated by subtracting 10 from the value and dividing by 2, rounded down.
        /// </summary>
        public int Modifier { get; set; }

        public AttributeModel() { }

        public AttributeModel(AttributeType attribute, int value, bool proficient = false)
        {
            Name = attribute;
            SaveProficiency = proficient;
            Value = value;
            Modifier = CalculateModifier(value);
        }

        private static int CalculateModifier(int value)
        {
            return (value - 10) / 2;
        }

        public void UpdateModifier()
        {
            Modifier = CalculateModifier(Value);
        }

    }
}
