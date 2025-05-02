Line line = new Line();
TextView textView = new TextView();
TextShape textShape = new TextShape(textView);

DrawingEditor editor1 = new DrawingEditor(line);
DrawingEditor editor2 = new DrawingEditor(textShape);

Console.WriteLine("--- Line ---");
editor1.Draw();

Console.WriteLine("--- TextShape (Adapter) ---");
editor2.Draw();
