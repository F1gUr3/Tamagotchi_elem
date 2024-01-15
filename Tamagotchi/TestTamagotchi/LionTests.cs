using Tamagotchi_Library.AnimalManagement;

namespace TestTamagotchi;

[TestClass]
public class LionTests
{
    [TestMethod]
    public void GetFelineInfo_VisszAdjaHelyesenAzInfokat()
    {
        IFeline lion = new Lion("sddds");
        var expectedInfo = new List<string> { "sddds", "0", "100", "100", "100", "Lion" };
        
        var actualInfo = lion.getFelineInfo();
        
        CollectionAssert.AreEqual(expectedInfo, actualInfo);
    }

    [TestMethod]
    public void Progress_NovelAzEletkort()
    {
        Lion lion = new Lion("Aasd");
        
        lion.Progress();
        var info = lion.getFelineInfo();
        
        Assert.IsTrue(float.Parse(info[1]) > 0); 
    }

    [TestMethod]
    public void PassiveProgress_CsokkentiASzuksegleteket()
    {

        Lion lion = new Lion("asd");
        
        lion.PassiveProgress(24);
        var info = lion.getFelineInfo();


        Assert.IsTrue(int.Parse(info[2]) < 100); 
        Assert.IsTrue(int.Parse(info[3]) < 100); 
        Assert.IsTrue(int.Parse(info[4]) < 100); 
    }

    [TestMethod]
    public void Eszik_NoveliEhsegetEsABoldogsagot()
    {
        Lion lion = new Lion("asdasd");
        lion.PassiveProgress(5); 
        int initialHunger = int.Parse(lion.getFelineInfo()[2]);
        int initialHappiness = int.Parse(lion.getFelineInfo()[4]);
        
        lion.Eat();
        
        Assert.IsTrue(int.Parse(lion.getFelineInfo()[2]) > initialHunger);
        Assert.IsTrue(int.Parse(lion.getFelineInfo()[4]) > initialHappiness); 
    }

    [TestMethod]
    public void Jatszik_NoveliABoldogsagotEsCsokkentiAzEhsegetASzomjusagot()
    {
        Lion lion = new Lion("sdasd");
        lion.PassiveProgress(5);
        int initialHunger = int.Parse(lion.getFelineInfo()[2]);
        int initialThirst = int.Parse(lion.getFelineInfo()[3]);
        int initialHappiness = int.Parse(lion.getFelineInfo()[4]);
        
        lion.Play();
        
        Assert.IsTrue(int.Parse(lion.getFelineInfo()[2]) < initialHunger); 
        Assert.IsTrue(int.Parse(lion.getFelineInfo()[3]) < initialThirst); 
        Assert.IsTrue(int.Parse(lion.getFelineInfo()[4]) > initialHappiness);
    }
}