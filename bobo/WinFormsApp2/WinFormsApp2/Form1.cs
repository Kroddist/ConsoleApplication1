using System;
using System.Windows.Forms;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            Compiler compiler = new Compiler();
            compiler.Compile("print('Hello, Facade!')");
            MessageBox.Show("Компиляция завершена! (см. консоль)");
        }
    }
}
