using System;
using PudelkoLib;
using static PudelkoLib.Pudelko;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko P = new Pudelko(1, 2.1, 3.05, UnitOfMeasure.milimeter);
            Pudelko P2 = new Pudelko(1, 3.05, 2.1);
            Pudelko P3 = new Pudelko(2.1, 1, 3.05);
            Console.WriteLine(P.Equals(P2));

            Console.WriteLine(P.ToString("mm",null));

            Pudelko P4 = new Pudelko(2100, 10000, 3050, UnitOfMeasure.milimeter);

            Console.WriteLine(P4.ToString());

        }
    }
}
