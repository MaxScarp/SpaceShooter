﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class Controller
    {
        protected int index;

        public Controller(int controllerIndex)
        {
            index = controllerIndex;
        }

        public abstract bool IsFirePressed();
        public abstract float GetHorizonatl();
        public abstract float GetVertical();
    }
}
