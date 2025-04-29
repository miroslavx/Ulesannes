using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> maakonnad = new Dictionary<string, string>();
        Dictionary<string, string> pealinnad = new Dictionary<string, string>();
        maakonnad.Add("Harjumaa", "Tallinn");
        maakonnad.Add("Tartumaa", "Tartu");
        maakonnad.Add("Pärnumaa", "Pärnu");
        maakonnad.Add("Ida-Virumaa", "Jõhvi");
        maakonnad.Add("Lääne-Virumaa", "Rakvere");
        foreach (var paar in maakonnad)
        {
            pealinnad.Add(paar.Value, paar.Key);
        }
        
        bool jätka = true;
        
        while (jätka)
        {
            Console.WriteLine("\nVali tegevus:");
            Console.WriteLine("1 - Otsi maakonna järgi pealinna");
            Console.WriteLine("2 - Otsi pealinna järgi maakonda");
            Console.WriteLine("3 - Lisa uus maakond ja pealinn");
            Console.WriteLine("4 - Mängurežiim");
            Console.WriteLine("5 - Välju");
            string valik = Console.ReadLine();
            
            switch (valik)
            {
                case "1":
                    OtsiMaakonnaJärgi(maakonnad);
                    break;
                case "2":
                    OtsiPealinnaJärgi(pealinnad);
                    break;
                case "3":
                    LisaMaakond(maakonnad, pealinnad);
                    break;
                case "4":
                    Mängurežiim(maakonnad);
                    break;
                case "5":
                    jätka = false;
                    break;
                default:
                    Console.WriteLine("Tundmatu valik!");
                    break;}
    }
}

    static void OtsiMaakonnaJärgi(Dictionary<string, string> maakonnad)
    {
        Console.Write("Sisesta maakonna nimi: ");
        string maakond = Console.ReadLine();
        
        if (maakonnad.ContainsKey(maakond))
        {
            Console.WriteLine($"Maakonna {maakond} pealinn on {maakonnad[maakond]}");
        }
        else
        {
            Console.WriteLine($"Maakonda {maakond} ei leitud!");
        }
    }
    static void OtsiPealinnaJärgi(Dictionary<string, string> pealinnad)
    {
        Console.Write("Sisesta pealinna nimi: ");
        string pealinn = Console.ReadLine();
        
        if (pealinnad.ContainsKey(pealinn))
        {
            Console.WriteLine($"Linn {pealinn} on maakonna {pealinnad[pealinn]} pealinn");
        }
        else
        {
            Console.WriteLine($"Pealinna {pealinn} ei leitud!");
        }
    }
    static void LisaMaakond(Dictionary<string, string> maakonnad, Dictionary<string, string> pealinnad)
    {
        Console.Write("Sisesta maakonna nimi: ");
        string maakond = Console.ReadLine();
        
        Console.Write("Sisesta pealinna nimi: ");
        string pealinn = Console.ReadLine();
        if (!maakonnad.ContainsKey(maakond))
        {
            maakonnad.Add(maakond, pealinn);
            pealinnad.Add(pealinn, maakond);
            Console.WriteLine("Andmed lisatud!");
        }
        else
        {
            Console.WriteLine($"Maakond {maakond} on juba olemas!");
        }
    }
    
    static void Mängurežiim(Dictionary<string, string> maakonnad)
    {
        Console.WriteLine("Mängurežiim! Vastake küsimustele.");
        
        int õiged = 0;
        int katsed = 0;
        string[] maakondadeNimed = new string[maakonnad.Count];
        maakonnad.Keys.CopyTo(maakondadeNimed, 0);
        
        Random random = new Random();
        
        for (int i = 0; i < 5; i++)
        {
            int indeks = random.Next(maakondadeNimed.Length);
            string maakond = maakondadeNimed[indeks];
            Console.Write($"Mis on maakonna {maakond} pealinn? ");
            string vastus = Console.ReadLine();
            katsed++;
            
            if (vastus.ToLower() == maakonnad[maakond].ToLower())
            {
                Console.WriteLine("Õige vastus!");
                õiged++;
            }
            else
            {
                Console.WriteLine($"Vale vastus! Õige vastus on {maakonnad[maakond]}");
            }
        }
        double protsent = (double)õiged / katsed * 100;
        Console.WriteLine($"Sa said {õiged} õiget vastust {katsed}-st. Tulemus: {protsent}%");
    }
}
