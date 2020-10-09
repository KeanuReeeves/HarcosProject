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
        private static Random r;
        private static int db=1;
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
        private static void Menu()
        {
            
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine((i + 1) + " " + harcosok[i]);
            }
            Console.WriteLine("\n" + h);
            Console.WriteLine("Menü\n" +
                              "1.Harc\n" +
                              "2.Gyógyulás\n" +
                              "3.Kilépés");
            ConsoleKey k = Console.ReadKey().Key;
            
            
            do
            {
                if (k == ConsoleKey.D1)
                {
                    int celpont;

                    Console.WriteLine("Adja meg a megtámadni kívánt harcos sorszámát");
                    celpont = Convert.ToInt32(Console.ReadLine());
                    if (celpont <= harcosok.Count)
                    {
                        h.Megkuzd(harcosok[celpont - 1]);
                        Console.Clear();
                        Menu();
                        db++;
                        
                    }
                    else
                    {
                        Console.WriteLine("Rossz számot adott meg");
                        Menu();
                    }





                }
                else if (k == ConsoleKey.D2)
                {
                    h.Gyogyul();
                    Console.Clear();
                    Menu();
                    db++;
                }
                else
                {
                    db++;
                }
                if (db%3==0)
                {
                    int Random = r.Next(0, harcosok.Count - 1);
                    harcosok[Random].Megkuzd(h);
                    foreach (var item in harcosok)
                    {
                        item.Gyogyul();
                    }
                }
                
                
            }
            while (k != ConsoleKey.D3);
            
        }
        static void Main(string[] args)
        {
            
            harcosok.Add(new Harcos("Tök Ödön", 1));
            harcosok.Add(new Harcos("Pisi Misi", 2));
            harcosok.Add(new Harcos("Fütty Imre", 3));
            Jatekos();
            Menu();

            Console.ReadKey();
        }
    }
}
