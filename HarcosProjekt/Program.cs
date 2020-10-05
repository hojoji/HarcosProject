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
        public static Harcos h1 = new Harcos("Kristóf", 1);
        public static Harcos h2 = new Harcos("Levi", 2);
        public static Harcos h3 = new Harcos("Márk", 3);
        static Random r = new Random();


        public static void listaFeltoltese()
        {
            harcosLista.Add(h1);
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

            //foreach (Harcos h in harcosLista)
            //{
            //    Console.WriteLine(h);
            //}

        }


        static void Main(string[] args)
        {

            listaFeltoltese();

            //Karakter Létrehozása
            Console.Write("Adja meg a harcosa nevét:\t");
            string nev = Console.ReadLine();
            Console.Write("Státuszsablon száma (1/2/3):\t");
            int sablon = Convert.ToInt32(Console.ReadLine());
            Harcos felhasznalo = new Harcos(nev, sablon);


            string menu;
            int korSzamlalo = 1;
            do
            {
                //Saját karakter kiiratása
                Console.WriteLine(korSzamlalo+". Kör");
                Console.WriteLine("-> {0}\n", felhasznalo);
                //Ellenfelek kiiratása
                for (int i = 0; i < harcosLista.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, harcosLista[i]);
                }

                //menü

                do
                {
                    Console.WriteLine("Válasszon a menüpontok közül:\n(h)-harcol\n(g)-gyógyul\n(k)-kilép ");
                    menu = Console.ReadLine();
                } while (menu != "h" && menu != "g" && menu != "k");

                if (menu == "h")
                {
                    string index;
                    int indexInt = 0;
                    string hiba = "";
                    do
                    {
                        Console.WriteLine(hiba + " Hányas sorszámú ellenféllel szeretne megküzdeni?");
                        index = Console.ReadLine();

                        if (index.All(char.IsNumber))
                        {
                            indexInt = Int32.Parse(index);
                        }
                        else
                        {
                            hiba = "Egy számot adjon meg!";
                        }

                    } while (indexInt < 1 || indexInt > harcosLista.Count);

                    felhasznalo.Megkuzd(harcosLista[Convert.ToInt32(index) - 1]);
                }
                else if (menu == "g")
                {
                    felhasznalo.Gyogyul();
                }


                if (korSzamlalo % 3 == 0)
                {
                    int rnd = r.Next(0, harcosLista.Count);
                    Console.WriteLine("A karaktered megtámadták!\n{0} <---> {1}\n Eredmény: ", felhasznalo, harcosLista[rnd]);
                    harcosLista[rnd].Megkuzd(felhasznalo);
                    Console.ReadLine();
                    Console.WriteLine("{0}\n{1}\n [ENTER]: ", felhasznalo, harcosLista[rnd]);
                    Console.ReadLine();
                    foreach (Harcos h in harcosLista)
                    {
                        h.Gyogyul();
                    }
                }
                korSzamlalo++;
                Console.Clear();
            } while (menu != "k");

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





        }
    }
}
