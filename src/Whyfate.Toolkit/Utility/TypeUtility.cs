using System.Collections.Concurrent;

namespace Whyfate.Toolkit.Utility;

/// <summary>
/// type utility.
/// </summary>
public static class TypeUtility
{
    /// <summary>
    /// type cache.
    /// </summary>
    private static readonly ConcurrentDictionary<string, Type?> TypeCaches = new();

    /// <summary>
    /// get type from typename.
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static Type? GetType(string typeName)
    {
        return TypeCaches.GetOrAdd(typeName, tName =>
        {
            Type? type = null;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var tmp = assembly.GetType(tName);
                if (tmp != null)
                {
                    type = tmp;
                    break;
                }
            }

            return type;
        });
    }

    /// <summary>
    /// is simple type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool IsSimpleType(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (type.IsValueType)
        {
            return true;
        }

        return typeof(string) == type || typeof(Enum) == type;
    }
}