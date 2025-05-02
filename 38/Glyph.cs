using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public abstract class Glyph
    {
        public abstract void Draw(string context);
        public abstract bool Intersects(Point point, string context);
    }

    public class Character : Glyph
    {
        private char _char;
        public Character(char c) { _char = c; }
        public override void Draw(string context)
        {
            Console.WriteLine($"Draw Character '{_char}' with context: {context}");
        }
        public override bool Intersects(Point point, string context)
        {
            return false;
        }
    }
    public class Row : Glyph
    {
        private List<Glyph> _children = new List<Glyph>();
        public void Add(Glyph glyph) => _children.Add(glyph);
        public override void Draw(string context)
        {
            foreach (var glyph in _children)
                glyph.Draw(context);
        }
        public override bool Intersects(Point point, string context)
        {
            foreach (var glyph in _children)
                if (glyph.Intersects(point, context))
                    return true;
            return false;
        }
    }
    public class Column : Glyph
    {
        private List<Glyph> _children = new List<Glyph>();
        public void Add(Glyph glyph) => _children.Add(glyph);
        public override void Draw(string context)
        {
            foreach (var glyph in _children)
                glyph.Draw(context);
        }
        public override bool Intersects(Point point, string context)
        {
            foreach (var glyph in _children)
                if (glyph.Intersects(point, context))
                    return true;
            return false;
        }
    }
    public class Page : Glyph
    {
        private List<Glyph> _children = new List<Glyph>();
        public void Add(Glyph glyph) => _children.Add(glyph);
        public override void Draw(string context)
        {
            foreach (var glyph in _children)
                glyph.Draw(context);
        }
        public override bool Intersects(Point point, string context)
        {
            foreach (var glyph in _children)
                if (glyph.Intersects(point, context))
                    return true;
            return false;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
    }
} 