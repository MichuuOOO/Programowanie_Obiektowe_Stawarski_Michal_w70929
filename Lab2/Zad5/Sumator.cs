using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5
{
    internal class Sumator
    {
        private int[] Liczby;

        public Sumator(int[] liczby)
        {
            Liczby = liczby ?? throw new ArgumentNullException(nameof(liczby));
        }

        public int Suma()
        {
            int suma = 0;
            foreach (var liczba in Liczby)
            {
                suma += liczba;
            }
            return suma;
        }

        public int SumaPodziel2()
        {
            int suma = 0;
            foreach (var liczba in Liczby)
            {
                if (liczba % 2 == 0)
                    suma += liczba;
            }
            return suma;
        }

        public int IleElementow()
        {
            return Liczby.Length;
        }

        public void WypiszElementy()
        {
            Console.WriteLine(string.Join(", ", Liczby));
        }

        public void WypiszZakres(int lowIndex, int highIndex)
        {
            for (int i = Math.Max(0, lowIndex); i <= Math.Min(Liczby.Length - 1, highIndex); i++)
            {
                Console.Write(Liczby[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
