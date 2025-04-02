using System;

namespace BankSystem
{
    public enum AccountType { Savings, Current }

    public class BankAccount
    {
        private static int accountCounter = 1000;
        private int accountNumber;
        private double balance;
        private AccountType accountType;

        public BankAccount(AccountType type, double initialBalance)
        {
            this.accountNumber = ++accountCounter;
            this.accountType = type;
            this.balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0) balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount > balance) return false;
            balance -= amount;
            return true;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Account Number: {accountNumber}, Type: {accountType}, Balance: {balance}");
        }
    }
}

namespace SortingAlgorithms
{
    public class Sort
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;
            int pivot = arr[right], i = left;
            for (int j = left; j < right; j++)
                if (arr[j] < pivot)
                    (arr[i++], arr[j]) = (arr[j], arr[i]);
            (arr[i], arr[right]) = (arr[right], arr[i]);
            QuickSort(arr, left, i - 1);
            QuickSort(arr, i + 1, right);
        }
    }
}

namespace StringOperations
{
    public class StringTasks
    {
        public static int GetStringLength(string str)
        {
            int length = 0;
            foreach (char c in str) length++;
            return length;
        }

        public static void PrintReverse(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        public static int CountWords(string str)
        {
            return str.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static bool CompareStrings(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            for (int i = 0; i < str1.Length; i++)
                if (str1[i] != str2[i]) return false;
            return true;
        }

        public static void CountCharacters(string str, out int letters, out int digits, out int special)
        {
            letters = digits = special = 0;
            foreach (char c in str)
            {
                if (char.IsLetter(c)) letters++;
                else if (char.IsDigit(c)) digits++;
                else special++;
            }
        }

        public static string CopyString(string str)
        {
            char[] copiedStr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
                copiedStr[i] = str[i];
            return new string(copiedStr);
        }

        public static void CountVowelsConsonants(string str, out int vowels, out int consonants)
        {
            vowels = consonants = 0;
            string vowelSet = "AEIOUaeiou";
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    if (vowelSet.Contains(c)) vowels++;
                    else consonants++;
                }
            }
        }

        public static void SortStringArray(string[] arr)
        {
            Array.Sort(arr);
        }
    }
}

class Program
{
    static void Main()
    {
        BankSystem.BankAccount account = new BankSystem.BankAccount(BankSystem.AccountType.Savings, 5000);
        account.Deposit(1500);
        account.Withdraw(2000);
        account.PrintInfo();

        int[] arr = { 5, 2, 9, 1, 5, 6 };
        SortingAlgorithms.Sort.BubbleSort(arr);
        Console.WriteLine("Bubble Sorted: " + string.Join(", ", arr));

        int[] arr2 = { 10, 7, 8, 9, 1, 5 };
        SortingAlgorithms.Sort.QuickSort(arr2, 0, arr2.Length - 1);
        Console.WriteLine("Quick Sorted: " + string.Join(", ", arr2));

        string str = "Hello World!";
        Console.WriteLine("String Length: " + StringOperations.StringTasks.GetStringLength(str));

        Console.Write("Reversed String: ");
        StringOperations.StringTasks.PrintReverse(str);

        Console.WriteLine("Word Count: " + StringOperations.StringTasks.CountWords(str));

        Console.WriteLine("Comparison (Hello, Hello): " + StringOperations.StringTasks.CompareStrings("Hello", "Hello"));
        Console.WriteLine("Comparison (Hello, World): " + StringOperations.StringTasks.CompareStrings("Hello", "World"));

        StringOperations.StringTasks.CountCharacters(str, out int letters, out int digits, out int special);
        Console.WriteLine($"Letters: {letters}, Digits: {digits}, Special: {special}");

        string copiedStr = StringOperations.StringTasks.CopyString(str);
        Console.WriteLine("Copied String: " + copiedStr);

        StringOperations.StringTasks.CountVowelsConsonants(str, out int vowels, out int consonants);
        Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}");

        string[] strArr = { "Banana", "Apple", "Cherry", "Mango" };
        StringOperations.StringTasks.SortStringArray(strArr);
        Console.WriteLine("Sorted Strings: " + string.Join(", ", strArr));
    }
}
