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
        private string name;
        private int age;
        private int hunger;
        private int thirst;
        private int happiness;
        private string type;
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
        }

        public void saveToJson(string filePath)
        {
            updateData(feline);

            var saveManagerInstance = new SaveManager(feline);

            string toJson = JsonSerializer.Serialize(saveManagerInstance, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, toJson);

        }
    }
}
