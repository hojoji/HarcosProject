using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Harcos h = new Harcos("harcos1", 1);
            Harcos h2 = new Harcos("harcos2", 2);
            Console.WriteLine(h);
            Console.WriteLine(h2);
            Console.WriteLine();
            h.Megkuzd(h2);
            Console.WriteLine(h);
            Console.WriteLine(h2);

            Console.WriteLine();
            h.Megkuzd(h2);
            Console.WriteLine(h);
            Console.WriteLine(h2);
            Console.WriteLine();
            h.Megkuzd(h2);
            Console.WriteLine(h);
            Console.WriteLine(h2);
            Console.WriteLine();
            h.Megkuzd(h2);


            Console.WriteLine(h);
            Console.WriteLine(h2);
            


            Console.ReadLine();

        }
    }
}
