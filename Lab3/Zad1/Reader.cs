namespace Zad1
{
    public class Reader(string firstName, string lastName, int age) : Person(firstName, lastName, age)
    {
        protected List<Book> BooksRead { get; private set; } = [];

        public void AddBook(Book book)
        {
            BooksRead.Add(book);
        }

        public void ViewBook()
        {
            Console.WriteLine($"Książki przeczytane przez {GetFullName()}:");
            foreach (var book in BooksRead)
            {
                book.View();
                Console.WriteLine();
            }
        }

        public override void View()
        {
            base.View();
            ViewBook();
        }
    }
}
