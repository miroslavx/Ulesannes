using System;
using System.Collections.Generic;

namespace CSharpAssignments
{
    //1 Juhuslike arvude ruudud 
    class ArvuTöötlus
    {
        public int[] GenereeriRuudud(int min, int max)
        {
            Random random = new Random();
            int N = random.Next(-100, 101);
            int M = random.Next(-100, 101);
            int väiksem = Math.Min(N, M);
            int suurem = Math.Max(N, M);
            int[] ruudud = new int[suurem - väiksem + 1];
            int index = 0;
            for (int i = väiksem; i <= suurem; i++)
            {
                ruudud[index] = i * i;
                index++;
            }
            
            return ruudud;
        }
    }

    // 5: Arvamise mäng 
    class ArvamiseMäng
    {
        public void ArvaArv()
        {
            Random random = new Random();
            int arv = random.Next(1, 101); 
            int katse = 1; 
            bool onÕige = false;
            while (katse <= 5 && !onÕige)
            {
                Console.Write($"Katse {katse}/5. Sisesta arv: ");
                int pakkumine = int.Parse(Console.ReadLine());
                if (pakkumine < arv)
                {
                    Console.WriteLine("Liiga väike!");}
                else if (pakkumine > arv)
                {
                    Console.WriteLine("Liiga suur!");
                }
                else
                {
                    Console.WriteLine("Õige! Õnnitleme!");
                    onÕige = true;
                }
                katse++;
            }
            if (!onÕige)
            {
                Console.WriteLine($"Mäng läbi! Õige vastus oli {arv}.");
            }
            
            Console.Write("Kas soovid uuesti mängida? (jah/ei): ");
            string vastus = Console.ReadLine().ToLower();
            if (vastus == "jah")
            {
                ArvaArv();
            }
        }
    }

    // 7 korrutustabel 
    class Korrutustabel
    {
        public void GenereeriKorrutustabel(int ridadeArv, int veergudeArv)
        {
            for (int i = 1; i <= ridadeArv; i++)
            {
                for (int j = 1; j <= veergudeArv; j++)
                {
                    Console.Write("{0,5}", i * j); 
                }
                Console.WriteLine();
            }
        }
    }

    // 9 Arvude ruudud
    class ArvudeRuudud
    {
        public void RuududJaKahekordne()
        {
            int[] arvud = { 2, 4, 6, 8, 10, 12 };
            Console.WriteLine("Arvud ruudus (kasutades for):");
            for (int i = 0; i < arvud.Length; i++)
            {
                Console.WriteLine($"{arvud[i]} ruudus = {arvud[i] * arvud[i]}");
            }
            Console.WriteLine("\nKahekordne väärtus (kasutades foreach):");
            foreach (var arv in arvud)
            {
                Console.WriteLine($"{arv} kahekordne = {arv * 2}");
            }
            Console.WriteLine("\nArvude loendus, mis jaguvad 3-ga (kasutades while):");
            int loendur = 0;
            int indeks = 0;
            
            while (indeks < arvud.Length)
            {
                if (arvud[indeks] % 3 == 0)
                {
                    loendur++;
                }
                indeks++;
            }
            
            Console.WriteLine($"Arve, mis jaguvad 3-ga: {loendur}");
        }
    }

    //12 Kõige suurema arvu otsing 
    class SuurimArv
    {
        public void LeiaSuurim()
        {
            int[] numbrid = { 12, 56, 78, 2, 90, 43, 88, 67 };
            int suurim = numbrid[0];
            int suurimIndeks = 0;
            
            for (int i = 1; i < numbrid.Length; i++)
            {
                if (numbrid[i] > suurim)
                {
                    suurim = numbrid[i];
                    suurimIndeks = i;
                }
            }
            Console.WriteLine($"Suurim arv on {suurim}, mis asub indeksil {suurimIndeks}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valige ülesande number (1, 5, 7, 9 või 12):");
            int valik = int.Parse(Console.ReadLine());
            
            switch (valik)
            {case 1:
                    Console.WriteLine("Ülesanne 1: Juhuslike arvude ruudud");
                    ArvuTöötlus arvuTöötlus = new ArvuTöötlus();
                    int[] ruudud = arvuTöötlus.GenereeriRuudud(-100, 100);
                    int algIndeks = (int)Math.Sqrt(ruudud[0]);
                    if (algIndeks * algIndeks != ruudud[0])
                        algIndeks = -algIndeks;
                    for (int i = 0; i < ruudud.Length; i++)
                    {
                        int algArv = algIndeks + i;
                        Console.WriteLine($"{algArv} → {ruudud[i]}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Ülesanne 5: Arvamise mäng");
                    ArvamiseMäng mäng = new ArvamiseMäng();
                    mäng.ArvaArv();
                    break;
                case 7:
                    Console.WriteLine("Ülesanne 7: Korrutustabel");
                    Console.Write("Sisesta ridade arv: ");
                    int read = int.Parse(Console.ReadLine());
                    Console.Write("Sisesta veergude arv: ");
                    int veerud = int.Parse(Console.ReadLine());
                    
                    Korrutustabel tabel = new Korrutustabel();
                    tabel.GenereeriKorrutustabel(read, veerud);
                    break;
                case 9:
                    Console.WriteLine("Ülesanne 9: Arvude ruudud");
                    ArvudeRuudud arvudeRuudud = new ArvudeRuudud();
                    arvudeRuudud.RuududJaKahekordne();
                    break;
                case 12:
                    Console.WriteLine("Ülesanne 12: Kõige suurema arvu otsing");
                    SuurimArv suurimArv = new SuurimArv();
                    suurimArv.LeiaSuurim();
                    break;
                default:
                    Console.WriteLine("Vale valik, palun valige 1, 5, 7, 9 või 12");
                    break;
            }
            
            Console.WriteLine("\nProgrammi lõpp. Vajuta Enter klahvi lõpetamiseks...");
            Console.ReadLine();
        }
    }
}
