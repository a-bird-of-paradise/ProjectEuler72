using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler72
{
    class Program
    {

        static List<long>[] GetPrimeDivisors(int cap)
        {
            int i, j;
            List<long>[] Answer = new List<long>[cap + 1];

            for (i = 0; i <= cap; ++i)
            {
                Answer[i] = new List<long>();
            }

            for (i = 2; i <= cap; i++)
            {
                if (Answer[i].Count() == 0) // if i is prime...
                {
                    j = 2;
                    while (i * j <= cap)
                    {
                        Answer[i * j].Add(i);
                        j++;
                    }
                }
            }
            return Answer;
        }

        static void Main(string[] args)
        {
            const int max = 1000000;
            List<long>[] Divs = GetPrimeDivisors(max);

            long Totient;

            long accum = 0;

            for (int i = 1; i <= max; i++)
            {
                if (Divs[i].Count() == 0)
                {
                    Totient = i - 1;
                }
                else
                {
                    Totient = Divs[i].Select(x => x - 1).Aggregate((x, y) => x * y);
                    Totient *= i;
                    Totient /= Divs[i].Aggregate((x, y) => x * y);
                }
                accum += Totient;
            }
            Console.WriteLine(accum);
        }
    }
}
