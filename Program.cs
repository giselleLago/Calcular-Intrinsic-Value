using System;

namespace ConsoleApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Current Book Value: ");
            float cbv = float.Parse(Console.ReadLine());
            Console.WriteLine("Old Book Value: ");
            float obv = float.Parse(Console.ReadLine());
            Console.WriteLine("Years: ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Average Book Value change (%): " + AverageBookValuer(cbv, obv, y));
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Dividend: ");
            float div = float.Parse(Console.ReadLine());
            Console.WriteLine("Years (Comparing with Federal Note): ");
            double year = double.Parse(Console.ReadLine());
            Console.WriteLine("Federal Note(%): ");
            float fn = float.Parse(Console.ReadLine());
            Console.WriteLine("Intrinsic Value : " + IntrinsicValuer(div, cbv, AverageBookValuer(cbv, obv, y), year, fn));
            Console.ReadKey();
        }

        public static double AverageBookValuer(float currentBookValue, float oldBookValue, double years)
        {
            var currentOldRoot = Math.Pow((currentBookValue / oldBookValue), (1 / years));
            var averageBookVal = 100 * (currentOldRoot - 1);
            return averageBookVal;
        }

        public static double IntrinsicValuer(float dividend, float currentBookValue, double averageBookVal, double years, float federalNote)
        {
            var r = federalNote / 100;
            var perc = 1 + averageBookVal / 100;
            var bas = Math.Pow(perc, years);
            var extra = Math.Pow(1 + r, years);
            var intrinsicVal = dividend * (1 - (1 / extra)) / r + (currentBookValue * bas) / extra;
            return intrinsicVal;
        }   
    }
}
