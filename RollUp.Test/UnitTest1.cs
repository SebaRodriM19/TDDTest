using RoolUp;

namespace RollUp.Test;

public class UnitTest1
{
    private Output _sut;

    [Fact]
    public void Test1()
    {
        _sut = new Output();
    }

    [Fact]
    public void ShouldReturnProductAsSamePriceOfHisChild()
    {
        Test1();
        var listOfChain = new List<Chain>();

        var item1 = new Chain("G1","V1","P1",100);
        var item2 = new Chain("G2", "V1", "P1", 100);
        var item3 = new Chain("G3", "V2", "P1", 100);
        var item4 = new Chain("G4", "V2", "P1", 100);

        listOfChain.Add(item1);
        listOfChain.Add(item2);
        listOfChain.Add(item3);
        listOfChain.Add(item4);

        Assert.Equal("P1 100", _sut.CheckPrice(listOfChain));
    }

    [Fact]
    public void ShouldReturnProductAsSamePriceOfHisChildOneDotOne()
    {
        Test1();
        var listOfChain = new List<Chain>();

        var item1 = new Chain("G1", "V1", "P1", 100);
        var item2 = new Chain("G2", "V1", "P1", 100);
        var item3 = new Chain("G3", "V2", "P1", 100);
        var item4 = new Chain("G4", "V2", "P1", 100);
        var item5 = new Chain("G5", "V2", "P1", 100);

        listOfChain.Add(item1);
        listOfChain.Add(item2);
        listOfChain.Add(item3);
        listOfChain.Add(item4);

        Assert.Equal("P1 100", _sut.CheckPrice(listOfChain));
    }

    [Fact]
    public void ShouldReturnProductAsSamePriceOfHisChildOneDotTwo()
    {
        Test1();
        var listOfChain = new List<Chain>();

        var item1 = new Chain("G1", "V1", "P1", 100);
        var item2 = new Chain("G2", "V1", "P1", 100);
        var item3 = new Chain("G3", "V2", "P1", 100);
        var item4 = new Chain("G4", "V2", "P1", 100);
        var item5 = new Chain("G5", "V3", "P1", 100);

        listOfChain.Add(item1);
        listOfChain.Add(item2);
        listOfChain.Add(item3);
        listOfChain.Add(item4);
        listOfChain.Add(item5);

        Assert.Equal("P1 100", _sut.CheckPrice(listOfChain));
    }

    [Fact]
    public void ShouldReturnProductAsSamePriceOfHisChildOneDotThree()
    {
        Test1();

        var listOfChain = new List<Chain>();

        var item1 = new Chain("G1", "V1", "P1", 100);
        var item2 = new Chain("G2", "V1", "P1", 100);
        var item3 = new Chain("G3", "V2", "P1", 100);
        var item4 = new Chain("G4", "V2", "P1", 100);
        var item5 = new Chain("G5", "V3", "P2", 100);

        listOfChain.Add(item1);
        listOfChain.Add(item2);
        listOfChain.Add(item3);
        listOfChain.Add(item4);
        listOfChain.Add(item5);

        Assert.Equal("P1 100, P2 100", _sut.CheckPrice(listOfChain));
    }
}
