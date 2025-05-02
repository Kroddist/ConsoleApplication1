using System.Collections.Generic;

public class Picture : IGraphic
{
    private List<IGraphic> _children = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        _children.Add(graphic);
    }

    public void Remove(IGraphic graphic)
    {
        _children.Remove(graphic);
    }

    public IGraphic GetChild(int child)
    {
        if (child >= 0 && child < _children.Count)
            return _children[child];
        return null;
    }

    public void Draw(object device)
    {
        System.Console.WriteLine("Рисуем картину, состоящую из:");
        foreach (var child in _children)
        {
            child.Draw(device);
        }
    }
} 