using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi_Library.AnimalManagement;

namespace Tamagotchi_Library.GameManagement
{
    public class GameManager
    {
        private int timePassing {  get; init; }
        private bool hasExit = false;

        public void startGame()
        {
            Console.WriteLine("Hogy hívják a tigrised: ");
            string tamagotchi = Console.ReadLine();
            Tiger tamagotchiPet = new Tiger(tamagotchi);

            while (!hasExit)
            {
                gameProgress(tamagotchiPet);
            }

        }

        public void gameProgress(IFeline animal)
        {
            animal.Progress();
            Thread.Sleep(1000);
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        animal.Drink();
                        break;
                    case 2:
                        animal.Hunt();
                        break;
                    case 3:
                        animal.Play();
                        break;
                    case 4:
                        animal.Wash();
                        break;
                    case 5:
                        animal.Eat();
                        break;
                    case 6:
                        hasExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Doing nothing.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Doing nothing.");
            }
        }
    


    }
}
