using System;
using System.Collections.Generic;
using System.Text;

namespace PudelkoLib
{
    public class SortByVolumeAndArea : Comparer<Pudelko>
    {
        //public int Compare(Pudelko p, Pudelko other)
        //{
        //}

        public override int Compare(Pudelko p, Pudelko other)
        {

            if (p == null)
            {
                if (other == null)
                    return 0;
                return -1;
            }
            else
            {
                if (other == null)
                {
                    return 1;
                }
                else
                {
                    if (p.Objetosc < other.Objetosc)
                    {
                        if (p.Pole == other.Pole)
                        {
                            return (p.A + p.B + p.C).CompareTo(other.A + other.B + other.C);
                        }
                        return (p.Pole).CompareTo(other.Pole);
                    }
                    else
                    {
                        return p.CompareTo(other);
                    }
                }
            }
        }
    }
}
