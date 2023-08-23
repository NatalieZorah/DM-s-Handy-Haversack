﻿using static HaversackLibrary.Enums;

namespace HaversackLibrary.Models.StatusModels
{
    public class MovementModel
    {
        // TODO - Documentation
        public MovementType Type { get; set; }

        public int Speed { get; set; }

        public MovementModel(MovementType type, int speed)
        {
            Type = type;
            Speed = speed;
        }
    }
}
