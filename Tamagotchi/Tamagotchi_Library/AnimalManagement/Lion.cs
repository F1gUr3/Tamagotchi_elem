using System;
using System.Threading;
using System.Xml.Linq;
using Tamagotchi_Library.AnimalManagement;


public class Lion : IFeline
{
    public string Name { get; }
    private float age;
    private int hunger;
    private int thirst;
    private int happiness;
    private bool isSick;
    private bool isResting;
    private bool isHunting;

    public const int MaxValue = 100;

    public Lion(string name)
    {
        Name = name;
        age = 0;
        hunger = MaxValue;
        thirst = MaxValue;
        happiness = MaxValue;
        isSick = false;
        isResting = false;
        isHunting = false;
    }

    public List<string> getFelineInfo()
    {
        List<string> felineData = new List<string>
        {
            Name,
            Convert.ToString(age),
            Convert.ToString(hunger),
            Convert.ToString(thirst),
            Convert.ToString(happiness),
            "Lion"

        };

        return felineData;


    }
    public void PassiveProgress(int elapsedHours)
    {
        age = (float)(age + elapsedHours * 0.25);
        hunger = hunger - (int)elapsedHours * 2;
        thirst = thirst - (int)elapsedHours * 4;
        happiness = happiness - (int)elapsedHours * 4;
    }
    public void Progress()
    {
        age = (float)(age + 0.25);
        if (age / 1 == 0)
        {
            Console.WriteLine($"Animal is now {age} years old.");
        }
        else
        {
            Console.WriteLine($"Animal is now {Math.Ceiling(age)} years old.");
        }
        if (age >= 1 && age <= 10 && IsRandomlySick())
        {
            Console.WriteLine("The animal is sick and needs rest.");
            isSick = true;
        }
        else if (age > 10 && age <= 20 && IsRandomlySick())
        {
            Console.WriteLine("The animal is sick and needs rest.");
            isSick = true;
        }



        if (isResting)
        {
            Console.WriteLine("Animal is still resting.");
            Thread.Sleep(10000); // Sleep for 10 seconds
            isResting = false;
        }

        if (isHunting)
        {
            Console.WriteLine("Animal is still hunting.");
            isHunting = false;
        }
    }

    public void Drink()
    {
        if (!isResting)
        {
            thirst = Math.Min(thirst + 5, MaxValue);
            happiness = Math.Min(happiness + 5, MaxValue);
            Console.WriteLine("Animal is drinking.");
            CheckNeeds();
        }
    }


    public void Hunt()
    {
        if (!isResting)
        {
            if (isSick)
            {
                Console.WriteLine("The animal is too sick to hunt.");
                isSick = false;
                Die();
            }
            else
            {
                Console.WriteLine("Animal is hunting.");
                isHunting = true;
                happiness = Math.Min(happiness + 5, MaxValue);
                thirst -= 10;
                hunger -= 15;
                CheckNeeds();
            }
        }
    }

    public void Wash()
    {
        Console.WriteLine("Animal is washing.");
        happiness = Math.Min(happiness + 5, MaxValue);
        CheckNeeds();
    }

    public void Play()
    {
        if (!isResting)
        {
            if (age < 10)
            {
                happiness = Math.Min(happiness + 15, MaxValue);
                thirst -= 5;
                hunger -= 5;
                CheckNeeds();
            }
            else if (age >= 10 && age <= 15)
            {
                Console.WriteLine("The animal is too old to play.");
            }
            else if (age > 15 && age <= 20)
            {
                Console.WriteLine("The animal is too old to play.");
            }
        }
    }

    public async void Heal()
    {
        happiness = Math.Min(happiness + 10, MaxValue);
        isResting = true;
        isSick = false;
        await Task.Delay(1000);
        isResting = false;

    }


    public void Die()
    {
        Console.WriteLine("Animal has died.");
        Environment.Exit(0);
    }

    private void CheckNeeds()
    {
        Console.WriteLine($"Hunger: {hunger}, Thirst: {thirst}, Happiness: {happiness}");
        if (hunger <= 0 || thirst <= 0 || happiness <= 0)
        {
            Console.WriteLine("Animal has died due to neglect.");
            Environment.Exit(0);
        }
        else if (hunger <= 40)
        {
            Console.WriteLine("Animal is hungry. It's time to eat!");
            Eat();
        }
        else if (thirst <= 40)
        {
            Console.WriteLine("Animal is thirsty. It's time to drink!");

        }
    }

    public void Eat()
    {
        happiness = Math.Min(happiness + 5, MaxValue);
        hunger = Math.Min(hunger + 20, MaxValue);
        CheckNeeds();
    }

    private bool IsRandomlySick()
    {

        return new Random().Next(1, 20) == 1;
    }

    void IFeline.Eat()
    {
        Eat();
    }
}

