using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IComparable<Pudelko>, IEnumerable<Pudelko>
    {
        public enum UnitOfMeasure
        {
            meter,
            centimeter,
            milimeter
        }

        private readonly UnitOfMeasure unit;
        private readonly double a;
        public double A => a;
        private readonly double b;
        public double B => b;
        private readonly double c;
        public double C => c;

        private double ConvertToMeter(double num)
        {
            if (unit == UnitOfMeasure.milimeter) return num / 1000;

            if (unit == UnitOfMeasure.centimeter) return num / 100;

            return num;
        }

        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.unit = unit;

            if (ConvertToMeter(this.a) > 10 || ConvertToMeter(this.b) > 10 || ConvertToMeter(this.c) > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (ConvertToMeter(this.a) < 0.001 || ConvertToMeter(this.b) < 0.001 || ConvertToMeter(this.c) < 0.001)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private string getUnitAbbreviation()
        {
            if (unit == UnitOfMeasure.meter) return "m";
            if (unit == UnitOfMeasure.centimeter) return "cm";
            return "mm";
        }
        public override string ToString()
        {

            return $"{ConvertToMeter(a):0.000}m \u00D7 {ConvertToMeter(b):0.000}m \u00D7 {ConvertToMeter(c):0.000}m";
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
        public string ToString(string format)
        {
            switch (format)
            {
                case "m":
                    return ToString();
                case "cm":
                    return $"{(ConvertToMeter(a) * 100):0.0}cm \u00D7 {(ConvertToMeter(b) * 100):0.0}cm \u00D7 {(ConvertToMeter(c) * 100):0.0}cm";
                case "mm":
                    return $"{(ConvertToMeter(a) * 1000):0}mm \u00D7 {(ConvertToMeter(b) * 1000):0}mm \u00D7 {(ConvertToMeter(c) * 1000):0}mm";
                default:
                    throw new FormatException();
            }
        }

        public double Objetosc => Math.Round((ConvertToMeter(a) * ConvertToMeter(b) * ConvertToMeter(c)), 9);
        public double Pole => Math.Round((2 * (ConvertToMeter(a) * ConvertToMeter(b)) + 2 * (ConvertToMeter(b) * ConvertToMeter(c)) + 2 * (ConvertToMeter(a) * ConvertToMeter(c))), 6);

        public bool Equals(Pudelko other)
        {
            double a1 = ConvertToMeter(a);
            double b1 = ConvertToMeter(b);
            double c1 = ConvertToMeter(c);

            double a2 = ConvertToMeter(other.A);
            double b2 = ConvertToMeter(other.B);
            double c2 = ConvertToMeter(other.C);

            if (a1 == a2 || a1 == b2 || a1 == c2)
                if (b1 == b2 || b1 == c2 || b1 == a2)
                    if (c1 == a2 || c1 == b2 || c1 == c2) return true;
            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pudelko pudelkoObj = obj as Pudelko;
            if (pudelkoObj == null) return false;
            return Equals(pudelkoObj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 17;
        }

        public int CompareTo(Pudelko other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            return !p1.Equals(p2);
        }

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double a1 = p1.ConvertToMeter(p1.A);
            double b1 = p1.ConvertToMeter(p1.B);
            double c1 = p1.ConvertToMeter(p1.C);

            double a2 = p2.ConvertToMeter(p2.A);
            double b2 = p2.ConvertToMeter(p2.B);
            double c2 = p2.ConvertToMeter(p2.C);

            double min1 = Math.Min(Math.Min(a1, b1), c1);
            double min2 = Math.Min(Math.Min(a2, b2), c2);

            double size1 = min1 + min2;

            double max1 = Math.Max(Math.Max(a1, b1), c1);
            double max2 = Math.Max(Math.Max(a2, b2), c2);

            double size2 = Math.Max(max1, max2);

            double mediumSize1;
            if (a1 == min1)
            {
                mediumSize1 = Math.Min(b1, c1);
            }
            else if (b1 == min1)
            {
                mediumSize1 = Math.Min(a1, c1);
            }
            else
            {
                mediumSize1 = Math.Min(a1, b1);
            }

            double mediumSize2;
            if (a2 == min2)
            {
                mediumSize2 = Math.Min(b2, c2);
            }
            else if (b2 == min2)
            {
                mediumSize2 = Math.Min(a2, c2);
            }
            else
            {
                mediumSize2 = Math.Min(a2, b2);
            }

            double size3 = Math.Max(mediumSize1, mediumSize2);

            return new Pudelko(size1, size2, size3);
        }

        public static explicit operator double[](Pudelko p)
        {
            double[] tab = new double[3];
            tab[0] = p.a;
            tab[1] = p.b;
            tab[2] = p.c;
            return tab;
        }
        public static implicit operator Pudelko(ValueTuple<int, int, int> v)
        {
            Pudelko p = new Pudelko(v.Item1, v.Item1, v.Item3, Pudelko.UnitOfMeasure.milimeter);
            return p;
        }

        public double this[int indexer]
        {
            get
            {
                var tab = (double[])this;
                return tab[indexer];
            }
        }

        private List<Pudelko> pudelka = new List<Pudelko>();
        public IEnumerator<Pudelko> GetEnumerator()
        {
            foreach (Pudelko x in pudelka)
            {
                yield return x.A;
                yield return x.B;
                yield return x.C;
            }
        }
        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

    }
}
