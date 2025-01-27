namespace Zad1
{
    public class AdventureBook(string title, Person author, DateTime releaseDate, string setting) : Book(title, author, releaseDate)
    {
        public string Setting { get; private set; } = setting;
    }
}
