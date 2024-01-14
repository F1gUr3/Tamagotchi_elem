using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tamagotchi_Library.AnimalManagement;

namespace WPFTamagotchi
{
    public partial class MainWindow : Window
    {
        private IFeline pet;

        public MainWindow()
        {
            InitializeComponent();
            ShowPetSelection();
        }
        private string PromptForPetName() { 
            string petName = Microsoft.VisualBasic.Interaction.InputBox("Írja be a nevét a kisállatnak:", "Állatod neve", "DefaultName");
            return petName; 
        }


        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            pet.Play();
            UpdatePetInfo();
        }
        private void UpdatePetImage(string petType)
        {
            string imagePath = petType switch
            {
                "Lion" => "lion.jpg", 
                "Panther" => "panther.jpg",
                "Tiger" => "tiger.jpg",
                _ => null
            };

            if (imagePath != null)
            {
                PetImage.Source = new BitmapImage(new Uri($"./{imagePath}"));
            }
        }
        private void ShowPetControls()
        {
            PetSelectionPanel.Visibility = Visibility.Collapsed;
            PetControlsPanel.Visibility = Visibility.Visible;
            UpdatePetImage(pet.GetType().Name); // Feltételezve, hogy a pet típusa megegyezik a kép fájl nevével
        }

        private void ShowPetSelection()
        {
            PetSelectionPanel.Visibility = Visibility.Visible;
            PetControlsPanel.Visibility = Visibility.Collapsed;
            PetImage.Source = null; // Töröljük a jelenlegi képet
        }

        private void TigerButton_Click(object sender, RoutedEventArgs e)
        {
            string petName = PromptForPetName();
            if (!string.IsNullOrWhiteSpace(petName))
            {
                pet = new Tiger(petName);
                UpdatePetInfo();
                UpdatePetImage("Tiger");
                ShowPetControls();
            }
        }
        private void PantherButton_Click(object sender, RoutedEventArgs e)
        {
            string petName = PromptForPetName();
            if (!string.IsNullOrWhiteSpace(petName))
            {
                pet = new Panther(petName);
                UpdatePetInfo();
                UpdatePetImage("Panther"); 
                ShowPetControls();
            }
        }
        private void LionButton_Click(object sender, RoutedEventArgs e)
        {
            string petName = PromptForPetName();
            if (!string.IsNullOrWhiteSpace(petName))
            {
                pet = new Lion(petName);
                UpdatePetInfo();
                UpdatePetImage("Lion");
                ShowPetControls();
            }
        }

        private void SelectPet(string petType, string petName)
        {
            switch (petType)
            {
                case "Tiger":
                    pet = new Tiger(petName);
                    break;
                case "Panther":
                    pet = new Panther(petName);
                    break;
                case "Lion":
                    pet = new Lion(petName);
                    break;
                default:
                    throw new Exception("Ismeretlen állatfajta");
            }
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

        private void UpdatePetInfo()
        {
            var info = pet.getFelineInfo();
            PetInfo.Content = $"Name: {info[0]}, Age: {info[1]}, Hunger: {info[2]}, Thirst: {info[3]}, Happiness: {info[4]}";
            UpdatePetImage(pet.GetType().Name);
        }


    }
}