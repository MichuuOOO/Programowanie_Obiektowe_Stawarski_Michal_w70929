using Zad5;

class Program
{
    static void Main()
    {
        IPersonRepository repo = new FilePersonRepository();

        while (true)
        {
            Console.WriteLine("Lista osób");
            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Dodaj osobę");
            Console.WriteLine("2. Wyświetl wszystkie osoby");
            Console.WriteLine("3. Wyjście");
            Console.Write("Wybierz opcję: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj imię: ");
                    string name = Console.ReadLine();

                    Console.Write("Podaj wiek: ");
                    int age;
                    while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                        Console.Write("Niepoprawny wiek. Podaj ponownie: ");

                    Console.Write("Podaj e-mail: ");
                    string email = Console.ReadLine();

                    repo.SavePerson(new Person(name: name, age, email: email));
                    Console.WriteLine("Osoba dodana!");
                    break;

                case "2":
                    List<Person> people = repo.LoadPeople();
                    if (people.Count == 0)
                        Console.WriteLine("Brak zapisanych osób.");
                    else
                    {
                        Console.WriteLine("\n Lista osób:");
                        foreach (var person in people)
                            Console.WriteLine($" {person.Name}, {person.Age} lat,  {person.Email}");
                    }
                    break;

                case "3":
                    Console.WriteLine(" Koniec programu!");
                    return;

                default:
                    Console.WriteLine(" Niepoprawny wybór!");
                    break;
            }
        }
    }
}