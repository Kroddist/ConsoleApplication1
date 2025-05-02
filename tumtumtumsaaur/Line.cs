public class Line : Shape
{
    public override void BoundingBox()
    {
        Console.WriteLine("Line.BoundingBox()");
    }

    public override void CreateManipulator()
    {
        Console.WriteLine("Line.CreateManipulator()");
    }
} 