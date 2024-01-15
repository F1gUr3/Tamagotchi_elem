using Tamagotchi_Library.AnimalManagement;

namespace TestTamagotchi;

[TestClass]
public class PantherTests
{
    [TestMethod]
    public void GetFelineInfo_VisszAdjaHelyesenAzInfokat()
    {
        IFeline panther = new Panther("asdsad");
        var expectedInfo = new List<string> { "asdsad", "0", "100", "100", "100", "Panther" };
        
        var actualInfo = panther.getFelineInfo();
        
        CollectionAssert.AreEqual(expectedInfo, actualInfo);
    }
    [TestMethod]
    public void Progress_NovelAzEletkort()
    {
        Panther panther = new Panther("Aasd");
        
        panther.Progress();
        var info = panther.getFelineInfo();
        
        Assert.IsTrue(float.Parse(info[1]) > 0); 
    }

    [TestMethod]
    public void PassiveProgress_CsokkentiASzuksegleteket()
    {

        Panther panther = new Panther("asd");
        
        panther.PassiveProgress(24);
        var info = panther.getFelineInfo();


        Assert.IsTrue(int.Parse(info[2]) < 100); 
        Assert.IsTrue(int.Parse(info[3]) < 100); 
        Assert.IsTrue(int.Parse(info[4]) < 100); 
    }

    [TestMethod]
    public void Eszik_NoveliEhsegetEsABoldogsagot()
    {
        Panther panther = new Panther("asdasd");
        panther.PassiveProgress(5); 
        int initialHunger = int.Parse(panther.getFelineInfo()[2]);
        int initialHappiness = int.Parse(panther.getFelineInfo()[4]);
        
        panther.Eat();
        
        Assert.IsTrue(int.Parse(panther.getFelineInfo()[2]) > initialHunger);
        Assert.IsTrue(int.Parse(panther.getFelineInfo()[4]) > initialHappiness); 
    }

    [TestMethod]
    public void Jatszik_NoveliABoldogsagotEsCsokkentiAzEhsegetASzomjusagot()
    {
        Panther panther = new Panther("sdasd");
        panther.PassiveProgress(5);
        int initialHunger = int.Parse(panther.getFelineInfo()[2]);
        int initialThirst = int.Parse(panther.getFelineInfo()[3]);
        int initialHappiness = int.Parse(panther.getFelineInfo()[4]);
        
        panther.Play();
        
        Assert.IsTrue(int.Parse(panther.getFelineInfo()[2]) < initialHunger); 
        Assert.IsTrue(int.Parse(panther.getFelineInfo()[3]) < initialThirst); 
        Assert.IsTrue(int.Parse(panther.getFelineInfo()[4]) > initialHappiness);
    }
}