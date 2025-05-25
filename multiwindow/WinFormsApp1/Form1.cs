using System;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Rectangle rectangle;
        private TextBox dateTextBox;
        private Button calculateButton;
        private Label resultLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.Text = "Задания WinForms";
            this.Size = new Size(800, 600);
        }

        private void InitializeCustomComponents()
        {
            rectangle = new Rectangle(10, 10, this.ClientSize.Width - 20, this.ClientSize.Height - 20);

            dateTextBox = new TextBox
            {
                Location = new Point(20, 20),
                Size = new Size(200, 20),
                PlaceholderText = "Введите дату (dd.MM.yyyy)"
            };

            calculateButton = new Button
            {
                Location = new Point(230, 20),
                Size = new Size(100, 20),
                Text = "Рассчитать"
            };
            calculateButton.Click += CalculateButton_Click;

            resultLabel = new Label
            {
                Location = new Point(20, 50),
                Size = new Size(300, 20),
                Text = "Результат:"
            };

            this.Controls.AddRange(new Control[] { dateTextBox, calculateButton, resultLabel });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ShowResume();
        }

        private void ShowResume()
        {
            string[] resumeParts = new string[]
            {
                "Имя: Иван Иванов\nДолжность: Разработчик",
                "Опыт работы: 5 лет\nНавыки: C#, .NET, WinForms",
                "Образование: Высшее техническое\nЯзыки: Русский, Английский"
            };

            int totalChars = string.Join("", resumeParts).Length;
            double avgChars = (double)totalChars / resumeParts.Length;

            foreach (string part in resumeParts)
            {
                MessageBox.Show(part, "Резюме", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            MessageBox.Show("Конец резюме", $"Среднее количество символов: {avgChars:F0}", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dateTextBox.Text, out DateTime date))
            {
                resultLabel.Text = $"День недели: {date.ToString("dddd")}";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите дату в формате dd.MM.yyyy", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                string message = rectangle.Contains(e.Location) ? "Внутри прямоугольника" :
                               rectangle.IntersectsWith(new Rectangle(e.Location, new Size(1, 1))) ? "На границе" :
                               "Снаружи прямоугольника";
                MessageBox.Show(message, "Позиция мыши", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Text = $"Ширина = {this.ClientSize.Width}, Высота = {this.ClientSize.Height}";
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.Text = $"X: {e.X}, Y: {e.Y}";
        }

        private void StartNumberGuessingGame()
        {
            int min = 1;
            int max = 2000;
            int attempts = 0;
            int guess = (min + max) / 2;

            while (true)
            {
                attempts++;
                DialogResult result = MessageBox.Show(
                    $"Ваше число {guess}?",
                    "Угадывание числа",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(
                        $"Число угадано за {attempts} попыток!",
                        "Победа!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    result = MessageBox.Show(
                        "Хотите сыграть еще раз?",
                        "Новая игра",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        StartNumberGuessingGame();
                    }
                    break;
                }
                else
                {
                    result = MessageBox.Show(
                        "Ваше число больше?",
                        "Уточнение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        min = guess + 1;
                    }
                    else
                    {
                        max = guess - 1;
                    }
                    guess = (min + max) / 2;
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            StartNumberGuessingGame();
        }
    }
}
