using System;
using System.Windows.Forms;

public interface WindowImp
{
    void DevDrawButton(Form form);
    void DevDrawForm(Form form);
}

public class MSWindowImp : WindowImp
{
    public void DevDrawButton(Form form)
    {
        Button btn = new Button();
        btn.Text = "MS Button";
        btn.Top = 30;
        btn.Left = 30;
        form.Controls.Add(btn);
    }
    public void DevDrawForm(Form form)
    {
        form.Text = "MS Form";
    }
}

public class MacWindowImp : WindowImp
{
    public void DevDrawButton(Form form)
    {
        Button btn = new Button();
        btn.Text = "Mac Button";
        btn.Top = 30;
        btn.Left = 150;
        form.Controls.Add(btn);
    }
    public void DevDrawForm(Form form)
    {
        form.Text = "Mac Form";
    }
} 