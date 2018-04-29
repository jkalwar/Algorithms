using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    //The following program is the implementation of the Karatsuba algorithm for multiplying two 64 digit numbers
    /* X * Y = (10^n/2 * a + b )  * (10^n/2 * c + d)
     * (10^n/2 * a+b)(10^n/2 * c+d) = 10^n * ac + 10^n/2 (ad + bc) + bd
     * 
     * num1 = ab
     * num2 = cd
     * 
     * 1. Compute ac
     * 2. Compute bd
     * 3. Compute (a+b)(c+d) - ac - bd
     * 
     */
    public class Program
    {
       
        static void Main(string[] args)
        {
            string a = "3141592653589793238462643383279502884197169399375105820974944592";
            string b = "2718281828459045235360287471352662497757247093699959574966967627";

            MultiplyUtility obj = new MultiplyUtility();
            Console.WriteLine(obj.MultiplyTwoStrings(a, b));
            //Console.WriteLine(obj.MultiplyTwoStrings("95", "105"));
            Console.ReadLine();
        }
    }
}
