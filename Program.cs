using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var account = new PaymentAccount(1000, 30, 100, 5);

            Console.WriteLine("Демонстрация сериализации с включенными вычисляемыми полями:");
            PaymentAccount.SerializeCalculatedFields = true;
            string jsonWithCalculated = account.ToJson();
            Console.WriteLine(jsonWithCalculated);
            File.WriteAllText("account_with_calculated.json", jsonWithCalculated);

            Console.WriteLine("\nДемонстрация сериализации с отключенными вычисляемыми полями:");
            PaymentAccount.SerializeCalculatedFields = false;
            string jsonWithoutCalculated = account.ToJson();
            Console.WriteLine(jsonWithoutCalculated);
            File.WriteAllText("account_without_calculated.json", jsonWithoutCalculated);

            Console.WriteLine("\nЧтение из файла:");
            string jsonFromFile = File.ReadAllText("account_with_calculated.json");
            var deserializedAccount = PaymentAccount.FromJson(jsonFromFile);

            Console.WriteLine($"Оплата за день: {deserializedAccount.DailyPayment}");
            Console.WriteLine($"Количество дней: {deserializedAccount.Days}");
            Console.WriteLine($"Штраф за день: {deserializedAccount.PenaltyPerDay}");
            Console.WriteLine($"Дни задержки: {deserializedAccount.DelayDays}");
            Console.WriteLine($"Сумма без штрафа: {deserializedAccount.TotalWithoutPenalty}");
            Console.WriteLine($"Сумма штрафа: {deserializedAccount.TotalPenalty}");
            Console.WriteLine($"Общая сумма к оплате: {deserializedAccount.TotalWithPenalty}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
