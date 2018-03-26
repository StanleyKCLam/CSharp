using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Hello", "Microsoft", "LINQ", "C#" };
            for (int i = 0; i < words.Count(); i++)
            {
                if (words[i].Length <= 5)
                    Console.WriteLine(words[i].ToString());
            }

            //LINQ
            var result = from word in words
                         where word.Length <= 5
                         select word;

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

            //Case2
            var customers = new[]
            {
                new {Name="Andy", Discount=5.0, City="Hong Kong"},
                new {Name="Brian", Discount=3.0, City="Taiwan"},
                new {Name="Candy", Discount=4.5, City="China"},
                new {Name="Doris", Discount=4.0, City="Hong Kong"},
             };

            var query = from cust in customers
                        where cust.Discount > 3
                        where cust.City == "Hong Kong"
                        orderby cust.Discount
                        select cust.Name;

            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
            {

            }

            Console.Read();
        }
    }
}
