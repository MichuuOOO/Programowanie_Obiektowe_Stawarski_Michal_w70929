using System.Text.Json;

namespace Zad5
{
    public class FilePersonRepository : IPersonRepository
    {
        private readonly string filePath = "people.json";  

        public void SavePerson(Person person)
        {
            var people = LoadPeople();
            people.Add(person);
            File.WriteAllText(filePath, JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true }));
        }

        public List<Person> LoadPeople()
        {
            if (!File.Exists(filePath))
                return [];

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Person>>(json) ?? [];
        }
    }
}
