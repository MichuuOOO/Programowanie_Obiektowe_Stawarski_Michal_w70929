namespace Zad5
{
    public interface IPersonRepository
    {
        void SavePerson(Person person);
        List<Person> LoadPeople();     
    }
}