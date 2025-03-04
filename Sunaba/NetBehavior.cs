namespace Sunaba;

public class NetBehavior : IDisposable
{
    public virtual void Initialize() { }
    
    public virtual void EnterScene() { }
    
    public virtual void Start() { }
    
    public virtual void Update(float deltaTime) { }
    
    public virtual void PhysicsUpdate(float deltaTime) { }
    
    public virtual void ExitScene() { }
    
    public virtual void Stop() { }
    
    public virtual void Dispose() { }
}