using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using Tamagotchi_Library.AnimalManagement;

namespace Tamagotchi_Library.GameManagement
{
    public class SaveManager
    {

        private List<string> felineData = new List<string>();
        public string name { get; init; }
        public float age { get; set; }
        public int hunger { get; set; }
        public int thirst { get; set; }
        public int happiness { get; set; }
        public string type { get; init; }
        public DateTime lastLogOn { get; set; }

        private IFeline feline;

        public SaveManager()
        {

        }

        [JsonConstructor]
        public SaveManager(IFeline toSave)
        {
 
           felineData = toSave.getFelineInfo();
           name = felineData[0];
           age = float.Parse(felineData[1]);
           hunger = int.Parse(felineData[2]);
           thirst = int.Parse(felineData[3]);
           happiness = int.Parse(felineData[4]);
           type = felineData[5];
            feline = toSave;


        }

        public int TimePassUpdate()
        {
            TimeSpan elapsedTime = (DateTime.Now - lastLogOn);
            int elapsedHours = (int)elapsedTime.Hours;
            Console.WriteLine(elapsedHours);
            return elapsedHours;
            
        }
        public void updateData(IFeline toSave)
        {
            felineData = toSave.getFelineInfo();
            age = float.Parse(felineData[1]);
            hunger = int.Parse(felineData[2]);
            thirst = int.Parse(felineData[3]);
            happiness = int.Parse(felineData[4]);
            lastLogOn = DateTime.Now;
        }

        public void savePrompt(string filepPath)
        {
            if (File.Exists(filepPath))
            {
                ConsoleHandler.PrintCentered($"File '{filepPath}' already exists in the current directory.");
                Console.Write("Do you want to overwrite it? (Y/N): ");

                char response = Char.ToUpper(Console.ReadKey().KeyChar);

                if (response == 'Y')
                {
                    saveToJson(filepPath);
                }
                else if(response == 'N')
                {
                    ConsoleHandler.PrintCentered("\nFile creation aborted.");
                    ConsoleHandler.PrintCentered("Try again save file name: ");
                    string fileName = Console.ReadLine() + ".json";
                    savePrompt(fileName);


                }
                
            }
            else
            {
                saveToJson(filepPath);
            }
        }

        public void saveToJson(string filePath)
        {
            updateData(feline); 

            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
           
            File.WriteAllText(filePath + ".json", json);
        }

        public IFeline LoadPrompt()
        {
            string[] jsonFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json");
            if (jsonFiles.Length > 0)
            {
                ConsoleHandler.PrintCentered("Save files: ");
                foreach (string jsonFile in jsonFiles)
                {
                    if (!jsonFile.EndsWith("Tamagotchi_Console.deps.json") &&
                        !jsonFile.EndsWith("Tamagotchi_Console.runtimeconfig.json"))
                    {
                        string filename = Path.GetFileName(jsonFile);
                        ConsoleHandler.PrintCentered(filename);
                    }
                }
            }
            else
            {
                ConsoleHandler.PrintCentered("No save files found.");
            }

            string chosenSave = Console.ReadLine();

            return loadFromJson(chosenSave);
        }
        public IFeline loadFromJson(string filePath)
        {
            IFeline loadedPet = null;
            try
            {
                string json = File.ReadAllText(filePath);
                int startIndex = json.IndexOf("\"type\": \"") + ("\"type\": \"").Length;
                int endIndex = json.IndexOf("\"", startIndex + 1);
                string type = json.Substring(startIndex, endIndex - startIndex);

                switch (type)
                {
                    case "Tiger":
                        loadedPet = JsonSerializer.Deserialize<Tiger>(json);
                        loadedPet.PassiveProgress(TimePassUpdate());
                        break;
                    case "Panther":
                        loadedPet = JsonSerializer.Deserialize<Panther>(json);
                        loadedPet.PassiveProgress(TimePassUpdate());
                        break;
                    case "Lion":
                        loadedPet = JsonSerializer.Deserialize<Lion>(json);
                        loadedPet.PassiveProgress(TimePassUpdate());
                        break;
                    default:
                        throw new CorruptSaveException();

                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading pet from JSON: {ex.Message}");
            }
            return loadedPet;

        }

    }
}
