using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MultiplyUtility
    {
        /// <summary>
        /// Returns Sum of Two Single Digit Strings
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private string MultiplySingleDigits(string p, string q)
        {
            return (Int32.Parse(p) * Int32.Parse(q)).ToString();
        }

        public string SumOfTwoStrings(string a  , string b)
        {
            int l1 = a.Length;
            int l2 = b.Length;

            var str1 = a.ToCharArray();
            var str2 = b.ToCharArray();

            string sumString = "";

            var carry = 0;

            while(l1 > 0 && l2 > 0)
            {
                var sum = (int)(Char.GetNumericValue(str1[l1 - 1]) + Char.GetNumericValue((str2[l2 - 1])) + carry);
                carry = 0;

                if(sum > 9)
                {
                    carry = sum / 10;
                    sum = sum % 10;
                }

                sumString = sum.ToString() + sumString;
                l1--;
                l2--;
            }

            if(l1 == 0 && l2 != 0 )
            {
                while (l2 > 0)
                {
                    var temp = (int)Char.GetNumericValue(b[l2-1]) + carry;
                    carry = 0;
                    if (temp > 9)
                    {
                        carry = temp / 10;
                        temp = temp % 10;
                    }

                    sumString = temp.ToString() + sumString;
                    l2--;
                }

            }

            if (l2 == 0 && l1 != 0)
            {
                while (l1 > 0)
                {
                    var temp = (int)Char.GetNumericValue(a[l1-1]) + carry;
                    carry = 0;
                    if (temp > 9)
                    {
                        carry = temp / 10;
                        temp = temp % 10;
                    }
                    l1--;
                    sumString = temp.ToString() + sumString;
                }


            }

            if (carry != 0)
            {
                sumString = carry.ToString() + sumString;
                carry = 0;
            }

            return sumString;

        }

        public string SubstractTwoStrings(string a, string b)
        {
            int l1 = a.Length;
            int l2 = b.Length;

            char[] str1 = new char[64];
            char[] str2 = new char[64];

            if (l1 > l2) {
                 str1 = a.ToCharArray();
                 str2 = b.ToCharArray();
            }

            if (l2 > l1)
            {
                str1 = b.ToCharArray();
                str2 = a.ToCharArray();
                var temp = l1;
                l1 = l2;
                l2 = temp;
            }

            if (l1 == l2)
            {
                var p = a.ToCharArray();
                var q = b.ToCharArray();
                for (int i=0; i <= l1 - 1; i++)
                {
                    if(p[i] > q[i])
                    {
                        str1 = p;
                        str2 = q;
                        break;
                    }
                    str1 = q;
                    str2 = p;
                }                
            }

            string subString = "";

            var carry = 0;

            while (l1 > 0 && l2 > 0)
            {
                int p = (int) Char.GetNumericValue(str1[l1 - 1]) ;
                int q = (int) Char.GetNumericValue(str2[l2 - 1]) ;
                
                if(p >= (q+carry))
                {
                    subString = (p - q - carry).ToString() + subString;
                    carry = 0;
                }
                else
                {
                    subString = (10 + p - q - carry).ToString() + subString;
                    carry = 1;
                }

                l1--;
                l2--;
            }

            if (l2 == 0)
            {
                while (l1 > 0)
                {
                    if((int)Char.GetNumericValue(str1[l1-1]) >= carry)
                    {
                        subString = ((int)Char.GetNumericValue(str1[l1 - 1]) - carry).ToString() + subString;
                        carry = 0;
                    }
                    else
                    {
                        subString = (10 + (int)Char.GetNumericValue(str1[l1 - 1]) - carry).ToString() + subString;
                        carry = 1;
                    }
                    l1--;
                }
            }

           
            return subString;

        }

        public string AppendZeros(int n , string str)
        {
            for(int i = 0; i < n; i++)
            {
                str = str + "0";
            }
            return str;
        }
        public string MultiplyTwoStrings(string num1, string num2)
        {

            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 == 0 || len2 == 0)
            {
                return "0";
            }

            if (len1 == 1 && len2 == 1)
            {
                return MultiplySingleDigits(num1, num2);
            }

            if (len1 < len2)
            {
                var temp = new StringBuilder(num1);
                for (int i = 0; i < len2 - len1; i++)
                {
                    temp = new StringBuilder("0").Append(temp);
                }
                num1 = temp.ToString();

                len1 = len2;
            }

            if (len1 > len2)
            {
                var temp = new StringBuilder(num2);
                for (int i = 0; i < len1 - len2; i++)
                {
                    temp = new StringBuilder("0").Append(temp);
                }
                num2 = temp.ToString();
                len2 = len1;

            }
            int fh = len1 / 2;
            int sh = len1 - fh;

            string num1fh = num1.Substring(0, len1 / 2);
            string num1lh = num1.Substring(len1 / 2 , (len1-(len1/2)));

            string num2fh = num2.Substring(0, len1 / 2);
            string num2lh = num2.Substring(len1 / 2 , (len1 - (len1/2)));

            string p1 = MultiplyTwoStrings(num1fh, num2fh);
            string p2 = MultiplyTwoStrings(num1lh, num2lh);

            string p3 = SubstractTwoStrings(MultiplyTwoStrings(SumOfTwoStrings(num1fh, num1lh), SumOfTwoStrings(num2fh, num2lh)) , SumOfTwoStrings(p1 , p2));

            var result = SumOfTwoStrings(SumOfTwoStrings(AppendZeros(2 * (sh), p1), AppendZeros(sh, p3)), p2);
            return result;

        }
    }
}
