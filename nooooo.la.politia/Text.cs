public class Text : IGraphic
{
    public void Add(IGraphic graphic) { }
    public void Remove(IGraphic graphic) { }
    public IGraphic GetChild(int child) => null;
    public void Draw(object device)
    {
        System.Console.WriteLine("Рисуем текст");
    }
} 