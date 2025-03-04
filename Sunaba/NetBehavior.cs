namespace Sunaba;

public class NetBehavior : IDisposable
{
    internal GameNode _gameNode;
    
    public GameNode GameNode { get => _gameNode; }
    
    public Scene Scene { get => _gameNode.Scene; }
    
    public virtual void Initialize() { }
    
    public virtual void EnterScene() { }
    
    public virtual void Start() { }
    
    public virtual void Update(float deltaTime) { }
    
    public virtual void PhysicsUpdate(float deltaTime) { }
    
    public virtual void ExitScene() { }
    
    public virtual void Stop() { }
    
    public virtual void Dispose() { }
}