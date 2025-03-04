namespace Sunaba;

public abstract class SceneNode : IDisposable
{
    private List<GameNode> _children { get; set; } = new List<GameNode>();
    
    public List<GameNode> Children { get => _children; }
    
    public int ChildrenCount => Children.Count;
    
    public GameNode GetChild(int index) => Children[index];

    protected GameNode? FindByList(List<string> path, int depth)
    {
        foreach (var node in Children)
        {
            if (node == Children[depth])
            {
                if (path[depth] == node.Name)
                {
                    return node;
                }
            }
        }
        
        return null;
    }

    public GameNode? Find(string path)
    {
        List<string> paths = path.Split('/').ToList();
        if (paths.Count == 0)
        {
            return null;
        }
        if (paths[0] == String.Empty)
        {
            paths.RemoveAt(0);
        }
        if (paths[^1] == String.Empty)
        {
            paths.RemoveAt(paths.Count - 1);
        }
        return FindByList(paths, 0);
    }

    public SceneNode() { }

    public void Dispose()
    {
        Children?.Clear();
    }
}