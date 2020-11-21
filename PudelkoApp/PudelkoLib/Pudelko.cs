using System;

namespace PudelkoLib
{
    public sealed class Pudelko
    {
        public enum UnitOfMeasure
        {
            meter,
            centimeter,
            milimeter
        }

        private UnitOfMeasure unit;
        private readonly double a;
        public double A => a;
        private readonly double b;
        public double B => b;
        private readonly double c;
        public double C => c;

        private double Convert(UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.milimeter) return 1000;

            if (unit == UnitOfMeasure.centimeter) return 100;

            return 1;
        }

        public Pudelko(double a = 0.1 , double b = 0.1 , double c = 0.1 , UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            double convert = Convert(unit);

            this.a = a / convert;
            this.b = b / convert;
            this.c = c / convert;
            this.unit = unit;

            if (this.a > 10 || this.b > 10 || this.c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (this.a < 0.001 || this.b < 0.001 || this.c < 0.001)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private string AddMeasure(UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.meter) return "m";
            if (unit == UnitOfMeasure.centimeter) return "cm";
            return "mm";
        }

        public override string ToString()
        {

            return $"{a:0.000}m \u00D7 {b:0.000}m \u00D7 {c:0.000}m";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "m":
                    return $"{a:0.000} \u00D7 {b:0.000}m \u00D7 {c:0.000}m";
                case "cm":
                    return $"{a:0.0}cm \u00D7 {b:0.0}cm \u00D7 {c:0.0}cm";
                case "mm":
                    return $"{a:0000}mm \u00D7 {b:0000}mm \u00D7 {c:0000}mm";
                default:
                    throw new FormatException();
            }
        }

        public double Objetosc => Math.Round((a * b * c), 9);

        public double Pole => Math.Round((2 * (a * b) + 4 * (b * c)), 6);







        public static implicit operator Pudelko((int a, int b, int c) v)
        {
            throw new NotImplementedException();
        }
    }
}
