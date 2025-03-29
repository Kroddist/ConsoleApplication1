using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CyclicArray
{
    private int[] array;
    private int index = 0;
    public CyclicArray(int[] arr) => array = arr;
    public int Value
    {
        get
        {
            int val = array[index];
            index = (index + 1) % array.Length;
            return val;
        }
        set => array[index == 0 ? array.Length - 1 : index - 1] = value;
    }
}

class DigitField
{
    private int number;
    public int this[int index]
    {
        set
        {
            int digit = value % 10;
            int power = (int)Math.Pow(10, index);
            number = (number / (power * 10)) * (power * 10) + digit * power + number % power;
        }
    }
    public int Number => number;
}

class TextArray
{
    private string[] texts;
    public TextArray(string[] texts) => this.texts = texts;
    public string this[int index]
    {
        get => texts[index % texts.Length];
        set => texts[index % texts.Length] = value;
    }
    public char this[int row, int col]
    {
        get => texts[row % texts.Length][col % texts[row % texts.Length].Length];
    }
}

class Program
{
    static void Main()
    {
        CyclicArray ca = new CyclicArray(new int[] { 1, 2, 3 });
        Console.WriteLine(ca.Value);
        Console.WriteLine(ca.Value);
        ca.Value = 10;
        Console.WriteLine(ca.Value);

        DigitField df = new DigitField();
        df[1] = 25;
        Console.WriteLine(df.Number);

        TextArray ta = new TextArray(new string[] { "Hello", "World" });
        Console.WriteLine(ta[1]);
        Console.WriteLine(ta[0, 2]);
    }
}
