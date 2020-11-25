using System;
using System.Collections.Generic;
using PudelkoLib;
using static PudelkoLib.Pudelko;
using PudelkoAppExtenshions;

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
            pudelka.Add(new Pudelko(2.5, 9.321, 0.1));

            foreach (Pudelko pudelko in pudelka)
            {
                Console.WriteLine(pudelko);
            }

            pudelka.Sort(new SortByVolumeAndArea());


            Pudelko p1 = new Pudelko(11.0, 11.0, 10.0, UnitOfMeasure.centimeter);
            Console.WriteLine(p1);
            Console.WriteLine(p1.ToString());

            Console.WriteLine(pudelka[0].Equals(pudelka[2]));

            Console.WriteLine(pudelka[1].ToString("mm", null));


            Console.WriteLine(pudelka[3].ToString("cm", null));
            Console.WriteLine(pudelka[4].ToString("mm", null));

            Console.WriteLine(pudelka[1].Equals(pudelka[3]));

        }
    }
}
