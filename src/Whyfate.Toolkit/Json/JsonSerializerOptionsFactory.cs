using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Whyfate.Toolkit.Json;

/// <summary>
/// JsonSerializerOptions Factory.
/// </summary>
public static class JsonSerializerOptionsFactory
{
    /// <summary>
    /// options.
    /// </summary>
    private static JsonSerializerOptions? _options;

    /// <summary>
    /// lock obj.
    /// </summary>
    private static readonly Lock _lockObj = new Lock();

    /// <summary>
    /// 写入options.
    /// </summary>
    /// <param name="options"></param>
    public static void Set(JsonSerializerOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// 得到options.
    /// </summary>
    /// <returns></returns>
    public static JsonSerializerOptions Get()
    {
        if (_options == null)
        {
            lock (_lockObj)
            {
                if (_options == null)
                {
                    _options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true,
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                    };

                    _options.Converters.Add(new DateTimeConverter());
                    _options.Converters.Add(new DateTimeOffsetConverter());
                    _options.Converters.Add(new DateOnlyConverter());
                    _options.Converters.Add(new TimeOnlyConverter());
                    _options.Converters.Add(new JsonStringEnumConverter());
                }
            }
        }

        return _options;
    }
}