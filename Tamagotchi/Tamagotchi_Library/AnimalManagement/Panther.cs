using System;
using System.Threading;
using System.Xml.Linq;
using Tamagotchi_Library.AnimalManagement;


public class Panther : IFeline
{
    public string Name { get; }
    private int age;
    private int hunger;
    private int thirst;
    private int happiness;
    private bool isSick;
    private bool isResting;
    private bool isHunting;

    public Panther(string name)
    {
        Name = name;
        age = 0;
        hunger = 100;
        thirst = 100;
        happiness = 100;
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
            "Panther"

        };

        return felineData;


    }

    public void Progress()
    {
        age++;
        Console.WriteLine($"Animal is now {age} years old.");
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
<<<<<<< HEAD
            Console.WriteLine("Animal is still hunting.");
            Thread.Sleep(1000); // Sleep for 5 seconds
            isHunting = false;
=======
            throw new NotImplementedException();
        }

        public List<string> getFelineInfo()
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

        public void PassiveProgress(int elapsedDays)
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Progress()
        {
            throw new NotImplementedException();
        }

        public void Wash()
        {
            throw new NotImplementedException();
>>>>>>> 0ceebd9679f1929bba4aa954d65c2b973a9961fe
        }
    }

    public void Drink()
    {
        if (!isResting)
        {
            thirst -= 5;
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
                happiness += 10;
                thirst -= 10;
                hunger -= 15;
                CheckNeeds();
            }
        }
    }

    public void Wash()
    {
        Console.WriteLine("Animal is washing.");
        happiness += 5;
        Thread.Sleep(5000); // Sleep for 5 seconds
        CheckNeeds();
    }

    public void Play()
    {
        if (!isResting)
        {
            if (age < 10)
            {
                Console.WriteLine("Animal is playing.");
                happiness += 15;
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

    public void Heal()
    {
        Console.WriteLine("Animal is resting and healing.");
        happiness += 10;
        isResting = true;
        isSick = false;
        Thread.Sleep(10000); // Sleep for 10 seconds
        CheckNeeds();
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

    private void Eat()
    {
        Console.WriteLine("Animal is eating.");
        hunger += 20;
        CheckNeeds();
    }

    private bool IsRandomlySick()
    {

        return new Random().Next(1, 6) == 1;
    }

    void IFeline.Eat()
    {
        Console.WriteLine("Animal is eating.");
        hunger += 20;
        CheckNeeds();
    }
}

