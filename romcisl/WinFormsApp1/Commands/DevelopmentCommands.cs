using System;

namespace WinFormsApp1.Commands
{
    public class WriteCodeCommand : ICommand
    {
        private readonly string _feature;

        public WriteCodeCommand(string feature)
        {
            _feature = feature;
        }

        public void Execute()
        {
            Console.WriteLine($"Программист пишет код для функции: {_feature}");
        }

        public void Undo()
        {
            Console.WriteLine($"Программист отменяет изменения в коде для функции: {_feature}");
        }
    }

    public class TestCodeCommand : ICommand
    {
        private readonly string _feature;

        public TestCodeCommand(string feature)
        {
            _feature = feature;
        }

        public void Execute()
        {
            Console.WriteLine($"Тестировщик выполняет тестирование функции: {_feature}");
        }

        public void Undo()
        {
            Console.WriteLine($"Тестировщик отменяет результаты тестирования функции: {_feature}");
        }
    }

    public class MarketingCommand : ICommand
    {
        private readonly string _campaign;

        public MarketingCommand(string campaign)
        {
            _campaign = campaign;
        }

        public void Execute()
        {
            Console.WriteLine($"Маркетолог запускает рекламную кампанию: {_campaign}");
        }

        public void Undo()
        {
            Console.WriteLine($"Маркетолог отменяет рекламную кампанию: {_campaign}");
        }
    }
} 