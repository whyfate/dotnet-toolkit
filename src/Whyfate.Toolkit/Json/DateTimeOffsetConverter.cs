using System.Text.Json;
using System.Text.Json.Serialization;

namespace Whyfate.Toolkit.Json;

/// <summary>
/// DateTimeOffset.
/// </summary>
public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    private readonly string _format = "yyyy-MM-dd'T'HH:mm:ss.fffzzzz";

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeConverter"/> class.
    /// </summary>
    public DateTimeOffsetConverter()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeConverter"/> class.
    /// </summary>
    /// <param name="format">dateTimeFormat.</param>
    public DateTimeOffsetConverter(string? format)
    {
        if (!string.IsNullOrWhiteSpace(format))
        {
            _format = format;
        }
    }

    /// <summary>
    /// 读.
    /// </summary>
    /// <param name="reader">reader.</param>
    /// <param name="typeToConvert">typeToConvert.</param>
    /// <param name="options">options.</param>
    /// <returns>dt.</returns>
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrWhiteSpace(value))
            throw new NullReferenceException();

        return DateTimeOffset.Parse(value);
    }

    /// <summary>
    /// 写.
    /// </summary>
    /// <param name="writer">writer.</param>
    /// <param name="value">value.</param>
    /// <param name="options">options.</param>
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}