using Whyfate.Toolkit.Utility;

namespace Whyfate.Toolkit.Tests.Utilities;

public class ObjectUtilityTests
{
    [Fact]
    public void TestCopy()
    {
        var c1 = new Copyer(true)
        {
            Name = "1",
            Age = 1,
            Addresses = ["1", "2", "3"],
        };

        var c2 = new Copyer(false);
        ObjectUtility.Copy(c1, c2);

        Assert.Equal(c1.Name, c2.Name);
        Assert.Equal(c1.Age, c2.Age);
        Assert.NotNull(c2.Addresses);
        Assert.Equal(c1.Addresses.Count, c2.Addresses.Count);
        Assert.Equal(c1.List.Count, c2.List.Count);
        Assert.Null(c2.List2);
    }

    [Fact]
    public void TestCopy2()
    {
        var c1 = new Copyer2
        {
            Name = "1",
        };
        c1.Add();

        var c2 = new Copyer2();
        ObjectUtility.Copy(c1, c2);

        Assert.Equal(c1.Name, c2.Name);
        Assert.NotNull(c2.Addresses);
        Assert.Equal(c1.Addresses.Count, c2.Addresses.Count);
        Assert.Null(c2.Names);
    }

    [Fact]
    public void TestPoorClone()
    {
        var c1 = new Copyer(true)
        {
            Name = "1",
            Age = 1,
            Addresses = ["1", "2", "3"]
        };

        var c2 = ObjectUtility.PoorClone(c1);

        Assert.NotNull(c2);
        Assert.Equal(c1.Name, c2.Name);
        Assert.Equal(c1.Age, c2.Age);
        Assert.NotNull(c2.Addresses);
        Assert.Equal(c1.Addresses.Count, c2.Addresses.Count);
    }

    private class Copyer
    {
        public Copyer()
        {
        }

        public Copyer(bool initList)
        {
            if (initList)
            {
                List = new List<string> { "1", "2" };
                List2 = new List<string> { "1", "2" };
            }
            else
            {
                List = new List<string>();
            }
        }
        
        public string? Name { get; init; }
        public int Age { get; init; }
        public List<string>? Addresses { get; init; }
        public IReadOnlyList<string> List { get; }
        public IReadOnlyList<string> List2 { get; }
    }

    private class Copyer2
    {
        private readonly List<string> _addresses;

        public Copyer2()
        {
            _addresses = new List<string>();
        }

        public string? Name { get; init; }

        public IReadOnlyList<string> Addresses => _addresses;

        public List<string> Names { get; }

        public void Add()
        {
            _addresses.Add("1");
            _addresses.Add("2");
            _addresses.Add("3");
        }
    }
}