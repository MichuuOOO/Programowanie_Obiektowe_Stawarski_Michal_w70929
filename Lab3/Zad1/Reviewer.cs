namespace Zad1
{
    public class Reviewer(string firstName, string lastName, int age) : Reader(firstName, lastName, age)
    {
        private static readonly Random random = new();

        public void ViewReviews()
        {
            Console.WriteLine($"Ocenione przez {GetFullName()}:");
            foreach (var book in BooksRead) 
            {
                Console.WriteLine($"- {book.GetTitle()}: {random.Next(1, 6)}/5");
            }
        }

        public override void View()
        {
            base.View();
            ViewReviews();
        }
    }
}
