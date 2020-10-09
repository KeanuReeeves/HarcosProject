using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProject
{
    class Program
    {
        private static List<Harcos> harcosok = new List<Harcos>();
        private static Harcos h;
        public void olvas(List<Harcos>h)
        {
            h = new List<Harcos>();
            StreamReader r = new StreamReader("harcosok.csv");
            string sor = r.ReadLine();
            while (!r.EndOfStream)
            {
                
                string[] st = sor.Split(';');
                h.Add(new Harcos(st[0], Convert.ToInt32(st[1])));
                sor = r.ReadLine();
            }
        }
        private static void Jatekos()
        {
            string s="";
            
            do
            {
                Console.WriteLine("Kérem adja meg a harcos nevét és státusz sablonját (;-vel elválasztva, a statusz sablon 1,2,3 lehet)");
                s = Console.ReadLine();
                string[] st = s.Split(';');
                h = new Harcos(st[0], Convert.ToInt32(st[1]));
            } 
            while (s.Split(';').Length!=2);
            
        }
        private static void Jatek()
        {
            Jatekos();
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine((i+1)+" "+harcosok[i]);
            }
            Console.WriteLine("\n"+h);
        }
        static void Main(string[] args)
        {
            
            harcosok.Add(new Harcos("Tök Ödön", 1));
            harcosok.Add(new Harcos("Pisi Misi", 2));
            harcosok.Add(new Harcos("Fütty Imre", 3));
            Jatek();

            Console.ReadKey();
        }
    }
}
