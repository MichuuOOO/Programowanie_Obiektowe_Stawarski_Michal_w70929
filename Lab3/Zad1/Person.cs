namespace Zad1
{
    public class Person(string firstName, string lastName, int age)
    {
        private readonly string FirstName = firstName;
        private readonly string LastName = lastName;
        private readonly int Age = age;

        public virtual void View()
        {
            Console.WriteLine($"Osoba: {FirstName} {LastName}, Wiek: {Age}");
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
