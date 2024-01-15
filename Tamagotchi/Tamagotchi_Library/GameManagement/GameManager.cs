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
            Console.ForegroundColor = ConsoleColor.Magenta;
            ConsoleHandler.PrintCentered("Welcome to the feline pet simulator \n");

            Console.ForegroundColor = ConsoleColor.Green;

            ConsoleHandler.PrintCentered(": Start new Game (1) \n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            ConsoleHandler.PrintCentered(": Load Game (2)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;

            ConsoleHandler.PrintCentered(",\\/~~~\\_                            _/~~~~\\");
            ConsoleHandler.PrintCentered("|  ---, `\\_    ___,-------~~\\__  /~' ,,''  |");
            ConsoleHandler.PrintCentered("| `~`, ',,\\`-~~--_____    ---  - /, ,--/ '/'");
            ConsoleHandler.PrintCentered("`\\_|\\ _\\`    ______,---~~~\\  ,_   '\\_/' /'");
            ConsoleHandler.PrintCentered("  \\,_|   , '~,'~/~   /~\\ ,_  `\\_ \\_  \\_\\'");
            ConsoleHandler.PrintCentered("    ,/   /' ,/' _,-'~~  `\\  ~~\\_ ,_  `\\  `\\");
            ConsoleHandler.PrintCentered("  /@@ _/  /' ./',-                 \\       `@,");
            ConsoleHandler.PrintCentered(" @@ '   |  ___/  /'  /  \\  \\ '__ _`~|, `, @@");
            ConsoleHandler.PrintCentered("/@@ /  | | ',___  |  |    `  | ,,---,  |  | `@@,");
            ConsoleHandler.PrintCentered("@@@ \\  | | \\ \\O_\\ |        / / O_/' | \\  \\  @@@");
            ConsoleHandler.PrintCentered("@@@ |  | `| '   ~ / ,          ~     /  |    @@@");
            ConsoleHandler.PrintCentered("`@@ |   \\ `\\     ` |         | |  _/'  /'  | @@'");
            ConsoleHandler.PrintCentered(" @@ |    ~\\ /--'~  |       , |  \\__   |    | |@@");
            ConsoleHandler.PrintCentered(" @@, \\     | ,,|   |       ,,|   | `\\     /',@@");
            ConsoleHandler.PrintCentered("`@@, ~\\   \\ '     ` |       / /    `' '   / ,@@");
            ConsoleHandler.PrintCentered(" @@@,    \\    ~~\\ `\\/~---'~/' _ /'~~~~~~~~--,");
            ConsoleHandler.PrintCentered("  `@@@_,---::::::=  `-_,| ,~  _=:::::''''    `");
            ConsoleHandler.PrintCentered("  ,/~~_---'_,-___     _-__  ' -~~~\\_```---");
            ConsoleHandler.PrintCentered("    ~`   ~~_/'// _,--~\\_/ '~--, |\\_");
            ConsoleHandler.PrintCentered("         /' /'| `@@@@@,,,,,@@@@  | \\   -Chevalier-");
            ConsoleHandler.PrintCentered("              `     `@@@@@@'");

            Console.ForegroundColor = ConsoleColor.White;
        int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                Console.Clear();
                newGame();
            }
            else if (userInput == 2)
            {
                Console.Clear();
                loadGame();
            }
            else
            {
                Console.Clear();
                ConsoleHandler.PrintCentered("Incorrect input!");
                startGame();
            }

            Console.Clear();
        }
        public void newGame()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("what is your pet's name? ");
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
            saveManager = new SaveManager(tamagotchi);
            while (!hasExit)
            {
                gameProgress(tamagotchi);
            }
        }

        public IFeline choosePet(string nameOfTamagotchi, string petOfChoice = null)
        {
            if(petOfChoice == null)
            {
                ConsoleHandler.PrintCentered("Choose the type of pet: (1) Tiger, (2), Panther, (3) Lion");
                petOfChoice = Console.ReadLine();
            }
            
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
                    ConsoleHandler.PrintCentered("Bad input! Try a number between 1-3!");
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        ConsoleHandler.PrintCentered("                         __,,,,_");
                        ConsoleHandler.PrintCentered("          _ __..-;''`--/'/ /.',-`-.");
                        ConsoleHandler.PrintCentered("      (`/' ` |  \\ \\ \\\\ / / / / .-'/`,_");
                        ConsoleHandler.PrintCentered("     /'`\\ \\   |  \\ | \\| // // / -.,/_,'-,");
                        ConsoleHandler.PrintCentered("    /<7' ;  \\ \\  | ; ||/ /| | \\/    |`-/,/-.,_,/'");
                        ConsoleHandler.PrintCentered("   /  _.-, `,-\\,__|  _-| / \\ \\/|_/  |    '-/.;.'\\'");
                        ConsoleHandler.PrintCentered("   `-`  ( / ;      / __/ \\__ `/ |__/ |");
                        ConsoleHandler.PrintCentered("        `-'      |  -| =|\\_  \\  |-' |");
                        ConsoleHandler.PrintCentered("              __/   /_..-' `  ),'  //");
                        ConsoleHandler.PrintCentered("             ((__.-'((___..-'' \\__.'");
                        Console.ForegroundColor = ConsoleColor.White;

                        animal.Drink();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        ConsoleHandler.PrintCentered(" _");
                        ConsoleHandler.PrintCentered("  ( \\                ..-----..__");
                        ConsoleHandler.PrintCentered("   \\.'.        _.--'`  [   '  ' ```'-._");
                        ConsoleHandler.PrintCentered("    `. `'-..-'' `    '  ' '   .  ;   ; `-'''-.,__/|/_");
                        ConsoleHandler.PrintCentered("      `'-.;..-''`|'  `.  '.    ;     '  `    '   `'  `,");
                        ConsoleHandler.PrintCentered("                 \\ '   .    ' .     '   ;   .`   . ' 7 \\");
                        ConsoleHandler.PrintCentered("                  '.' . '- . \\    .`   .`  .   .\\     `Y");
                        ConsoleHandler.PrintCentered("                    '-.' .   ].  '   ,    '    /'`\"\"';:'");
                        ConsoleHandler.PrintCentered("                      /Y   '.] '-._ /    ' _.-'");
                        ConsoleHandler.PrintCentered("                      \\'\\_   ; (`'.'.'  .\"/");
                        ConsoleHandler.PrintCentered("                       ' )` /  `.'   .-'.");
                        ConsoleHandler.PrintCentered("                        '\\  \\).'  .-'--\"");
                        ConsoleHandler.PrintCentered("                          `. `,_'`");
                        ConsoleHandler.PrintCentered("                            `.__)");
                        Console.ForegroundColor = ConsoleColor.White;

                        animal.Hunt();
                        break;
                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        ConsoleHandler.PrintCentered("                           _");
                        ConsoleHandler.PrintCentered("        __       __       ' `.");
                        ConsoleHandler.PrintCentered("      .'  `.  .-'\\`-.  ./   |");
                        ConsoleHandler.PrintCentered("      |     \\-'-'_\\`-`_/    |");
                        ConsoleHandler.PrintCentered("      |      \\--'-\\-._-.'/  )");
                        ConsoleHandler.PrintCentered("      \\  \\ .'.'--'|\\`--._`.-'.");
                        ConsoleHandler.PrintCentered("       )`' .''' .'.-L-.`-.\\ '.");
                        ConsoleHandler.PrintCentered("      // _'/J '- ///|\\\\\\|-.``.`'.");
                        ConsoleHandler.PrintCentered("    .'/'/ .'.-`( | '|` ..-.'( L- L");
                        ConsoleHandler.PrintCentered("   // |J J|]`(\"\\\")\\ J  (\".'`J||- |");
                        ConsoleHandler.PrintCentered("  / | |) || Y.`.`\\.' -. L'-J|||- -");
                        ConsoleHandler.PrintCentered(" /. ' |`.J|J\\  ))J'/\"-. \\\\`'/'/-  \\");
                        ConsoleHandler.PrintCentered("J- -  \\  L\\\\`.-' || .' \\ \\\\`'J J  |");
                        ConsoleHandler.PrintCentered("|- '_-'. (= `.//.-.__ \" _  L-/.-. |");
                        ConsoleHandler.PrintCentered("|-      )_\\\\`|...(\\`-.\".''.)/ -.  )---");
                        ConsoleHandler.PrintCentered("|- ''    )  `\\.::::.`.\\|/.:.'`-  ``--._");
                        ConsoleHandler.PrintCentered("J-' -'.'  )./ \\::::::'X::::\\` ``` ____");
                        ConsoleHandler.PrintCentered(") \\ ' '//  ///''.__-'--`-\\\\ \\ `__");
                        ConsoleHandler.PrintCentered("|\\' .'/|/  ' '///  ' \"` \\|\\`` -.`--.");
                        ConsoleHandler.PrintCentered("| `.'    /.' )  |(       )``-'  . `.");
                        ConsoleHandler.PrintCentered("J   `.'_.' /  /'''.____.'.'.-'| `.  `");
                        ConsoleHandler.PrintCentered("(`.   `-.') . \" _.' . .'  '  .'`  `.");
                        ConsoleHandler.PrintCentered("|`.\\     \\'  \\  )' |)/    .-' |  .'");
                        ConsoleHandler.PrintCentered("/  `.\\    `.\\  /|.'//  .-'    J /");
                        ConsoleHandler.PrintCentered("     `.     \\\" )//   //       L");
                        ConsoleHandler.PrintCentered("     _ `     ` . /  .''  _.--''|");
                        ConsoleHandler.PrintCentered("    --._      '|`  .'  .'-\"\"-` |");
                        animal.Play();
                        Console.ForegroundColor = ConsoleColor.White;

                        break;

                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        ConsoleHandler.PrintCentered("(^\\-==-/^)");
                        ConsoleHandler.PrintCentered(" >\\\\ == //<");
                        ConsoleHandler.PrintCentered(":== q''p ==:     _");
                        ConsoleHandler.PrintCentered(" .__ qp __.    .' )");
                        ConsoleHandler.PrintCentered("  / ^--^ \\    /\\.'");
                        ConsoleHandler.PrintCentered(" /_`    / )  '\\/'");
                        ConsoleHandler.PrintCentered("(  )  \\  |-='-/");
                        ConsoleHandler.PrintCentered(" \\^^,   |-|--'");
                        ConsoleHandler.PrintCentered("( `'    |_| )");
                        ConsoleHandler.PrintCentered(" \\-     |-|/");
                        ConsoleHandler.PrintCentered("(( )^---( ))   ");
                        animal.Wash();
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    case 5:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        ConsoleHandler.PrintCentered("        __       __       ' `.");
                        ConsoleHandler.PrintCentered("      .'  `.  .-'\\`-.  ./   |");
                        ConsoleHandler.PrintCentered("      |     \\-'-'_\\`-`_/    |");
                        ConsoleHandler.PrintCentered("      |      \\--'-\\-._-.'/  )");
                        ConsoleHandler.PrintCentered("      \\  \\ .'.'--'|\\`--._`.-'.");
                        ConsoleHandler.PrintCentered("       )`' .''' .'.-L-.`-.\\ '.");
                        ConsoleHandler.PrintCentered("      // _'/J '- ///|\\\\|-.``.`'.");
                        ConsoleHandler.PrintCentered("    .'/'/ .'.-`( | '|` ..-.'( L- L");
                        ConsoleHandler.PrintCentered("   // |J J|]`(\"\")\\ J  (\".'`J||- |");
                        ConsoleHandler.PrintCentered("  / | |) || Y.`.`\\.' -. L'-J|||- -");
                        ConsoleHandler.PrintCentered(" /. ' |`.J|J\\  ))J'/\"-. \\\\`'/'/-  \\");
                        ConsoleHandler.PrintCentered("J- -  \\  L\\\\`.-' || .' \\ \\\\`'J J  |");
                        ConsoleHandler.PrintCentered("|- '_-'. (= `.//.-.__ \" _  L-/.-. |");
                        ConsoleHandler.PrintCentered("|-      )_\\\\`|...(`-.\".''.)/ -.  )---");
                        ConsoleHandler.PrintCentered("|- ''    )  `\\.::::.`.|/.:.'`-  ``--._");
                        ConsoleHandler.PrintCentered("J-' -'.'  )./ \\::::::'X::::\\` ``` ____");
                        ConsoleHandler.PrintCentered(") \\ ' '//  ///''.__-'--`-\\\\ \\ `__");
                        ConsoleHandler.PrintCentered("|\\' .'/|/  ' '///  ' \"` \\|\\`` -.`--.");
                        ConsoleHandler.PrintCentered("| `.'    /.' )  |(       )``-'  . `.");
                        ConsoleHandler.PrintCentered("J   `.'_.' /  /'''.____.'.'.-'| `.  `");
                        ConsoleHandler.PrintCentered("(`.   `-.') . \" _.' . .'  '  .'`  `.");
                        ConsoleHandler.PrintCentered("|`.\\     \\'  \\  )' |)/    .-' |  .'");
                        ConsoleHandler.PrintCentered("/  `.\\    `.\\  /|.'//  .-'    J /");
                        ConsoleHandler.PrintCentered("     `.     \\\" )//   //       L");
                        ConsoleHandler.PrintCentered("     _ `     ` . /  .''  _.--''|");
                        ConsoleHandler.PrintCentered("    --._      '|`  .'  .'-\"\"-` |");
                        Console.ForegroundColor = ConsoleColor.White;

                        animal.Eat();

                        break;
                    case 6:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        ConsoleHandler.PrintCentered("             .-.       .-.");
                        ConsoleHandler.PrintCentered("            (   \\_.-._/   )");
                        ConsoleHandler.PrintCentered("             \\           /");
                        ConsoleHandler.PrintCentered("             | __     __ |");
                        ConsoleHandler.PrintCentered("             | \\O\\   /O/ |");
                        ConsoleHandler.PrintCentered("              \\  \"   \"  /");
                        ConsoleHandler.PrintCentered("              /\\_`-v-'_/\\");
                        ConsoleHandler.PrintCentered("             /  \\._|_./  \\");
                        ConsoleHandler.PrintCentered("            |    \\___/    |");
                        ConsoleHandler.PrintCentered("            |             |");
                        ConsoleHandler.PrintCentered("            |             |");
                        ConsoleHandler.PrintCentered("            |   |     |   |");
                        ConsoleHandler.PrintCentered("  .ww.     _|   |     |   |_");
                        ConsoleHandler.PrintCentered(".\\WWW=    / |   |     |   | \\");
                        ConsoleHandler.PrintCentered("\\WWW=    |  |   |     |   |  |");
                        ConsoleHandler.PrintCentered("\\WW=     |  |   |     |   |  |");
                        ConsoleHandler.PrintCentered("( (      |  |   \\     /   |  |");
                        ConsoleHandler.PrintCentered(" \\ \\___.-'\\  \\   \\   /   /  /");
                        ConsoleHandler.PrintCentered("  `-.__.-(...(...)---(...)...)");
                        Console.ForegroundColor = ConsoleColor.White;

                        animal.Heal();

                        break;
                    case 7:
                        Console.Clear();

                        ConsoleHandler.PrintCentered("Save file name: ");

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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                ConsoleHandler.PrintCentered("             .-.       .-.");
                ConsoleHandler.PrintCentered("            (   \\_.-._/   )");
                ConsoleHandler.PrintCentered("             \\           /");
                ConsoleHandler.PrintCentered("             | __     __ |");
                ConsoleHandler.PrintCentered("             | \\O\\   /O/ |");
                ConsoleHandler.PrintCentered("              \\  \"   \"  /");
                ConsoleHandler.PrintCentered("              /\\_`-v-'_/\\");
                ConsoleHandler.PrintCentered("             /  \\._|_./  \\");
                ConsoleHandler.PrintCentered("            |    \\___/    |");
                ConsoleHandler.PrintCentered("            |             |");
                ConsoleHandler.PrintCentered("            |             |");
                ConsoleHandler.PrintCentered("            |   |     |   |");
                ConsoleHandler.PrintCentered("  .ww.     _|   |     |   |_");
                ConsoleHandler.PrintCentered(".\\WWW=    / |   |     |   | \\");
                ConsoleHandler.PrintCentered("\\WWW=    |  |   |     |   |  |");
                ConsoleHandler.PrintCentered("\\WW=     |  |   |     |   |  |");
                ConsoleHandler.PrintCentered("( (      |  |   \\     /   |  |");
                ConsoleHandler.PrintCentered(" \\ \\___.-'\\  \\   \\   /   /  /");
                ConsoleHandler.PrintCentered("  `-.__.-(...(...)---(...)...)");
                Console.ForegroundColor = ConsoleColor.White;

                ConsoleHandler.PrintCentered("Invalid input. Doing nothing.");
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            ConsoleHandler.PrintCentered("Controls: Drink(1) Hunt(2) Play(3) Wash(4) Eat(5) heal(6) Save and exit(7)");
            Console.ForegroundColor = ConsoleColor.White;

        }



    }
}
