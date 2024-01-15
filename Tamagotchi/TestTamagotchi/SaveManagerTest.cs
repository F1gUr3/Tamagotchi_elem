using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tamagotchi_Library.AnimalManagement;
using Tamagotchi_Library.GameManagement;

namespace TestTamagotchi
{
    [TestClass]
    public class SaveManagerTest
    {
         SaveManager saveManager = new SaveManager(new Tiger("tesTiger"));
        SaveManager saveManagerLoad = new SaveManager();


        [TestMethod]
        public void TestTimePassUpdate()
        {
            saveManager.lastLogOn = DateTime.Now.AddHours(-2); 

            int elapsedHours = saveManager.TimePassUpdate();

            Assert.AreEqual(2, elapsedHours);
        }

        [TestMethod]
        public void TestLoadFromJson()
        {
            string filePath = "Kiskedvenc.json";


            IFeline loadedPet = saveManagerLoad.loadFromJson(filePath);

            Assert.IsNotNull(loadedPet);
            Assert.IsInstanceOfType(loadedPet, typeof(Tiger));

        }

        [TestMethod]
        public void TestUpdateStatsUpdatingAfterProgression()
        {
            Tiger TesTiger = new Tiger("TesTiger");

            int oldHunger = int.Parse(TesTiger.getFelineInfo()[2]);

            saveManager = new SaveManager(TesTiger);

            TesTiger.Hunt();
            saveManager.updateData(TesTiger);

            Assert.AreNotEqual(oldHunger, saveManager.hunger);

        }

    }
}
