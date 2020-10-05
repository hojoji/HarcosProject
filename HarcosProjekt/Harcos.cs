using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;

        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;

            if (statuszSablon == 1)
            {
                this.alapEletero = 15;
                this.alapSebzes = 10;
            }
            else if (statuszSablon == 2)
            {
                this.alapEletero = 12;
                this.alapSebzes = 4;
            }
            else if (statuszSablon == 3)
            {
                this.alapEletero = 18;
                this.alapSebzes = 5;
            }
            this.eletero = this.MaxEletero();
        }

        public string Nev
        {
            get
            {
                return this.nev;
            }
            set
            {
                nev = value;
            }
        }
        public int Szint
        {
            get
            {
                return this.szint;
            }
            set
            {
                this.szint = value;
            }
        }
        public int Tapasztalat
        {
            get
            {
                return this.tapasztalat;
            }
            set
            {
                if (this.eletero <= 0)
                {
                    this.tapasztalat = 0;
                }
                else
                {
                    this.tapasztalat = value;
                }

                if (this.tapasztalat >= this.SzintLepeshez())
                {
                    this.tapasztalat -= this.SzintLepeshez();
                    this.szint++;
                    this.eletero = this.MaxEletero();
                }
            }
        }
        public int Eletero
        {
            get
            {
                return this.eletero;
            }
            set
            {
                if (this.eletero > this.MaxEletero())
                {
                    this.eletero = this.MaxEletero();
                }
                else
                {
                    this.eletero = value;
                }
                if (this.eletero<0)
                {
                    this.eletero = 0;
                }
            }
        }
        public int AlapEletero
        {
            get
            {
                return alapEletero;
            }
        }
        public int AlapSebzes
        {
            get
            {
                return alapSebzes;
            }
        }


        public int Sebzes()
        {
            return this.alapSebzes + this.szint;
        }
        public int SzintLepeshez()
        {
            return (this.szint * 5 + 10);
        }
        public int MaxEletero()
        {
            return this.alapEletero + this.szint * 3;
        }
        public void Megkuzd(Harcos masikHarcos)
        {
            if (this.nev.Equals(masikHarcos.nev))
            {
                Console.WriteLine("Hiba, a két harcos megegyezik");
                return;
            }
            else if (this.eletero == 0 || masikHarcos.eletero == 0)
            {
                Console.WriteLine("Az egyik harcos életereje 0, {0}: {1}, {2}: {3}", this.Nev, this.Eletero, masikHarcos.Nev, masikHarcos.Eletero);
                return;
            }
            else
            {
                masikHarcos.Eletero -= this.Sebzes();
                if (masikHarcos.eletero > 0)
                {
                    this.Eletero -= masikHarcos.Sebzes();
                    masikHarcos.Tapasztalat += 5;
                }
                else
                {
                    this.Tapasztalat += 10;
                }
                if (this.eletero > 0)
                {
                    this.Tapasztalat += 5;
                }
                else
                {
                    masikHarcos.Tapasztalat += 10;
                }
            }
        }

        public void Gyogyul()
        {
            if (this.Eletero <= 0)
            {
                this.Eletero = this.MaxEletero();
            }
            else
            {
                this.Eletero += 3 + this.Szint;
            }
        }




        public override string ToString()
        {
            return String.Format
                ("{0} - LVL: {1} - EXP: {2}/{3} - HP: {4}/{5} - DMG: {6}",
                this.nev, this.szint, this.tapasztalat, this.SzintLepeshez(),
                this.eletero, MaxEletero(), this.Sebzes());
        }


    }
}
