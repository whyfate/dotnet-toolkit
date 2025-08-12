using Whyfate.Toolkit.Json;

namespace Whyfate.Toolkit.Utility;

/// <summary>
/// object utility.
/// </summary>
public static class ObjectUtility
{
    /// <summary>
    /// copy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="target"></param>
    public static void Copy<T>(T source, T target)
    {
        var type = typeof(T);
        var properties =
            type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var property in properties)
        {
            // Get Set
            if (property is { CanWrite: true, CanRead: true })
            {
                var value = property.GetValue(source);
                if (value != null)
                {
                    property.SetValue(target, value);
                }
            }
            else
            {
                // IEnumerable<T>
                if (!property.PropertyType.IsGenericType || !property.CanRead)
                {
                    continue;
                }

                var targetValue = property.GetValue(target);
                var sourceValue = property.GetValue(source);
                if (sourceValue == null || targetValue == null)
                {
                    continue;
                }

                var countProperty = sourceValue.GetType().GetProperty("Count");
                if (countProperty == null)
                {
                    continue;
                }

                var method = targetValue.GetType().GetMethod("Add",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (method == null)
                {
                    continue;
                }

                var itemProperty = sourceValue.GetType().GetProperty("Item");
                if (itemProperty == null)
                {
                    continue;
                }

                var objectCount = countProperty.GetValue(sourceValue);
                if (objectCount == null)
                {
                    continue;
                }

                var count = (int)objectCount;

                for (int i = 0; i < count; i++)
                {
                    var v = itemProperty.GetValue(sourceValue, [i]);
                    if (v != null)
                    {
                        method.Invoke(targetValue, [v]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// poor clone.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? PoorClone<T>(T source)
        where T : class
    {
        return JsonUtility.Deserialize<T>(JsonUtility.Serialize(source));
    }
}