﻿using System;
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
        public int Szint { get => szint; set => szint = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Hp { get => hp; set => hp = value; }

        public int AlapHp {get => alapHp;}
        public int AlapDMG { get => alapDMG;}
        public int Sebzes { get => alapDMG + szint;}
        public int SzintLepeshez { get => (10 + szint * 5) - xp;}
        public int MaxHp { get => alapHp + szint * 3;}
        public override string ToString()
        {
            return ;
        }

    }
}