using System.Text.Json;

namespace Whyfate.Toolkit.Json;

/// <summary>
/// json utility.
/// </summary>
public static class JsonUtility
{
    /// <summary>
    /// Serialize.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj, JsonSerializerOptionsFactory.Get());
    }

    /// <summary>
    /// Serialize.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string Serialize(object obj, Type type)
    {
        return JsonSerializer.Serialize(obj, type, JsonSerializerOptionsFactory.Get());
    }

    /// <summary>
    /// Deserialize.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T? Deserialize<T>(string json)
        where T : class
    {
        return JsonSerializer.Deserialize<T>(json, JsonSerializerOptionsFactory.Get());
    }

    /// <summary>
    /// Deserialize.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static T? Deserialize<T>(string json, Type type)
        where T : class
    {
        return JsonSerializer.Deserialize(json, type, JsonSerializerOptionsFactory.Get()) as T;
    }
}