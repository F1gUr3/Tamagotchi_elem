using Tamagotchi_Library.AnimalManagement;

namespace TestTamagotchi;

[TestClass]
public class TigerTests
{
    [TestMethod]
    public void GetFelineInfo_VisszAdjaHelyesenAzInfokat()
    {
        IFeline tiger = new Tiger("sddds");
        var expectedInfo = new List<string> { "sddds", "0", "100", "100", "100", "Tiger" };
        
        var actualInfo = tiger.getFelineInfo();
        
        CollectionAssert.AreEqual(expectedInfo, actualInfo);
    }

    [TestMethod]
    public void Progress_NovelAzEletkort()
    {
        Tiger tiger = new Tiger("Aasd");
        
        tiger.Progress();
        var info = tiger.getFelineInfo();
        
        Assert.IsTrue(float.Parse(info[1]) > 0); 
    }

    [TestMethod]
    public void PassiveProgress_CsokkentiASzuksegleteket()
    {

        Tiger tiger = new Tiger("asd");
        
        tiger.PassiveProgress(24);
        var info = tiger.getFelineInfo();


        Assert.IsTrue(int.Parse(info[2]) < 100); 
        Assert.IsTrue(int.Parse(info[3]) < 100); 
        Assert.IsTrue(int.Parse(info[4]) < 100); 
    }

    [TestMethod]
    public void Eszik_NoveliEhsegetEsABoldogsagot()
    {
        Tiger tiger = new Tiger("asdasd");
        tiger.PassiveProgress(5); 
        int initialHunger = int.Parse(tiger.getFelineInfo()[2]);
        int initialHappiness = int.Parse(tiger.getFelineInfo()[4]);
        
        tiger.Eat();
        
        Assert.IsTrue(int.Parse(tiger.getFelineInfo()[2]) > initialHunger);
        Assert.IsTrue(int.Parse(tiger.getFelineInfo()[4]) > initialHappiness); 
    }

    [TestMethod]
    public void Jatszik_NoveliABoldogsagotEsCsokkentiAzEhsegetASzomjusagot()
    {
        Tiger tiger = new Tiger("sdasd");
        tiger.PassiveProgress(5);
        int initialHunger = int.Parse(tiger.getFelineInfo()[2]);
        int initialThirst = int.Parse(tiger.getFelineInfo()[3]);
        int initialHappiness = int.Parse(tiger.getFelineInfo()[4]);
        
        tiger.Play();
        
        Assert.IsTrue(int.Parse(tiger.getFelineInfo()[2]) < initialHunger); 
        Assert.IsTrue(int.Parse(tiger.getFelineInfo()[3]) < initialThirst); 
        Assert.IsTrue(int.Parse(tiger.getFelineInfo()[4]) > initialHappiness);
    }
}