public class TextShape : Shape
{
    private TextView textView;

    public TextShape(TextView textView)
    {
        this.textView = textView;
    }

    public override void BoundingBox()
    {
        textView.GetExtent();
    }

    public override void CreateManipulator()
    {
        Console.WriteLine("TextShape.CreateManipulator() (return new TextManipulator())");
    }
} 