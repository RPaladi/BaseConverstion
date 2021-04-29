using System;
using System.Linq;

namespace BaseConverstion
{
    class Program
    {
        static readonly string base34 = "7ABCDE123FGHIJ456KLMNPQRSTUV89WXYZ";
       
        private static string ConvertToBase34(int number, string baseString = "")
        {
            if (string.IsNullOrEmpty(baseString))
                baseString = base34;

            string strValue = "";
            int baseLength = baseString.Length;
            while (number != 0)
            {
                int modValue = (int)(number % baseLength);
                number /= baseLength;
                strValue = baseString.Substring(modValue, 1) + strValue;
            }
            return strValue;
        }

        private static int ConvertToBase10(string base34String, string baseString = "")
        {
            if (string.IsNullOrEmpty(baseString))
                baseString = base34;

            int value = 0;
            int power = 1;
            foreach (char c in Enumerable.Reverse(base34String.ToCharArray()))
            {
                int basePosIndex = baseString.IndexOf(c);
                value += basePosIndex * power;
                power *= baseString.Length;
            }
            return value;
        }


        static void Main(string[] args)
        {
            int sequence = 1;
            string base34val = "7A";

            for (sequence = 1; sequence < 1300; sequence++)
            {                
                base34val = ConvertToBase34(sequence);
                Console.WriteLine($"\nSequence {sequence} was converted to {base34val}");

                if (base34val == "7A")  //7 is zero because it is at the zeroth index
                {
                    Console.WriteLine("Conflict.. ");
                    break;
                }

            }

            //sequence = 1;
            //base34val = ConvertToBase34(sequence);
            //Console.WriteLine($"\nSequence {sequence} was converted to {base34val}");

            //base34val = "777A";
            //int number = ConvertToBase10(base34val);
            //Console.WriteLine($"String {base34val} was converted to {number}");


            Console.ReadKey();
        }
    }
}
