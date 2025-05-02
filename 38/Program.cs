using ConsoleApp3;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new GlyphFactory();
            var page = factory.CreatePage();
            var row = factory.CreateRow();
            var col = factory.CreateColumn();

            col.Add(factory.CreateCharacter('A'));
            col.Add(factory.CreateCharacter('B'));
            col.Add(factory.CreateCharacter('A')); 

            row.Add(col);
            page.Add(row);

            page.Draw("DemoContext");
        }
    }
}
