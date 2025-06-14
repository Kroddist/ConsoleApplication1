public class ConcreteCommand : Command
{
    private Receiver receiver;
    public ConcreteCommand(Receiver r)
    {
        receiver = r;
    }
    public override void Execute()
    {
        receiver.Operation();
    }
    public override void Undo()
    {
        Console.WriteLine("Откат операции Receiver");
    }
} 