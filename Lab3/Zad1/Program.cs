namespace Zad1
{
    class Program
    {
        static void Main()
        {
            var author1 = new Person("Henryk", "Sienkiewicz", 75);
            var author2 = new Person("Adam", "Mickiewicz", 59);
            var book1 = new AdventureBook("Krzyżacy", author1, new DateTime(1900, 1, 1), "Średniowieczna Polska");
            var book2 = new DocumentaryBook("Pan Tadeusz", author2, new DateTime(1834, 1, 1), "Szlachecka Litwa");

            var reader = new Reader("Janusz", "Palikot", 55);
            reader.AddBook(book1);
            reader.AddBook(book2);

            var reviewer = new Reviewer("Anna", "Nowak", 30);
            reviewer.AddBook(book1);
            reviewer.AddBook(book2);

            var people = new List<Person> { reader, reviewer };
            foreach (var person in people)
            {
                person.View();
                Console.WriteLine();
            }
        }
    }
}
