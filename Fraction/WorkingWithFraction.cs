using System;
using System.Text;

namespace FractionTest
{
    class MainClass
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);

            Console.WriteLine("Input first fraction.");
            var fraction1 = GetFraction();

            Console.WriteLine("Input second fraction.");
            var fraction2 = GetFraction();

            Console.WriteLine("Fractions (irreducible):\n" + fraction1 + '\n' + fraction2 + '\n');

            // fraction1 + fraction2
            Console.WriteLine("Sum:\n(" + fraction1 + ") + (" + fraction2 + ") = " + (fraction1 + fraction2) + '\n');

            // fraction1 - fraction2
            Console.WriteLine("Difference:\n(" + fraction1 + ") - (" + fraction2 + ") = " + (fraction1 - fraction2));

            // fraction2 - fraction1
            Console.WriteLine("(" + fraction2 + ") - (" + fraction1 + ") = " + (fraction2 - fraction1) + '\n');

            // fraction1 * fraction2
            Console.WriteLine("Product:\n(" + fraction1 + ") * (" + fraction2 + ") = " + (fraction1 * fraction2) + '\n');

            // fraction1 / fraction2
            try
            {
                Console.WriteLine("Quotient:\n(" + fraction1 + ") / (" + fraction2 + ") = " + (fraction1/fraction2));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Quotient: Error: second fraction is 0!");
            }

            // fraction2 / fraction1
            try
            {
                Console.WriteLine("(" + fraction2 + ") / (" + fraction1 + ") = " + (fraction2/fraction1) + '\n');
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Quotient: Error: first fraction is 0!\n");
            }

            var relation = (fraction1.Equals(fraction2) ? " == " : " != ");
            Console.WriteLine("Equality: (" + fraction1 + ")" + relation + "(" + fraction2 + ")");

            switch (fraction1.CompareTo(fraction2))
            {
                case -1:
                    relation = " < ";
                    break;
                case 1:
                    relation = " > ";
                    break;
            }

            Console.WriteLine("More or less: (" + fraction1 + ")" + relation + "(" + fraction2 + ")");
            Console.WriteLine("\nCasted to int:\n(int)" + fraction1 + " = " + ((int)fraction1) + "\n(int)" + fraction2 + " = " + ((int)fraction2));
            Console.WriteLine("\nCasted to double:\n(double)" + fraction1 + " = " + ((double)fraction1) + "\n(double)" + fraction2 + " = " + ((double)fraction2));
            Console.WriteLine();

            Fraction[] arrayFractions;
            var rng = new Random();
            while (true)
            {
                try
                {
                    arrayFractions = new[]
                    {
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                        new Fraction(rng.Next(-100, 100), rng.Next(-100, 100)),
                    };

                    break;
                }
                catch (DivideByZeroException)
                {
                    // In case if one of the fractions in array would have 0 as denominator.
                }
            }
            Console.WriteLine("Array of random fractions (unsorted): ");
            foreach (var fraction in arrayFractions)
                Console.Write(fraction + " | ");

            Console.WriteLine();

            Array.Sort(arrayFractions);
            Console.WriteLine("Array of random fractions (sorted): ");
            foreach (var fraction in arrayFractions)
                Console.Write(fraction + " | ");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press any to exit.");
            Console.WriteLine();

            Console.ReadKey();
        }

        static Fraction GetFraction()
        {
            Console.Write("Input numerator: ");
            int numerator;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out numerator))
                    break;

                Console.Write("Wrong input, try again: ");
            }
            Console.Write("Input denominator: ");

            while (true)
            {
                int denominator;
                var input = Console.ReadLine();
                if (int.TryParse(input, out denominator))
                {
                    try
                    {
                        return new Fraction(numerator, denominator);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Wrong input, denominator can not be 0!\n" +
                                          "Try again: ");
                    }
                }
            }

        }

    }
}
