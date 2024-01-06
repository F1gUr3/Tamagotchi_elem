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
        private SaveManager? currentSave;

        public void startGame()
        {
            Console.WriteLine("How is your pet called? ");
            string nameOfTamagotchi = Console.ReadLine();

            IFeline tamagotchi = choosePet(nameOfTamagotchi);
            currentSave = new SaveManager(tamagotchi);
            while (!hasExit)
            {
                gameProgress(tamagotchi);
            }

            
        }

        public void loadGame(string saveFilePath)
        {
            IFeline tamagotchi = SaveManager.loadFromJson(saveFilePath);
            while (!hasExit)
            {
                gameProgress(tamagotchi);
            }
        }

        public IFeline choosePet(string nameOfTamagotchi)
        {
            Console.WriteLine("Choose the type of pet: (1) Tiger, (2), Panther, (3) Lion");
            string petOfChoice = Console.ReadLine();
            IFeline tamagotchi = null;

            switch (petOfChoice)
            {
                case "1":
                    tamagotchi = new Tiger(nameOfTamagotchi);
                    break;
                case "2":
                    tamagotchi = new Tiger(nameOfTamagotchi);
                    break;
                case "3":
                    tamagotchi = new Tiger(nameOfTamagotchi);
                    break;
                default:
                    Console.WriteLine("Bad input! Try a number between 1-3!");
                    choosePet(nameOfTamagotchi);
                    break;


            }

            return tamagotchi;
        }
        //valami cooment mert a github szarakszik
        public void gameProgress(IFeline animal)
        {
            animal.Progress();
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
