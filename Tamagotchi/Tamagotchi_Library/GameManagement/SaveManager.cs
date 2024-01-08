using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tamagotchi_Library.AnimalManagement;

namespace Tamagotchi_Library.GameManagement
{
    public class SaveManager
    {

        List<string> felineData = new List<string>();
        public string name { get; init; }
        public int age { get; set; }
        public int hunger { get; set; }
        public int thirst { get; set; }
        public int happiness { get; set; }
        public string type { get; init; }
        public DateTime lastLogOn { get; set; }

        IFeline feline;

        [JsonConstructor]
        public SaveManager(IFeline toSave)
        {
 
           felineData = toSave.getFelineInfo();
           name = felineData[0];
           age = int.Parse(felineData[1]);
           hunger = int.Parse(felineData[2]);
           thirst = int.Parse(felineData[3]);
           happiness = int.Parse(felineData[4]);
           type = felineData[5];
            feline = toSave;


        }

        public void updateData(IFeline toSave)
        {
            felineData = toSave.getFelineInfo();
            age = int.Parse(felineData[1]);
            hunger = int.Parse(felineData[2]);
            thirst = int.Parse(felineData[3]);
            happiness = int.Parse(felineData[4]);
            lastLogOn = DateTime.Now;
        }

        public void saveToJson(string filePath)
        {
            updateData(feline); 

            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
           
            File.WriteAllText(filePath, json);
        }

        public static IFeline loadFromJson(string filePath)
        {
            IFeline loadedPet = null;

            try
            {
                string json = File.ReadAllText(filePath);
                Console.WriteLine(json);
                int startIndex = json.IndexOf("\"type\": \"") + ("\"type\": \"").Length;
                int endIndex = json.IndexOf("\"", startIndex + 1);
                string type = json.Substring(startIndex, endIndex - startIndex);

                switch (type)
                {
                    case "Tiger":
                        loadedPet = JsonSerializer.Deserialize<Tiger>(json);

                        break;
                    case "Panther":
                        loadedPet = JsonSerializer.Deserialize<Panther>(json);

                        break;
                    case "Lion":
                        loadedPet = JsonSerializer.Deserialize<Lion>(json);

                        break;
                    default:
                        throw new CorruptSaveException();

                }

                loadedPet = JsonSerializer.Deserialize<Tiger>(json);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading pet from JSON: {ex.Message}");
            }



            return loadedPet;


        }

    }
}
