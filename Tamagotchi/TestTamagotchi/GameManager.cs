using Tamagotchi_Library.AnimalManagement;
using Tamagotchi_Library.GameManagement;

namespace TestTamagotchi;

[TestClass]
public class GameManager
{
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
}