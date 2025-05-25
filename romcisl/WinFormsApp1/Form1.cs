using System;
using System.Windows.Forms;
using WinFormsApp1.Commands;
using WinFormsApp1.RomanNumerals;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly ProjectManager _projectManager = new ProjectManager();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            var btnAddDeveloper = new Button
            {
                Text = "Добавить задачу разработчика",
                Location = new System.Drawing.Point(20, 20),
                Width = 200
            };
            btnAddDeveloper.Click += (s, e) =>
            {
                _projectManager.AddCommand(new WriteCodeCommand("Новая функция"));
            };

            var btnAddTester = new Button
            {
                Text = "Добавить задачу тестировщика",
                Location = new System.Drawing.Point(20, 60),
                Width = 200
            };
            btnAddTester.Click += (s, e) =>
            {
                _projectManager.AddCommand(new TestCodeCommand("Тестирование функции"));
            };

            var btnAddMarketer = new Button
            {
                Text = "Добавить задачу маркетолога",
                Location = new System.Drawing.Point(20, 100),
                Width = 200
            };
            btnAddMarketer.Click += (s, e) =>
            {
                _projectManager.AddCommand(new MarketingCommand("Новая кампания"));
            };

            var btnExecute = new Button
            {
                Text = "Выполнить все задачи",
                Location = new System.Drawing.Point(20, 140),
                Width = 200
            };
            btnExecute.Click += (s, e) =>
            {
                _projectManager.ExecuteCommands();
            };

            var btnUndo = new Button
            {
                Text = "Отменить последнюю задачу",
                Location = new System.Drawing.Point(20, 180),
                Width = 200
            };
            btnUndo.Click += (s, e) =>
            {
                _projectManager.UndoLastCommand();
            };
            var txtRoman = new TextBox
            {
                Location = new System.Drawing.Point(20, 240),
                Width = 100
            };

            var btnConvert = new Button
            {
                Text = "Конвертировать",
                Location = new System.Drawing.Point(130, 240),
                Width = 100
            };

            var lblResult = new Label
            {
                Location = new System.Drawing.Point(20, 280),
                Width = 200,
                Text = "Результат:"
            };

            btnConvert.Click += (s, e) =>
            {
                try
                {
                    var romanNumber = new RomanNumber(txtRoman.Text);
                    lblResult.Text = $"Результат: {romanNumber.Interpret()}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка ввода римского числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            Controls.AddRange(new Control[] { 
                btnAddDeveloper, btnAddTester, btnAddMarketer, 
                btnExecute, btnUndo, txtRoman, btnConvert, lblResult 
            });
        }
    }
}
