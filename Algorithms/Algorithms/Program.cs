using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    //The following program is the implementation of the Karatsuba algorithm for multiplying two 64 digit numbers
    /*
     * 
     */ 
    public class Program
    {
        static string MultiplySingleDigits(string p , string q)
        {
            return (Int32.Parse(p) * Int32.Parse(q) ).ToString();
        }
        static string MultiplyTwoStrings(string num1 , string num2)
        {

            int len1 = num1.Length;
            int len2 = num2.Length;

            if(len1 == 0 || len2 == 0)
            {
                return "0";
            }

            if (len1 == 1 && len2 == 1)
            {
                return MultiplySingleDigits(num1 , num2);
            }

            if (len1 < len2)
            {
                var temp  = new StringBuilder(num1);
                for (int i=0; i < len2-len1; i++)
                {
                    temp = new StringBuilder("0").Append(temp);
                }
                num1 = temp.ToString();
            }

            if (len1 > len2)
            {
                var temp = new StringBuilder(num2);
                for (int i = 0; i < len1 - len2; i++)
                {
                    temp = new StringBuilder("0").Append(temp);
                }
                num2 = temp.ToString();
            }



            return "0";

        }
        static void Main(string[] args)
        {
            string a = "3141592653589793238462643383279502884197169399375105820974944592";
            string b = "2718281828459045235360287471352662497757247093699959574966967627";
        }
    }
}
