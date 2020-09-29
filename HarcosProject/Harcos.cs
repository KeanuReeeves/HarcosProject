using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProject
{
    class Harcos
    {
        string nev;
        int szint;
        int xp;
        int hp;
        int alapHp;
        int alapDMG;

        public Harcos(string nev,int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.xp = 0;
            switch (statuszSablon)
            {
                case 1: this.alapHp = 15; this.alapDMG = 3;break;
                case 2: this.alapHp = 12; this.alapDMG = 4; break;
                case 3: this.alapHp = 8; this.alapDMG = 5; break;
                default: this.alapHp = 15; this.alapDMG = 3; break;
            }
            this.hp = alapHp;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint;
            set 
            {
                if ()
                {

                }
            } 
        }
        public int Xp { get => xp;
            set 
            {
                if (value>SzintLepeshez)
                {
                    Szint++;
                    this.xp=value-SzintLepeshez;
                }

            } 
        }
        public int Hp { get => hp;
            set 
            {
                if (value==0)
                {
                    Xp = 0;
                }
                if (value > MaxHp)
                {
                    value = MaxHp;
                }
                if (value < 0)
                {
                    value = 0;
                }

                hp = value;
                
            } }

        public int AlapHp {get => alapHp;}
        public int AlapDMG { get => alapDMG;}
        public int Sebzes { get => alapDMG + szint;}
        public int SzintLepeshez { get => (10 + szint * 5);}
        public int MaxHp { get => alapHp + szint * 3;}
        public override string ToString()
        {
            string s = string.Format("{0}\tLVL:{6}\tEXP:{1}/{2}\tHP:{3}/{4}\tDMG:{5}",Nev,Xp,SzintLepeshez,Hp,MaxHp,Sebzes,Szint);
            return s;
        }
        public void Megkuzd(Harcos a, Harcos b)
        {
            if (a.Nev == b.Nev)
            {
                Console.WriteLine("Egy harcos sem harcol magával!");
            }
            else if (a.Hp == 0 || b.Hp == 0)
            {
                Console.WriteLine("Egyik harcosnak sem lehet a HP-ja 0!!!");
            }
            else 
            {
                b.Hp -= a.Sebzes;
                if (b.hp>0)
                {
                    a.Xp += 5;
                    b.Xp += 5;
                }
                else
                {
                    a.Xp += 10;
                }
            }
        }
        public void Gyogyul()
        {
            if (this.hp == 0)
            {
                hp = MaxHp;
            }
            else
            {
                hp += 3 + szint;
            }
        }

    }
}
