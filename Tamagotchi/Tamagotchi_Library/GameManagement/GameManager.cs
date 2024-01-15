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
            IFeline tamagotchi = saveManager.LoadPrompt();
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
                    tamagotchi = new Panther(nameOfTamagotchi);
                    break;
                case "3":
                    tamagotchi = new Lion(nameOfTamagotchi);
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

            //ASCII SOURCE: https://ascii.co.uk/art/tiger
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("                         __,,,,_");
                        Console.WriteLine("          _ __..-;''`--/'/ /.',-`-.");
                        Console.WriteLine("      (`/' ` |  \\ \\ \\\\ / / / / .-'/`,_");
                        Console.WriteLine("     /'`\\ \\   |  \\ | \\| // // / -.,/_,'-,");
                        Console.WriteLine("    /<7' ;  \\ \\  | ; ||/ /| | \\/    |`-/,/-.,_,/'");
                        Console.WriteLine("   /  _.-, `,-\\,__|  _-| / \\ \\/|_/  |    '-/.;.'\\'");
                        Console.WriteLine("   `-`  ( / ;      / __/ \\__ `/ |__/ |");
                        Console.WriteLine("        `-'      |  -| =|\\_  \\  |-' |");
                        Console.WriteLine("              __/   /_..-' `  ),'  //");
                        Console.WriteLine("             ((__.-'((___..-'' \\__.'");

                        animal.Drink();
                        break;
                    case 2:
                        Console.WriteLine(" _");
                        Console.WriteLine("  ( \\                ..-----..__");
                        Console.WriteLine("   \\.'.        _.--'`  [   '  ' ```'-._");
                        Console.WriteLine("    `. `'-..-'' `    '  ' '   .  ;   ; `-'''-.,__/|/_");
                        Console.WriteLine("      `'-.;..-''`|'  `.  '.    ;     '  `    '   `'  `,");
                        Console.WriteLine("                 \\ '   .    ' .     '   ;   .`   . ' 7 \\");
                        Console.WriteLine("                  '.' . '- . \\    .`   .`  .   .\\     `Y");
                        Console.WriteLine("                    '-.' .   ].  '   ,    '    /'`\"\"';:'");
                        Console.WriteLine("                      /Y   '.] '-._ /    ' _.-'");
                        Console.WriteLine("                      \\'\\_   ; (`'.'.'  .\"/");
                        Console.WriteLine("                       ' )` /  `.'   .-'.");
                        Console.WriteLine("                        '\\  \\).'  .-'--\"");
                        Console.WriteLine("                          `. `,_'`");
                        Console.WriteLine("                            `.__)     ");
                        animal.Hunt();
                        break;
                    case 3:
                        Console.WriteLine("                           _");
                        Console.WriteLine("        __       __       ' `.");
                        Console.WriteLine("      .'  `.  .-'\\`-.  ./   |");
                        Console.WriteLine("      |     \\-'-'_\\`-`_/    |");
                        Console.WriteLine("      |      \\--'-\\-._-.'/  )");
                        Console.WriteLine("      \\  \\ .'.'--'|\\`--._`.-'.");
                        Console.WriteLine("       )`' .''' .'.-L-.`-.\\ '.");
                        Console.WriteLine("      // _'/J '- ///|\\\\\\|-.``.`'.");
                        Console.WriteLine("    .'/'/ .'.-`( | '|` ..-.'( L- L");
                        Console.WriteLine("   // |J J|]`(\"\\\")\\ J  (\".'`J||- |");
                        Console.WriteLine("  / | |) || Y.`.`\\.' -. L'-J|||- -");
                        Console.WriteLine(" /. ' |`.J|J\\  ))J'/\"-. \\\\`'/'/-  \\");
                        Console.WriteLine("J- -  \\  L\\\\`.-' || .' \\ \\\\`'J J  |");
                        Console.WriteLine("|- '_-'. (= `.//.-.__ \" _  L-/.-. |");
                        Console.WriteLine("|-      )_\\\\`|...(\\`-.\".''.)/ -.  )---");
                        Console.WriteLine("|- ''    )  `\\.::::.`.\\|/.:.'`-  ``--._");
                        Console.WriteLine("J-' -'.'  )./ \\::::::'X::::\\` ``` ____");
                        Console.WriteLine(") \\ ' '//  ///''.__-'--`-\\\\ \\ `__");
                        Console.WriteLine("|\\' .'/|/  ' '///  ' \"` \\|\\`` -.`--.");
                        Console.WriteLine("| `.'    /.' )  |(       )``-'  . `.");
                        Console.WriteLine("J   `.'_.' /  /'''.____.'.'.-'| `.  `");
                        Console.WriteLine("(`.   `-.') . \" _.' . .'  '  .'`  `.");
                        Console.WriteLine("|`.\\     \\'  \\  )' |)/    .-' |  .'");
                        Console.WriteLine("/  `.\\    `.\\  /|.'//  .-'    J /");
                        Console.WriteLine("     `.     `\\\" )//   //       L");
                        Console.WriteLine("     _ `     ` . /  .''  _.--''|");
                        Console.WriteLine("    --._      '|`  .'  .'-\"\"-` |");
                        animal.Play();
                        break;
                    case 4:
                        Console.WriteLine("(^\\-==-/^)");
                        Console.WriteLine(" >\\\\ == //<");
                        Console.WriteLine(":== q''p ==:     _");
                        Console.WriteLine(" .__ qp __.    .' )");
                        Console.WriteLine("  / ^--^ \\    /\\.'");
                        Console.WriteLine(" /_`    / )  '\\/");
                        Console.WriteLine("(  )  \\  |-='-/");
                        Console.WriteLine(" \\^^,   |-|--'");
                        Console.WriteLine("( `'    |_| )");
                        Console.WriteLine(" \\-     |-|/");
                        Console.WriteLine("(( )^---( ))   ");
                        animal.Wash();
                        break;
                    case 5:
                        Console.WriteLine("        __       __       ' `.");
                        Console.WriteLine("      .'  `.  .-'\\`-.  ./   |");
                        Console.WriteLine("      |     \\-'-'_\\`-`_/    |");
                        Console.WriteLine("      |      \\--'-\\-._-.'/  )");
                        Console.WriteLine("      \\  \\ .'.'--'|\\`--._`.-'.");
                        Console.WriteLine("       )`' .''' .'.-L-.`-.\\ '.");
                        Console.WriteLine("      // _'/J '- ///|\\\\|-.``.`'.");
                        Console.WriteLine("    .'/'/ .'.-`( | '|` ..-.'( L- L");
                        Console.WriteLine("   // |J J|]`(\"\")\\ J  (\".'`J||- |");
                        Console.WriteLine("  / | |) || Y.`.`\\.' -. L'-J|||- -");
                        Console.WriteLine(" /. ' |`.J|J\\  ))J'/\"-. \\\\`'/'/-  \\");
                        Console.WriteLine("J- -  \\  L\\\\`.-' || .' \\ \\\\`'J J  |");
                        Console.WriteLine("|- '_-'. (= `.//.-.__ \" _  L-/.-. |");
                        Console.WriteLine("|-      )_\\\\`|...(`-.\".''.)/ -.  )---");
                        Console.WriteLine("|- ''    )  `\\.::::.`.|/.:.'`-  ``--._");
                        Console.WriteLine("J-' -'.'  )./ \\::::::'X::::\\` ``` ____");
                        Console.WriteLine(") \\ ' '//  ///''.__-'--`-\\\\ \\ `__");
                        Console.WriteLine("|\\' .'/|/  ' '///  ' \"` \\|\\`` -.`--.");
                        Console.WriteLine("| `.'    /.' )  |(       )``-'  . `.");
                        Console.WriteLine("J   `.'_.' /  /'''.____.'.'.-'| `.  `");
                        Console.WriteLine("(`.   `-.') . \" _.' . .'  '  .'`  `.");
                        Console.WriteLine("|`.\\     \\'  \\  )' |)/    .-' |  .'");
                        Console.WriteLine("/  `.\\    `.\\  /|.'//  .-'    J /");
                        Console.WriteLine("     `.     \\\" )//   //       L");
                        Console.WriteLine("     _ `     ` . /  .''  _.--''|");
                        Console.WriteLine("    --._      '|`  .'  .'-\"\"-` |");
                        animal.Eat();
                        break;
                    case 6:
                        animal.Heal();
                        break;
                    case 7:
                        Console.WriteLine("Save file name: ");

                        string fileName = Console.ReadLine();

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
            Console.WriteLine("Controls: Drink(1) Hunt(2) Play(3) Wash(4) Eat(5) heal(6) Save and exit(7)");

        }



    }
}
