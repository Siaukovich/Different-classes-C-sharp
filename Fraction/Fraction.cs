using System;

namespace FractionTest
{
    class Fraction : IEquatable<Fraction>, IComparable<Fraction>, IComparable
    {
        #region PROPERTIES
        private int Numerator { get; }
        private int Denomenator { get; }
        #endregion

        #region CONSTRUCTORS
        // Ctor that creates 1/1 fraction.
        public Fraction()
        {
            Numerator = Denomenator = 1;
        }

        // Ctor that creates pNumerator / pDenomenator fraction.
        public Fraction(int pNumerator, int pDenominator)
        {
            if (pDenominator == 0)
                throw new DivideByZeroException("Denominator can not be 0!");

            var gcd = Gcd(Math.Abs(pNumerator), Math.Abs(pDenominator));

            if (pDenominator < 0)
            {
                pNumerator *= -1;
                pDenominator *= -1;
            }

            Numerator = pNumerator / gcd;
            Denomenator = pDenominator / gcd;
        }
        #endregion

        #region OPERATORS_OVERLOAD
        // Addition of fractions.
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            var newDenomenator = f1.Denomenator * f2.Denomenator;
            var newNumerator   = f2.Denomenator * f1.Numerator + 
                                 f1.Denomenator * f2.Numerator;
          
            return new Fraction(newNumerator, newDenomenator);
        }

        // Substraction of fractions.
        // Add this fraction to negative other.
        public static Fraction operator -(Fraction f1, Fraction f2) => 
            f1 + new Fraction(f2.Numerator * -1, f2.Denomenator);

        // Product of fractions.
        public static Fraction operator *(Fraction f1, Fraction f2) => 
            new Fraction(f1.Numerator * f2.Numerator, f1.Denomenator * f2.Denomenator);

        // Quotient of fractions.
        // Reverse the second fraction and multiply.
        public static Fraction operator /(Fraction f1, Fraction f2) => 
            f1 * new Fraction(f2.Denomenator, f2.Numerator);
        #endregion

        #region COMPARISON _OPERATORS
        public static bool operator ==(Fraction f1, Fraction f2) =>
            ReferenceEquals(f1, null) ? ReferenceEquals(f2, null) : f1.Equals(f2);

        public static bool operator !=(Fraction f1, Fraction f2) => 
            !(f1 == f2);


        // Multiply both fractions in inequality by f1.Denomenator * f2.Denomenator.
        public static bool operator >(Fraction f1, Fraction f2) => 
            f1.Numerator * f2.Denomenator > f2.Numerator * f1.Denomenator;

        public static bool operator <(Fraction f1, Fraction f2) =>
            !(f1 > f2) && !(f1 == f2);
        #endregion

        #region OBJECTS_METHODS
        // Overrides the Object's three methods.
        public override string ToString()
        {
            if (Numerator == 0)
                return "0";

            if (Denomenator == 1)
                return Numerator.ToString();

            return $"{Numerator}/{Denomenator}";
        }

        public override bool Equals(object obj)
        {
            var f = obj as Fraction;
            
            return f != null && 
                this.Numerator   == f.Numerator && 
                this.Denomenator == f.Denomenator;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator * 397) ^ Denomenator;
            }
        }
        #endregion

        #region INTERFACES_IMPLEMENTATION
        // IComparable implementation.
        public int CompareTo(object obj)
        {
            if (!(obj is Fraction))
                throw new ArgumentException("Argument type should be Fraction");

            return CompareTo(obj as Fraction);
        }

        // IComparable<Fraction> implementation.
        public int CompareTo(Fraction other) =>
            (this < other) ? -1 :
            (this > other) ?  1 : 0;


        // IEquitable implementation.
        public bool Equals(Fraction other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return this.Numerator   == other.Numerator 
                && this.Denomenator == other.Denomenator;
        }
        #endregion

        #region CAST_OPERATORS
        // Cast operators overload.
        public static explicit operator int(Fraction f) => 
            f.Numerator / f.Denomenator;

        public static explicit operator double(Fraction f) => 
            Convert.ToDouble(f.Numerator) / f.Denomenator;
        #endregion

        #region OTHER
        // Greatest common divisior.
        private static int Gcd(int q, int r)
        {
            var max = q >= r ? q : r;
            var min = q < r ? q : r;

            while (true)
            {
                if (min == 0)
                    return max;

                var max1 = max;
                max = min;
                min = max1 % min;
            }
        }
        #endregion
    }
}