using System;
using System.Windows.Forms;

class MainForm : Form
{
    public MainForm()
    {
        this.Width = 400;
        this.Height = 200;
        Button btnMS = new Button { Text = "MS Window", Left = 30, Top = 100, Width = 120 };
        Button btnMac = new Button { Text = "Mac Window", Left = 170, Top = 100, Width = 120 };
        btnMS.Click += (s, e) => {
            this.Controls.Clear();
            Window msWindow = new MSWindow(new MSWindowImp());
            msWindow.Draw(this);
        };
        btnMac.Click += (s, e) => {
            this.Controls.Clear();
            Window macWindow = new MacWindow(new MacWindowImp());
            macWindow.Draw(this);
        };
        this.Controls.Add(btnMS);
        this.Controls.Add(btnMac);
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
