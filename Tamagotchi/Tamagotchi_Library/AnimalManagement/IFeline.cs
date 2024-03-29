﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_Library.AnimalManagement
{
    public interface IFeline
    {

        List<String> getFelineInfo();
        void Progress();
        void PassiveProgress(int elapsedDays);
        void Eat();
        void Drink();
        void Hunt();
        void Wash();
        void Play();
        void Heal();
        void Die();
    }


}
