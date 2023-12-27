
using Tamagotchi_Library.AnimalManagement;
using Tamagotchi_Library.GameManagement;

GameManager Tamagotchi = new GameManager();

Tamagotchi.startGame();

Console.WriteLine("Virtual pet simulation started!");
string name = Console.ReadLine();
IFeline pet = new Tiger(name);

while (true)
{
    pet.Progress();
    pet.Drink();
    pet.Hunt();
    pet.Wash();
    pet.Play();
    pet.Heal();
    pet.Eat();

    Thread.Sleep(3000);
}
