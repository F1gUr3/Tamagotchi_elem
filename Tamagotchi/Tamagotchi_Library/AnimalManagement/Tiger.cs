using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_Library.AnimalManagement
{
    public class Tiger : IFeline
    {

        public enum FelineState
        {
            Cub,
            Small,
            Grown,
            old,
            dead,
        }
        //GET SET IS TEMP

        private string Name { get; init; }
        private int CountOfScars { get; init; }
        private int Fullness { get; init; }
        private int Thirst { get; init; }
        private bool IsSick { get; init; }
        private int Hygiene { get; init; }
        private int Age { get; init; }
        private int Happiness { get; init; }
        private FelineState State { get; init; }

        public Tiger(string name)
        {
            Name = name;
            Fullness = 100;
            Thirst = 100;
            IsSick = false;
            Hygiene = 100;
            Age = 0;
            Happiness = 100;
            State = FelineState.Cub;
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }

        public void Hunt()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void progress()
        {
            Console.WriteLine(1 + " " + Name);
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }
    }
}
