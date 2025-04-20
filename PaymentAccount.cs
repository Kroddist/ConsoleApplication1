using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PaymentAccount
{
    private double _dailyPayment;
    private int _days;
    private double _penaltyPerDay;
    private int _delayDays;

    public static bool SerializeCalculatedFields { get; set; } = true;

    public double DailyPayment
    {
        get => _dailyPayment;
        set
        {
            if (value < 0)
                throw new ArgumentException("Оплата за день не может быть отрицательной");
            _dailyPayment = value;
        }
    }

    public int Days
    {
        get => _days;
        set
        {
            if (value < 0)
                throw new ArgumentException("Количество дней не может быть отрицательным");
            _days = value;
        }
    }

    public double PenaltyPerDay
    {
        get => _penaltyPerDay;
        set
        {
            if (value < 0)
                throw new ArgumentException("Штраф за день не может быть отрицательным");
            _penaltyPerDay = value;
        }
    }

    public int DelayDays
    {
        get => _delayDays;
        set
        {
            if (value < 0)
                throw new ArgumentException("Количество дней задержки не может быть отрицательным");
            _delayDays = value;
        }
    }

    [JsonIgnore]
    public double TotalWithoutPenalty => DailyPayment * Days;

    [JsonIgnore]
    public double TotalPenalty => PenaltyPerDay * DelayDays;

    [JsonIgnore]
    public double TotalWithPenalty => TotalWithoutPenalty + TotalPenalty;

    public PaymentAccount(double dailyPayment, int days, double penaltyPerDay, int delayDays)
    {
        DailyPayment = dailyPayment;
        Days = days;
        PenaltyPerDay = penaltyPerDay;
        DelayDays = delayDays;
    }

    public string ToJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreReadOnlyProperties = !SerializeCalculatedFields
        };
        return JsonSerializer.Serialize(this, options);
    }

    public static PaymentAccount FromJson(string json)
    {
        return JsonSerializer.Deserialize<PaymentAccount>(json);
    }
} 