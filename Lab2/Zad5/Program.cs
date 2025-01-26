using Zad5;
var sumator = new Sumator(new int[] { 1, 2, 3, 4, 5 });
Console.WriteLine($"Suma: {sumator.Suma()}");
Console.WriteLine($"Suma liczb podzielnych przez 2: {sumator.SumaPodziel2()}");
Console.WriteLine($"Ilość elementów: {sumator.IleElementow()}");
sumator.WypiszElementy();
sumator.WypiszZakres(1, 3);