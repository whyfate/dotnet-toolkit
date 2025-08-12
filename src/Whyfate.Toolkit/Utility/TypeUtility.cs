using System.Collections.Concurrent;

namespace Whyfate.Toolkit.Utility;

/// <summary>
/// type utility.
/// </summary>
public static class TypeUtility
{
    private static readonly Lock _lock = new Lock();
    private static readonly ConcurrentDictionary<string, Type?> _typeCaches = new ConcurrentDictionary<string, Type?>();

    /// <summary>
    /// get type from typename.
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static Type? GetType(string typeName)
    {
        if (_typeCaches.TryGetValue(typeName, out var t1))
        {
            return t1;
        }

        lock (_lock)
        {
            if (_typeCaches.TryGetValue(typeName, out var t2))
            {
                return t2;
            }

            Type? type = null;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var tmp = assembly.GetType(typeName);
                if (tmp != null)
                {
                    type = tmp;
                    break;
                }
            }

            _typeCaches.TryAdd(typeName, type);
            return type;
        }
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