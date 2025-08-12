using System.ComponentModel;
using System.Reflection;

namespace Whyfate.Toolkit.Utility;

public static class EnumUtility
{
    /// <summary>
    /// get enum attr.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static TAttribute? GetAttribute<TEnum, TAttribute>(this TEnum t)
        where TAttribute : Attribute
        where TEnum : struct, IConvertible
    {
        var type = typeof(TEnum);
        var field = type.GetField(t.ToString() ?? string.Empty);
        var value = field?.GetValue(null);
        if (t.Equals(value))
        {
            if (field != null) return field.GetCustomAttribute<TAttribute>();
        }

        return null;
    }


    /// <summary>
    /// Parse.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TEnum Parse<TEnum>(this string value)
        where TEnum : struct, IConvertible
    {
        if (!Enum.TryParse(value, out TEnum result))
        {
            return default;
        }

        return result;
    }

    /// <summary>
    /// Parse.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static TEnum Parse<TEnum>(this string value, TEnum defaultValue)
        where TEnum : struct, IConvertible
    {
        if (!Enum.TryParse(value, out TEnum result))
        {
            return defaultValue;
        }

        return result;
    }

    /// <summary>
    /// get description.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static string? GetDescription<TEnum>(this TEnum t)
        where TEnum : struct, IConvertible
    {
        return GetAttribute<TEnum, DescriptionAttribute>(t)?.Description;
    }
}