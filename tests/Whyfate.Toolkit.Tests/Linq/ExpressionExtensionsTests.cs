using System.Linq.Expressions;
using Whyfate.Toolkit.Linq;

namespace Whyfate.Toolkit.Tests.Linq;

public class ExpressionExtensionsTests
{
    [Fact]
    public void TestAndAlso()
    {
        Expression<Func<Person, bool>> ex1 = p => p.Name == "1";
        Expression<Func<Person, bool>> ex2 = p => p.Age > 10;
        var andEx = ex1.AndAlso(ex2);

        Assert.True(andEx.Compile().Invoke(new Person("1", 20)));
        Assert.False(andEx.Compile().Invoke(new Person("2", 20)));
        Assert.False(andEx.Compile().Invoke(new Person("1", 10)));
    }

    [Fact]
    public void TestOrElse()
    {
        Expression<Func<Person, bool>> ex1 = p => p.Name == "1";
        Expression<Func<Person, bool>> ex2 = p => p.Age > 10;
        var andEx = ex1.OrElse(ex2);

        Assert.True(andEx.Compile().Invoke(new Person("1", 20)));
        Assert.True(andEx.Compile().Invoke(new Person("2", 20)));
        Assert.True(andEx.Compile().Invoke(new Person("1", 10)));
        Assert.False(andEx.Compile().Invoke(new Person("2", 10)));
    }
}

class Person(string name, int age)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
}