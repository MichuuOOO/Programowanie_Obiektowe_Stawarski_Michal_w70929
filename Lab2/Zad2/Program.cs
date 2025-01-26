using Zad2;

var konto = new BankAccount("Robert Lewandowski", 5000);
konto.Wplata(300);
konto.Wyplata(100);
Console.WriteLine($"Saldo: {konto.Saldo}");