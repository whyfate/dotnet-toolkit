using System.Text.Json;
using Whyfate.Toolkit.Json;

namespace Whyfate.Toolkit.Tests.Json;

public class JsonConverterTest
{
    [Fact]
    public void TestDateOnly()
    {
        var c = new DateOnlyConverter(null);
        var options = new JsonSerializerOptions();
        options.Converters.Add(c);
        
        var str = JsonSerializer.Serialize(DateOnly.Parse("2025-08-12"),options);
        Assert.Equal("\"2025-08-12\"", str);
        
        c = new DateOnlyConverter("yyyy-MM");
        options = new JsonSerializerOptions();
        options.Converters.Add(c);
        str = JsonSerializer.Serialize(DateOnly.Parse("2025-08-12"),options);
        Assert.Equal("\"2025-08\"", str);
    }
    
    [Fact]
    public void TestTimeOnly()
    {
        var c = new TimeOnlyConverter(null);
        var options = new JsonSerializerOptions();
        options.Converters.Add(c);
        
        var str = JsonSerializer.Serialize(TimeOnly.Parse("09:00:00"),options);
        Assert.Equal("\"09:00:00\"", str);
        
        c = new TimeOnlyConverter("HH:mm");
        options = new JsonSerializerOptions();
        options.Converters.Add(c);
        str = JsonSerializer.Serialize(TimeOnly.Parse("09:00:00"),options);
        Assert.Equal("\"09:00\"", str);
    }
    
    [Fact]
    public void TestDateTime()
    {
        var c = new DateTimeConverter(null);
        var options = new JsonSerializerOptions();
        options.Converters.Add(c);
        
        var str = JsonSerializer.Serialize(DateTime.Parse("2025-08-12 09:00:00"),options);
        Assert.Equal("\"2025-08-12T09:00:00.000\"", str);
        
        c = new DateTimeConverter("yyyy-MM-dd HH:mm:ss");
        options = new JsonSerializerOptions();
        options.Converters.Add(c);
        str = JsonSerializer.Serialize(DateTime.Parse("2025-08-12 09:00:00"),options);
        Assert.Equal("\"2025-08-12 09:00:00\"", str);
    }
    
    [Fact]
    public void TestDateTimeOffset()
    {
        var c = new DateTimeOffsetConverter(null);
        var options = new JsonSerializerOptions();
        options.Converters.Add(c);
        
        var str = JsonSerializer.Serialize(DateTimeOffset.Parse("2025-08-12 09:00:00.000+08:00"),options);
        Assert.Equal("\"2025-08-12T09:00:00.000\\u002B08:00\"", str);
        
        c = new DateTimeOffsetConverter("yyyy-MM-dd HH:mm:sszzzz");
        options = new JsonSerializerOptions();
        options.Converters.Add(c);
        str = JsonSerializer.Serialize(DateTimeOffset.Parse("2025-08-12 09:00:00.000+08:00"),options);
        Assert.Equal("\"2025-08-12 09:00:00\\u002B08:00\"", str);
    }
}