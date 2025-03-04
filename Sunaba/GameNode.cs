namespace Sunaba;

public class GameNode : SceneNode
{
    private SceneNode? _parentNode { get; set; }
    
    public string? Name { get; set; }

    public SceneNode? Parent
    {
        get => _parentNode;
    }

    public Scene? Scene
    {
        get {
        if (Parent == null)
            return null;
        if (Parent is Scene scene)
            return scene;
        else if (Parent is GameNode gameNode)
            return gameNode.Scene;
        return null;
        }
    }
    private List<NetBehavior> _components { get; set; } = new List<NetBehavior>();
    
    public List<NetBehavior> Components { get => _components; }

    public NetBehavior AddComponent<TComponent>() where TComponent : NetBehavior
    {
        foreach (var c in Components)
        {
            if (c is TComponent)
            {
                throw new Exception($"Component {typeof(TComponent).Name} is already attached to {Name}");
            }
        }
        var component = Activator.CreateInstance<TComponent>();
        Components.Add(component);
        component.Initialize();
        return component;
    }

    public bool HasComponent<TComponent>() where TComponent : NetBehavior
    {
        foreach (var component in Components)
        {
            if (component is TComponent)
                return true;
        }
        return false;
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

    public void RemoveComponent<TComponent>() where TComponent : NetBehavior
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
        Components.Remove(component);
    }
}