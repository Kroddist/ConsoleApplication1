namespace WinFormsApp1
{
    public class ConcreteCommand : Command
    {
        private Receiver receiver;
        public ConcreteCommand(Receiver r)
        {
            receiver = r;
        }
        public void Execute()
        {
            receiver.Operation();
        }
        public void Undo()
        {
            MessageBox.Show("Операция отменена!", "ConcreteCommand");
        }
    }
} 