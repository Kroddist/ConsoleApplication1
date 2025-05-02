class Program
{
    static void Main(string[] args)
    {
        IGraphic line = new Line();
        IGraphic rectangle = new Rectangle();
        IGraphic text = new Text();

        Picture picture = new Picture();
        picture.Add(line);
        picture.Add(rectangle);
        picture.Add(text);

        Picture bigPicture = new Picture();
        bigPicture.Add(picture);
        bigPicture.Add(new Line());

        bigPicture.Draw(null);
    }
}
