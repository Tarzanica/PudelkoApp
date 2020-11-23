using System;
using System.Collections.Generic;
using PudelkoLib;
using static PudelkoLib.Pudelko;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Pudelko> pudelka = new List<Pudelko>();

            pudelka.Add(new Pudelko(1, 2.1, 3.05, UnitOfMeasure.milimeter));
            pudelka.Add(new Pudelko(1, 3.05, 2.1));
            pudelka.Add(new Pudelko(2.1, 1, 3.05));
            pudelka.Add(new Pudelko(2100, 10000, 3050, UnitOfMeasure.milimeter));

            foreach (Pudelko pudelko in pudelka)
            {
                Console.WriteLine(pudelko);
            }

            if (pudelka[0].Objetosc < pudelka[1].Objetosc)
            {
                pudelka.Sort();
            }


            Console.WriteLine(pudelka[0].Equals(pudelka[2]));

            Console.WriteLine(pudelka[1].ToString("mm"));


            Console.WriteLine(pudelka[3].ToString());

            Console.WriteLine(pudelka[1].Equals(pudelka[3]));

        }
    }
}
