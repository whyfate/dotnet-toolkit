using System.Text.Json;
using System.Text.Json.Serialization;

namespace Whyfate.Toolkit.Json;

/// <summary>
/// date only.
/// </summary>
public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string _format = "yyyy-MM-dd";

    /// <summary>
    /// Initializes a new instance of the <see cref="DateOnlyConverter"/> class.
    /// </summary>
    public DateOnlyConverter()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateOnlyConverter"/> class.
    /// </summary>
    /// <param name="format">dateTimeFormat.</param>
    public DateOnlyConverter(string? format)
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
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrWhiteSpace(value))
            throw new NullReferenceException();

        return DateOnly.Parse(value);
    }

    /// <summary>
    /// write.
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}