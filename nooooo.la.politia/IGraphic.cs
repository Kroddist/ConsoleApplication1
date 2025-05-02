public interface IGraphic
{
    void Add(IGraphic graphic);
    void Remove(IGraphic graphic);
    IGraphic GetChild(int child);
    void Draw(object device);
} 