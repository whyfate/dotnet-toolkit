using System.Text.Encodings.Web;
using System.Text.Json;
using Whyfate.Toolkit.Json;

namespace Whyfate.Toolkit.Tests.Json;

public class JsonUtilityTests
{
    [Fact]
    public void Test()
    {
        var p1 = new Person("1", 35, DateOnly.Parse("2000-01-01"), DateTime.Now);
        var json = JsonUtility.Serialize(p1);
        Assert.NotEmpty(json);

        var p2 = JsonUtility.Deserialize<Person>(json);
        Assert.NotNull(p2);
        Assert.Equal(p1.Id, p2.Id);
        Assert.Equal(p1.Age, p2.Age);
        Assert.Equal(p1.BirthDay, p2.BirthDay);
        Assert.Equal(p1.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), p2.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    [Fact]
    public void TestSerilization()
    {
        var list = new List<string>
        {
            "é"
        };

        var json = JsonSerializer.Serialize(list, new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }
    
    [Fact]
    public void TestSetOptions()
    {
        JsonSerializerOptionsFactory.Set(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        var options = JsonSerializerOptionsFactory.Get();
        Assert.NotNull(options);
        Assert.True(options.PropertyNameCaseInsensitive);
    }
    
    [Fact]
    public void TestException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            JsonSerializerOptionsFactory.Set(null!);
        });
    }
}

class Person(string id, int age, DateOnly birthDay, DateTime createTime)
{
    public string Id { get; } = id;
    public int Age { get; } = age;
    public DateOnly BirthDay { get; } = birthDay;
    public DateTime CreateTime { get; } = createTime;
}