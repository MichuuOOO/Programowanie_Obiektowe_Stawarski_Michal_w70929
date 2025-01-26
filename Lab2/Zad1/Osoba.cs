using System;

class Osoba
{
    public string Imie { get; private set; }
    public string Nazwisko { get; private set; }
    public int Wiek { get; private set; }

    public Osoba(string imie, string nazwisko, int wiek)
    {
        if (imie.Length < 2)
            throw new ArgumentException("Imię musi mieć co najmniej 2 znaki.");
        if (nazwisko.Length < 2)
            throw new ArgumentException("Nazwisko musi mieć co najmniej 2 znaki.");
        if (wiek <= 0)
            throw new ArgumentException("Wiek musi być liczbą dodatnią.");

        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {Imie}, Nazwisko: {Nazwisko}, Wiek: {Wiek}");
    }
}
