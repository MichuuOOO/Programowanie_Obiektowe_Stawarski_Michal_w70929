namespace Zad1
{
    public class DocumentaryBook(string title, Person author, DateTime releaseDate, string subject) : Book(title, author, releaseDate)
    {
        public string Subject { get; private set; } = subject;
    }
}
