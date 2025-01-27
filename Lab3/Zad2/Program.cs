namespace Zad2
{
    class Program
    {
        static void Main()
        {
            var car1 = new Samochod("Bmw", "320d", "Sedan", "Czarny", 2024, 5000);
            var car2 = new Samochod("Audi", "RS3", "Hatchback", "Biały", 2007, 120000);
            var carPersonal = new SamochodOsobowy("BMW", "M4", "Coupe", "Czerwony", 2022, 7299, 2f, 3f, 4);

            car1.View();
            Console.WriteLine();
            car2.View();
            Console.WriteLine();
            carPersonal.View();
        }
    }
}