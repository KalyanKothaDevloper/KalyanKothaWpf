using System;

namespace NumberToWordConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number=1;
            string numberInWords;
            while (number > 0)
            {
                Console.WriteLine("Enter any Number/ Zero to exit : ");
                number = int.Parse(Console.ReadLine());
                numberInWords = ConvertNumberToWords(number);
                Console.WriteLine("Number in Words :  " + numberInWords);
            }

        }

        private static string ConvertNumberToWords(int number)
        {
            string[] unitsPlace = new string[] {"zero", "one","two","three","four","five","six",
                "seven","eight","nine","ten","eleven","twelve","thrirteen","fourteen",
                "fifteen","sixteen","seventeen","eighteen","ninteen"};

            string[] tensPlace = new string[] { "zero", "ten", "twenty", "thirty", "fourty", "fifty",
                "sixty", "seventy", "eighty", "ninty"};

            string numberInWords =string.Empty;

            if (number == 0) return "zero";
            if (number < 20)
            {
                return unitsPlace[number] + " ";
            }
            int i = number / 1000000;
            if (i>0)
            {
                numberInWords += ConvertNumberToWords(i) + " million ";
                number %= 1000000;
            }
            i = number / 1000;
            if (i > 0)
            {
                numberInWords += ConvertNumberToWords(i) + " thousand ";
                number %= 1000;
            }
            i = number / 100;
            if (i > 0)
            {
                numberInWords += ConvertNumberToWords(i) + " hundred ";
                number %= 100;
            }
            i = number / 10;
            if (i > 0)
            {
                if (!string.IsNullOrEmpty(numberInWords)) numberInWords += " and ";

                if (number < 20)
                {
                    numberInWords += unitsPlace[number] + " ";
                }
                else
                {
                    numberInWords += tensPlace[number / 10] + " ";

                    if (number % 10 > 0)
                        numberInWords += unitsPlace[number % 10] + " ";
                }
            }

            return numberInWords;
        }
    }
}
