public class DrawingEditor
{
    private Shape shape;

    public DrawingEditor(Shape shape)
    {
        this.shape = shape;
    }

    public void Draw()
    {
        shape.BoundingBox();
        shape.CreateManipulator();
    }
} 