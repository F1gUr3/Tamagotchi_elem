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
        private bool hasExit = false;
        private SaveManager? saveManager;


        public void startGame()
        {
            Console.WriteLine("Welcome to the tamagotchi simulator: Start new Game (1) or load game (2)");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                newGame();
            }
            else if (userInput == 2)
            {
                loadGame();
            }
            else
            {
                Console.WriteLine("Incorrect input!");
                startGame();
            }
        }
        public void newGame()
        {
            Console.WriteLine("How is your pet called? ");
            string nameOfTamagotchi = Console.ReadLine();

            IFeline tamagotchi = choosePet(nameOfTamagotchi);
            saveManager = new SaveManager(tamagotchi);
            while (!hasExit)
            {
                gameProgress(tamagotchi);
            }

            
        }

        public void loadGame()
        {
            saveManager = new SaveManager();
            IFeline tamagotchi = saveManager.loadPrompt();
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
        public void gameProgress(IFeline animal)
        {
            animal.Progress();
            Console.WriteLine("Controls: Drink(1) Hunt(2) Play(3) Wash(4) Eat(5) Save and exit(6)");
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
                        Console.WriteLine("Save file name: ");

                        string fileName = Console.ReadLine() + ".json";

                        saveManager.savePrompt(fileName);
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
