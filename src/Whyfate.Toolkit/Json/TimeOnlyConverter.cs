using System.Text.Json;
using System.Text.Json.Serialization;

namespace Whyfate.Toolkit.Json;

/// <summary>
/// time only.
/// </summary>
public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    private readonly string _format = "HH:mm:ss";

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeOnlyConverter"/> class.
    /// </summary>
    public TimeOnlyConverter()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeOnlyConverter"/> class.
    /// </summary>
    /// <param name="format">dateTimeFormat.</param>
    public TimeOnlyConverter(string? format)
    {
        if (!string.IsNullOrWhiteSpace(format))
        {
            _format = format;
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrWhiteSpace(value))
            throw new NullReferenceException();

        return TimeOnly.Parse(value);
    }

    /// <summary>
    /// write.
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}