using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Publications
{
    public enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }

    public class Person
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Person()
        {
            firstName = "Default";
            lastName = "Person";
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }

        public virtual bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person other = (Person)obj;
            return firstName == other.firstName && lastName == other.lastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstName, lastName);
        }

        public virtual object DeepCopy()
        {
            return new Person(firstName, lastName);
        }

        public static bool operator ==(Person left, Person right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
    }

    public interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }

    public class Article : IRateAndCopy
    {
        public Person Author { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        public Article(Person author, string title, double rating)
        {
            Author = author;
            Title = title;
            Rating = rating;
        }

        public Article()
        {
            Author = new Person();
            Title = "Default Title";
            Rating = 0.0;
        }

        public override string ToString()
        {
            return $"Author: {Author}, Title: {Title}, Rating: {Rating}";
        }

        public virtual object DeepCopy()
        {
            return new Article((Person)Author.DeepCopy(), Title, Rating);
        }
    }

    public class Edition
    {
        protected string Title;
        protected DateTime ReleaseDate;
        protected int Circulation;

        public Edition(string title, DateTime releaseDate, int circulation)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Circulation = circulation;
        }

        public Edition()
        {
            Title = "Default Edition";
            ReleaseDate = DateTime.Now;
            Circulation = 0;
        }

        public string EditionTitle
        {
            get { return Title; }
            set { Title = value; }
        }

        public DateTime PublishDate
        {
            get { return ReleaseDate; }
            set { ReleaseDate = value; }
        }

        public int CirculationCount
        {
            get { return Circulation; }
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("Тираж не может быть отрицательным");
                Circulation = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Edition(Title, ReleaseDate, Circulation);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Edition other = (Edition)obj;
            return Title == other.Title && 
                   ReleaseDate == other.ReleaseDate && 
                   Circulation == other.Circulation;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ReleaseDate, Circulation);
        }

        public static bool operator ==(Edition left, Edition right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        public static bool operator !=(Edition left, Edition right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Title: {Title}, Release Date: {ReleaseDate}, Circulation: {Circulation}";
        }
    }

    public class MagazineEnumerator : IEnumerator
    {
        private Magazine magazine;
        private int position = -1;
        private ArrayList articles;

        public MagazineEnumerator(Magazine magazine)
        {
            this.magazine = magazine;
            this.articles = new ArrayList();
            foreach (Article article in magazine.Articles)
            {
                if (!magazine.Editors.Contains(article.Author))
                {
                    articles.Add(article);
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < articles.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return articles[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public class Magazine : Edition, IRateAndCopy, IEnumerable
    {
        private Frequency frequency;
        private ArrayList editors;
        private ArrayList articles;

        public Magazine(string title, Frequency frequency, DateTime releaseDate, int circulation)
            : base(title, releaseDate, circulation)
        {
            this.frequency = frequency;
            editors = new ArrayList();
            articles = new ArrayList();
        }

        public Magazine() : this("Default Magazine", Frequency.Monthly, DateTime.Now, 0) { }

        public Frequency Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public ArrayList Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public ArrayList Editors
        {
            get { return editors; }
            set { editors = value; }
        }

        public double AverageRating
        {
            get
            {
                if (articles.Count == 0) return 0;
                double sum = 0;
                foreach (Article article in articles)
                {
                    sum += article.Rating;
                }
                return sum / articles.Count;
            }
        }

        public Edition EditionProperty
        {
            get { return new Edition(Title, ReleaseDate, Circulation); }
            set
            {
                Title = value.EditionTitle;
                ReleaseDate = value.PublishDate;
                Circulation = value.CirculationCount;
            }
        }

        public double Rating
        {
            get { return AverageRating; }
        }

        public bool this[Frequency fr]
        {
            get { return frequency == fr; }
        }

        public void AddArticles(params Article[] newArticles)
        {
            articles.AddRange(newArticles);
        }

        public void AddEditors(params Person[] newEditors)
        {
            editors.AddRange(newEditors);
        }

        public override object DeepCopy()
        {
            Magazine copy = new Magazine(Title, frequency, ReleaseDate, Circulation);
            foreach (Article article in articles)
            {
                copy.articles.Add(article.DeepCopy());
            }
            foreach (Person editor in editors)
            {
                copy.editors.Add(editor.DeepCopy());
            }
            return copy;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Frequency: {frequency}\nEditors: {string.Join(", ", editors.Cast<Person>())}\nArticles: {string.Join("\n", articles.Cast<Article>())}";
        }

        public virtual string ToShortString()
        {
            return $"{base.ToString()}, Frequency: {frequency}, Average Rating: {AverageRating}";
        }

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(this);
        }

        public IEnumerable ArticlesByEditor()
        {
            foreach (Article article in articles)
            {
                if (editors.Contains(article.Author))
                {
                    yield return article;
                }
            }
        }

        public IEnumerable EditorsWithoutArticles()
        {
            foreach (Person editor in editors)
            {
                bool hasArticle = false;
                foreach (Article article in articles)
                {
                    if (article.Author == editor)
                    {
                        hasArticle = true;
                        break;
                    }
                }
                if (!hasArticle)
                {
                    yield return editor;
                }
            }
        }

        public IEnumerable GetArticlesByRating(double rating)
        {
            foreach (Article article in articles)
            {
                if (article.Rating > rating)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetArticlesByString(string substring)
        {
            foreach (Article article in articles)
            {
                if (article.Title.Contains(substring))
                {
                    yield return article;
                }
            }
        }
    }

    public class CountAndSay
    {
        public static string GetNthTerm(int n)
        {
            if (n < 1 || n > 30)
                throw new ArgumentException("n должно быть от 1 до 30");

            string result = "1";
            for (int i = 1; i < n; i++)
            {
                result = GetNextTerm(result);
            }
            return result;
        }

        private static string GetNextTerm(string current)
        {
            string result = "";
            int count = 1;
            char currentDigit = current[0];

            for (int i = 1; i < current.Length; i++)
            {
                if (current[i] == currentDigit)
                {
                    count++;
                }
                else
                {
                    result += count.ToString() + currentDigit;
                    currentDigit = current[i];
                    count = 1;
                }
            }
            result += count.ToString() + currentDigit;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Тестирование задания 1.1 и 1.2 ===");

            // 1. Создание и вывод объекта Magazine
            Magazine magazine = new Magazine();
            Console.WriteLine("\n1. Краткая информация о журнале:");
            Console.WriteLine(magazine.ToShortString());

            // 2. Вывод значений индексатора
            Console.WriteLine("\n2. Значения индексатора:");
            Console.WriteLine($"Weekly: {magazine[Frequency.Weekly]}");
            Console.WriteLine($"Monthly: {magazine[Frequency.Monthly]}");
            Console.WriteLine($"Yearly: {magazine[Frequency.Yearly]}");

            // 3. Присвоение значений свойствам
            magazine.EditionTitle = "Научный журнал";
            magazine.Frequency = Frequency.Monthly;
            magazine.PublishDate = new DateTime(2024, 4, 13);
            magazine.CirculationCount = 1000;
            Console.WriteLine("\n3. Полная информация о журнале:");
            Console.WriteLine(magazine.ToString());

            // 4. Добавление статей
            Person author1 = new Person("Иван", "Иванов");
            Person author2 = new Person("Петр", "Петров");
            Article article1 = new Article(author1, "Статья 1", 4.5);
            Article article2 = new Article(author2, "Статья 2", 4.8);
            magazine.AddArticles(article1, article2);
            magazine.AddEditors(author1);
            Console.WriteLine("\n4. Информация о журнале после добавления статей:");
            Console.WriteLine(magazine.ToString());

            // 5. Тестирование массивов
            Console.WriteLine("\n5. Сравнение времени выполнения операций с массивами:");
            
            int size = 1000;
            Article[] articles = new Article[size];
            Article[,] articles2D = new Article[size/2, 2];
            Article[][] articlesJagged = new Article[size/2][];
            
            for (int i = 0; i < size; i++)
            {
                articles[i] = new Article();
            }

            for (int i = 0; i < size/2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    articles2D[i,j] = new Article();
                }
            }

            for (int i = 0; i < size/2; i++)
            {
                articlesJagged[i] = new Article[2];
                for (int j = 0; j < 2; j++)
                {
                    articlesJagged[i][j] = new Article();
                }
            }

            // Тестирование Edition
            Console.WriteLine("\n=== Тестирование Edition ===");
            Edition edition1 = new Edition("Test Edition", DateTime.Now, 100);
            Edition edition2 = new Edition("Test Edition", DateTime.Now, 100);
            
            Console.WriteLine("Сравнение объектов Edition:");
            Console.WriteLine($"edition1 == edition2: {edition1 == edition2}");
            Console.WriteLine($"HashCode edition1: {edition1.GetHashCode()}");
            Console.WriteLine($"HashCode edition2: {edition2.GetHashCode()}");

            // Тестирование исключения
            Console.WriteLine("\nТестирование исключения при отрицательном тираже:");
            try
            {
                edition1.CirculationCount = -1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Поймано исключение: {ex.Message}");
            }

            // Тестирование DeepCopy
            Console.WriteLine("\nТестирование DeepCopy:");
            Magazine magazineCopy = (Magazine)magazine.DeepCopy();
            magazine.EditionTitle = "Измененное название";
            Console.WriteLine("Оригинал после изменения:");
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine("Копия:");
            Console.WriteLine(magazineCopy.ToShortString());

            // Тестирование итераторов
            Console.WriteLine("\nСтатьи с рейтингом выше 4.6:");
            foreach (Article article in magazine.GetArticlesByRating(4.6))
            {
                Console.WriteLine(article);
            }

            Console.WriteLine("\nСтатьи, содержащие '1' в названии:");
            foreach (Article article in magazine.GetArticlesByString("1"))
            {
                Console.WriteLine(article);
            }

            Console.WriteLine("\nСтатьи, чьи авторы не являются редакторами:");
            foreach (Article article in magazine)
            {
                Console.WriteLine(article);
            }

            Console.WriteLine("\nСтатьи, чьи авторы являются редакторами:");
            foreach (Article article in magazine.ArticlesByEditor())
            {
                Console.WriteLine(article);
            }

            Console.WriteLine("\nРедакторы без статей:");
            foreach (Person editor in magazine.EditorsWithoutArticles())
            {
                Console.WriteLine(editor);
            }

            Console.WriteLine("\n=== Тестирование задания 2 (Посмотри-и-скажи) ===");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{i}-й член последовательности: {CountAndSay.GetNthTerm(i)}");
            }
        }
    }
}
