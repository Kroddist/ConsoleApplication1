using System;

enum AccountType { Current, Savings, Deposit }

class BankAccount
{
    private static int accountCounter = 0;
    private int accountNumber;
    private decimal balance;
    private AccountType type;

    public BankAccount(decimal initialBalance, AccountType accountType)
    {
        accountNumber = ++accountCounter;
        balance = initialBalance;
        type = accountType;
    }

    public int GetAccountNumber() => accountNumber;
    public decimal GetBalance() => balance;
    public AccountType GetAccountType() => type;

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && balance >= amount)
        {
            balance -= amount;
            return true;
        }
        return false;
    }
}

class Program
{
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp1;
        return i + 1;
    }

    static int StringLength(string str)
    {
        int length = 0;
        foreach (char c in str)
            length++;
        return length;
    }

    static void PrintReverse(string str)
    {
        for (int i = str.Length - 1; i >= 0; i--)
            Console.Write(str[i]);
        Console.WriteLine();
    }

    static int CountWords(string str)
    {
        int count = 0;
        bool inWord = false;
        foreach (char c in str)
        {
            if (char.IsWhiteSpace(c))
                inWord = false;
            else if (!inWord)
            {
                inWord = true;
                count++;
            }
        }
        return count;
    }

    static bool CompareStrings(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return false;
        for (int i = 0; i < str1.Length; i++)
            if (str1[i] != str2[i])
                return false;
        return true;
    }

    static void CountCharacters(string str)
    {
        int alphabets = 0, digits = 0, special = 0;
        foreach (char c in str)
        {
            if (char.IsLetter(c))
                alphabets++;
            else if (char.IsDigit(c))
                digits++;
            else
                special++;
        }
        Console.WriteLine($"Alphabets: {alphabets}, Digits: {digits}, Special: {special}");
    }

    static string CopyString(string source)
    {
        char[] destination = new char[source.Length];
        for (int i = 0; i < source.Length; i++)
            destination[i] = source[i];
        return new string(destination);
    }

    static void CountVowelsConsonants(string str)
    {
        int vowels = 0, consonants = 0;
        string vowelsStr = "aeiouAEIOU";
        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                if (vowelsStr.Contains(c))
                    vowels++;
                else
                    consonants++;
            }
        }
        Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}");
    }

    static void SortStringArray(string[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (string.Compare(arr[j], arr[j + 1]) > 0)
                {
                    string temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }

    static void Main()
    {
        BankAccount account = new BankAccount(1000, AccountType.Current);
        Console.WriteLine($"Account Number: {account.GetAccountNumber()}");
        Console.WriteLine($"Balance: {account.GetBalance()}");
        Console.WriteLine($"Account Type: {account.GetAccountType()}");

        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        BubbleSort(arr);
        Console.WriteLine("Bubble Sort:");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();

        int[] arr2 = { 64, 34, 25, 12, 22, 11, 90 };
        QuickSort(arr2, 0, arr2.Length - 1);
        Console.WriteLine("Quick Sort:");
        foreach (int num in arr2)
            Console.Write(num + " ");
        Console.WriteLine();

        string testString = "Hello World!";
        Console.WriteLine($"String Length: {StringLength(testString)}");
        Console.Write("Reverse String: ");
        PrintReverse(testString);
        Console.WriteLine($"Word Count: {CountWords(testString)}");
        Console.WriteLine($"String Comparison: {CompareStrings("Hello", "Hello")}");
        CountCharacters(testString);
        Console.WriteLine($"Copied String: {CopyString(testString)}");
        CountVowelsConsonants(testString);

        string[] stringArray = { "banana", "apple", "orange", "grape" };
        SortStringArray(stringArray);
        Console.WriteLine("Sorted String Array:");
        foreach (string str in stringArray)
            Console.Write(str + " ");
        Console.WriteLine();
    }
}
