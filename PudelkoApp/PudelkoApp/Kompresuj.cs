using PudelkoLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PudelkoAppExtenshions
{
    public static class MyExtenshionMethods
    {
        public static Pudelko Kompresuj(this Pudelko p)
        {
            double a = Math.Cbrt(p.Objetosc);
            return new Pudelko(a, a, a);
        }

    }
}
