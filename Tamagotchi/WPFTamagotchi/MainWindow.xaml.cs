using System.Windows;
// Ensure you have the correct using directive for your IFeline and Tiger classes
using Tamagotchi_Library.AnimalManagement;

namespace WPFTamagotchi
{
    public partial class MainWindow : Window
    {
        private IFeline pet;

        public MainWindow()
        {
            InitializeComponent();
            pet = new Tiger("YourPetName"); // Replace with your pet's name
            UpdatePetInfo();
        }

        private void FeedButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Eat();
            UpdatePetInfo();
        }

        private void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Drink();
            UpdatePetInfo();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Play();
            UpdatePetInfo();
        }

        // Implement the rest of the event handlers
        private void HuntButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Hunt();
            UpdatePetInfo();
        }

        private void WashButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Wash();
            UpdatePetInfo();
        }

        private async void HealButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => pet.Heal());
            UpdatePetInfo();
        }


        // Progress method to increment the age of the pet
        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Progress();
            UpdatePetInfo();
        }

        // ... other event handlers ...

        private void UpdatePetInfo()
        {
            // Assuming getFelineInfo() returns a List<string> with the pet's info
            var info = pet.getFelineInfo();
            PetInfo.Content = $"Name: {info[0]}, Age: {info[1]}, Hunger: {info[2]}, Thirst: {info[3]}, Happiness: {info[4]}";
        }
    }
}
