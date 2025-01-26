using System;

namespace Zad2
{
    internal class BankAccount
    {
        public string Wlasciciel { get; private set; }
        public decimal Saldo { get; private set; }

        public BankAccount(string wlasciciel, decimal poczatkoweSaldo)
        {
            Wlasciciel = wlasciciel;
            Saldo = poczatkoweSaldo > 0 ? poczatkoweSaldo : throw new ArgumentException("Saldo początkowe musi być większe od zera.");
        }

        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota wpłaty musi być dodatnia.");
            Saldo += kwota;
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota wypłaty musi być dodatnia.");
            if (kwota > Saldo)
                throw new InvalidOperationException("Niewystarczająca ilość środków.");
            Saldo -= kwota;
        }
    }
}
