namespace WinFormsApp1
{
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private Invoker invoker;
        private Receiver receiver;
        private Command command;

        public Form1()
        {
            InitializeComponent();
            receiver = new Receiver();
            command = new ConcreteCommand(receiver);
            invoker = new Invoker();
            invoker.SetCommand(command);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            invoker.Run();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            invoker.Cancel();
        }
    }
}
