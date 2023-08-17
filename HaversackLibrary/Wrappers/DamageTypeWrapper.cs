using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaversackLibrary.Interfaces;
using static HaversackLibrary.Enums;

namespace HaversackLibrary.Wrappers
{
    public class DamageTypeWrapper : IDefenseType
    {
        public DamageType DamageType { get; set; }
    }
}
