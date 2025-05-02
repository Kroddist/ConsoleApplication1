using System.Collections.Generic;

namespace ConsoleApp3
{
    public class GlyphFactory
    {
        private Dictionary<char, Character> _characters = new Dictionary<char, Character>();
        public Character CreateCharacter(char c)
        {
            if (!_characters.ContainsKey(c))
                _characters[c] = new Character(c);
            return _characters[c];
        }
        public Row CreateRow() => new Row();
        public Column CreateColumn() => new Column();
        public Page CreatePage() => new Page();
    }
} 