using System;
using System.Windows.Forms;

public abstract class Window
{
    protected WindowImp windowImp;
    public Window(WindowImp imp)
    {
        windowImp = imp;
    }
    public abstract void Draw(Form form);
}

public class MSWindow : Window
{
    public MSWindow(WindowImp imp) : base(imp) { }
    public override void Draw(Form form)
    {
        windowImp.DevDrawButton(form);
        windowImp.DevDrawForm(form);
    }
}

public class MacWindow : Window
{
    public MacWindow(WindowImp imp) : base(imp) { }
    public override void Draw(Form form)
    {
        windowImp.DevDrawButton(form);
        windowImp.DevDrawForm(form);
    }
} 