using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
        public static List<Harcos> harcosLista = new List<Harcos>();
        public static Harcos h = new Harcos("harcos1", 1);
        public static Harcos h2 = new Harcos("harcos2", 2);
        public static Harcos h3 = new Harcos("harcos3", 3);
        public static void listaFeltoltese()
        {
            harcosLista.Add(h);
            harcosLista.Add(h2);
            harcosLista.Add(h3);

            StreamReader r = new StreamReader("harcosok 1.csv", Encoding.Default);

            try
            {

                while (!r.EndOfStream)
                {
                    string[] sor = r.ReadLine().Split(';');
                    Harcos h = new Harcos(sor[0], Int32.Parse(sor[1]));
                    harcosLista.Add(h);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("A fájlt nem sikerült beolvasni");
            }


            foreach (Harcos h in harcosLista)
            {
                Console.WriteLine(h);
            }

        }


        static void Main(string[] args)
        {

            listaFeltoltese();



            ////teszt
            //console.writeline(h);
            //console.writeline(h2);
            //console.writeline();
            //h.megkuzd(h2);
            //console.writeline(h);
            //console.writeline(h2);

            //console.writeline();
            //h.megkuzd(h2);
            //console.writeline(h);
            //console.writeline(h2);
            //console.writeline();
            //h.megkuzd(h2);
            //console.writeline(h);
            //console.writeline(h2);
            //console.writeline();
            //h.megkuzd(h2);


            //console.writeline(h);
            //console.writeline(h2);



            Console.ReadLine();

        }
    }
}
