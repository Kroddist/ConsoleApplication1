using System;

class Scanner
{
    public Token Scan(string source)
    {
        Console.WriteLine("Сканирование исходного кода...");
        return new Token();
    }
}

class Token { }

class Parser
{
    public ProgramNode Parse(Token token)
    {
        Console.WriteLine("Парсинг токенов...");
        return new ProgramNode();
    }
}

class ProgramNodeBuilder
{
    public ProgramNode Build()
    {
        Console.WriteLine("Построение дерева программы...");
        return new ProgramNode();
    }
}

class ProgramNode { }
class VariableNode : ProgramNode { }
class StatementNode : ProgramNode { }
class ExpressionNode : ProgramNode { }

class CodeGenerator
{
    public ByteCode Generate(ProgramNode node)
    {
        Console.WriteLine("Генерация байткода...");
        return new ByteCode();
    }
}

class ByteCode { }
class ByteCodeStream { }
class CISCCodeGenerator : CodeGenerator { }

// Facade
public class Compiler
{
    private Scanner scanner = new Scanner();
    private Parser parser = new Parser();
    private ProgramNodeBuilder builder = new ProgramNodeBuilder();
    private CodeGenerator codeGenerator = new CodeGenerator();

    public void Compile(string source)
    {
        Token token = scanner.Scan(source);
        ProgramNode program = parser.Parse(token);
        ProgramNode root = builder.Build();
        ByteCode byteCode = codeGenerator.Generate(root);
        Console.WriteLine("Компиляция завершена!");
    }
} 