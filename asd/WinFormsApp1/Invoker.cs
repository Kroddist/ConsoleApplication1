namespace WinFormsApp1
{
    public class Invoker
    {
        private Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            command?.Execute();
        }
        public void Cancel()
        {
            command?.Undo();
        }
    }
} 