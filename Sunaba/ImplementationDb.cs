namespace Sunaba;

public class ImplementationDb
{
    private static readonly Dictionary<Type, Type> Types = new();

    public static Type? GetType<T>()
    {
        return Types.TryGetValue(typeof(T), out var implType) ? implType : null;
    }

    public static void Register<TA, TB>() where TB : class, TA
    {
        Types[typeof(TA)] = typeof(TB);
    }

    public static object? CreateInstance<T>() where T : class
    {
        Type? type = GetType<T>();
        return type != null ? Activator.CreateInstance(type) : null;
    }
}