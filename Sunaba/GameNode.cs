namespace Sunaba;

public class GameNode : BaseObject
{
    private BaseObject? _parentNode { get; set; }

    public BaseObject? Parent
    {
        get => _parentNode;
    }
    
    private List<NetBehavior> Components { get; set; } = new List<NetBehavior>();

    public NetBehavior AddComponent<TComponent>() where TComponent : NetBehavior
    {
        var component = Activator.CreateInstance<TComponent>();
        Components.Add(component);
        component.Initialize();
        return component;
    }

    public TComponent? GetComponent<TComponent>() where TComponent : NetBehavior
    {
        TComponent? component = null;
        foreach (var c in Components)
        {
            if (c is TComponent)
            {
                component = (TComponent)c;
                break;
            }
        }
        return component;
    }
}