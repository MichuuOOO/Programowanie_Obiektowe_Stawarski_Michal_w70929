namespace Zad1
{
    public class Book(string title, Person author, DateTime releaseDate)
    {
        protected string Title { get; private set; } = title;
        protected Person Author { get; private set; } = author;
        protected DateTime ReleaseDate { get; private set; } = releaseDate;

        public void View()
        {
            Console.WriteLine($"Książka: {Title}, Autor: {Author.GetFullName()}, Data publikacji: {ReleaseDate.ToShortDateString()}");
        }

        public string GetTitle() => Title;
    }
}