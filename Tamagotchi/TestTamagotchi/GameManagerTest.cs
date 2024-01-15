using Tamagotchi_Library.AnimalManagement;
using Tamagotchi_Library.GameManagement;

namespace TestTamagotchi;

[TestClass]
public class GameManagerTest
{
    GameManager gameManager = new GameManager();


    [TestMethod]
    public void TimePassUpdate_FrissitiAzIdoElteltet()
    {
        // Arrange
        IFeline lion = new Lion("Simba");
        SaveManager manager = new SaveManager(lion);
        manager.lastLogOn = DateTime.Now.AddHours(-5);
        int expectedHunger = int.Parse(lion.getFelineInfo()[2]) - 10;

        // Act
        int elapsedHours = manager.TimePassUpdate();
        lion.PassiveProgress(elapsedHours);
        var info = lion.getFelineInfo();

        // Assert
        Assert.AreEqual(expectedHunger, int.Parse(info[2]));
    }

    [TestMethod]
    public void ChoosePet_ReturnsCorrectPetInstance()
    {
        string petName = "TestPet";

            
            IFeline pet = gameManager.choosePet(petName, "1");

            Assert.IsNotNull(pet);
            Assert.AreEqual(petName, pet.getFelineInfo()[0]);
        
    }

    [TestMethod]
    public void ChoosePet_CreatesCorrectTypeInstance()
    {
        string petName = "tigerTest";
        IFeline pet = gameManager.choosePet(petName, "1");

        Assert.IsNotNull(pet);
        Assert.AreEqual("Tiger", pet.getFelineInfo()[5]);


    }


}