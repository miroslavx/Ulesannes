using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    //  2 - Maakonnad ja peaalinnad 
    class MaakonnadJaPealinnad
    {
        private Dictionary<string, string> maakonnad;
        private Random random;

        public MaakonnadJaPealinnad()
        {
            maakonnad = new Dictionary<string, string>();
            random = new Random();
            maakonnad.Add("Harjumaa", "Tallinn");
            maakonnad.Add("Tartumaa", "Tartu");
            maakonnad.Add("Pärnumaa", "Pärnu");
            maakonnad.Add("Ida-Virumaa", "Jõhvi");
            maakonnad.Add("Lääne-Virumaa", "Rakvere");
        }

        public void AlgusMenu()
        {bool jätkame = true;
            
            while (jätkame)
            {
                Console.WriteLine("\nMaakonnad ja pealinnad programm");
                Console.WriteLine("1. Otsi pealinna maakonna järgi");
                Console.WriteLine("2. Otsi maakonda pealinna järgi");
                Console.WriteLine("3. Lisa uus maakond ja pealinn");
                Console.WriteLine("4. Mängi teadmiste testi");
                Console.WriteLine("5. Näita kõik maakonnad ja pealinnad");
                Console.WriteLine("0. Välju");
                
                Console.Write("\nVali tegevus: ");
                string valik = Console.ReadLine();
                
                switch (valik)
                {
                    case "1":
                        OtsiPealinnaMaakonna();
                        break;
                    case "2":
                        OtsiMaakondaPealinna();
                        break;
                    case "3":
                        LisaMaakondPealinn();
                        break;
                    case "4":
                        MängiTesti();
                        break;
                    case "5":
                        NäitaKõik();
                        break;
                    case "0":
                        jätkame = false;
                        break;
                    default:
                        Console.WriteLine("Vale valik, proovi uuesti!");
                        break;
                }
            }
        }

        private void OtsiPealinnaMaakonna()
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
                Console.Write("Kas soovid lisada selle maakonna? (jah/ei): ");
                if (Console.ReadLine().ToLower() == "jah")
                {
                    LisaMaakondPealinn(maakond);
                }
            }
        }

        private void OtsiMaakondaPealinna()
        {
            Console.Write("Sisesta pealinna nimi: ");
            string pealinn = Console.ReadLine();
            bool leitud = false;
            foreach (var paar in maakonnad)
            {
                if (paar.Value.Equals(pealinn, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Pealinn {pealinn} asub maakonnas {paar.Key}");
                    leitud = true;
                    break;
                }
            }
            if (!leitud)
            {
                Console.WriteLine($"Pealinna {pealinn} ei leitud!");
                Console.Write("Kas soovid lisada uue maakonna selle pealinnaga? (jah/ei): ");
                if (Console.ReadLine().ToLower() == "jah")
                {
                    Console.Write($"Sisesta maakonna nimi pealinnale {pealinn}: ");
                    string uusMaakond = Console.ReadLine();
                    maakonnad.Add(uusMaakond, pealinn);
                    Console.WriteLine("Maakond ja pealinn lisatud!");
                }
            }
        }

        private void LisaMaakondPealinn(string maakond = null)
        {
            if (maakond == null)
            {
                Console.Write("Sisesta maakonna nimi: ");
                maakond = Console.ReadLine();
            }
            
            if (!maakonnad.ContainsKey(maakond))
            {
                Console.Write($"Sisesta maakonna {maakond} pealinn: ");
                string pealinn = Console.ReadLine();
                maakonnad.Add(maakond, pealinn);
                Console.WriteLine("Maakond ja pealinn lisatud!");
            }
            else
            {
                Console.WriteLine($"Maakond {maakond} on juba olemas!");
            }
        }

        private void MängiTesti()
        {
            if (maakonnad.Count < 3)
            {
                Console.WriteLine("Mängimiseks on vaja vähemalt 3 maakonda!");
                return;
            }
            
            Console.WriteLine("\nTeadmiste test alustatud!");
            Console.WriteLine("Vastamiseks kirjuta vastus ja vajuta Enter. Lõpetamiseks kirjuta 'stopp'.");
            
            int küsimused = 0;
            int õigedVastused = 0;
            bool jätkame = true;
            
            while (jätkame && küsimused < 10) // Maksimum 10 küsimust
            {
                // Valik: 0 - küsi pealinna, 1 - küsi maakonda
                int küsimuseTüüp = random.Next(2);
                int juhuslikIndeks = random.Next(maakonnad.Count);
                var juhuslikPaar = maakonnad.ElementAt(juhuslikIndeks);
                
                if (küsimuseTüüp == 0)
                {
                    Console.Write($"\nMis on maakonna {juhuslikPaar.Key} pealinn? ");
                    string vastus = Console.ReadLine();
                    
                    if (vastus.ToLower() == "stopp")
                    {
                        jätkame = false;
                    }
                    else
                    {
                        küsimused++;
                        if (vastus.Equals(juhuslikPaar.Value, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Õige vastus!");
                            õigedVastused++;
                        }
                        else
                        {
                            Console.WriteLine($"Vale vastus. Õige vastus on {juhuslikPaar.Value}");
                        }
                    }
                }
                else
                {
                    Console.Write($"\nMillises maakonnas asub pealinn {juhuslikPaar.Value}? ");
                    string vastus = Console.ReadLine();
                    
                    if (vastus.ToLower() == "stopp")
                    {
                        jätkame = false;
                    }
                    else
                    {
                        küsimused++;
                        if (vastus.Equals(juhuslikPaar.Key, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Õige vastus!");
                            õigedVastused++;
                        }
                        else
                        {
                            Console.WriteLine($"Vale vastus. Õige vastus on {juhuslikPaar.Key}");
                        }
                    }
                }
            }
            
            if (küsimused > 0)
            {
                double protsentTulemus = (double)õigedVastused / küsimused * 100;
                Console.WriteLine($"\nTest lõpetatud! Tulemus: {õigedVastused}/{küsimused} ({protsentTulemus:F1}%)");
            }
        }
        private void NäitaKõik()
        {
            Console.WriteLine("\nKõik maakonnad ja pealinnad:");
            foreach (var paar in maakonnad)
            {
                Console.WriteLine($"{paar.Key} - {paar.Value}");
            }
        }
    }

    // Õpilased ja hinnete analüüs 
    class Õpilane
    {
        public string Nimi { get; set; }
        public List<int> Hinded { get; set; }

        public Õpilane(string nimi)
        {
            Nimi = nimi;
            Hinded = new List<int>();
        }

        public double KeskminneHinne()
        {
            if (Hinded.Count == 0)
                return 0;
                
            return (double)Hinded.Sum() / Hinded.Count;
        }
    }

    class ÕpilasedAnalüüs
    {
        private List<Õpilane> õpilased;

        public ÕpilasedAnalüüs()
        {
            õpilased = new List<Õpilane>();
        }

        public void LisaÕpilased()
        {
            //lisame 3 õpilast käsitsi
            Õpilane õpilane1 = new Õpilane("Mart");
            õpilane1.Hinded.Add(4);
            õpilane1.Hinded.Add(5);
            õpilane1.Hinded.Add(3);
            õpilane1.Hinded.Add(4);
            õpilased.Add(õpilane1);

            Õpilane õpilane2 = new Õpilane("Liisa");
            õpilane2.Hinded.Add(5);
            õpilane2.Hinded.Add(5);
            õpilane2.Hinded.Add(4);
            õpilased.Add(õpilane2);

            Õpilane õpilane3 = new Õpilane("Jaan");
            õpilane3.Hinded.Add(3);
            õpilane3.Hinded.Add(4);
            õpilane3.Hinded.Add(2);
            õpilane3.Hinded.Add(5);
            õpilane3.Hinded.Add(4);
            õpilased.Add(õpilane3);
        }

        public void LisaKasutajaÕpilased()
        {
            Console.Write("Mitu õpilast soovid lisada? ");
            int arv = int.Parse(Console.ReadLine());

            for (int i = 0; i < arv; i++)
            {
                Console.Write($"\nSisesta {i+1}. õpilase nimi: ");
                string nimi = Console.ReadLine();
                
                Õpilane uusÕpilane = new Õpilane(nimi);
                
                Console.Write("Mitu hinnet soovid lisada (3-5)? ");
                int hinnetearv = int.Parse(Console.ReadLine());
                
                for (int j = 0; j < hinnetearv; j++)
                {
                    Console.Write($"Sisesta {j+1}. hinne (1-5): ");
                    int hinne = int.Parse(Console.ReadLine());
                    
                    if (hinne >= 1 && hinne <= 5)
                    {
                        uusÕpilane.Hinded.Add(hinne);
                    }
                    else
                    {
                        Console.WriteLine("Hinne peab olema vahemikus 1-5. Proovi uuesti.");
                        j--;
                    }
                }
                
                õpilased.Add(uusÕpilane);
            }
        }

        public void ArvutaJaKuvaKeskmised()
        {
            Console.WriteLine("\nÕpilaste keskmised hinded:");
            
            foreach (var õpilane in õpilased)
            {
                double keskmine = õpilane.KeskminneHinne();
                Console.WriteLine($"{õpilane.Nimi}: {keskmine:F2}");
            }
        }

        public void LeiaParimKeskmine()
        {
            if (õpilased.Count == 0)
            {
                Console.WriteLine("Õpilasi pole lisatud!");
                return;
            }
            
            Õpilane parim = õpilased[0];
            double parimKeskmine = parim.KeskminneHinne();
            
            foreach (var õpilane in õpilased)
            {
                double keskmine = õpilane.KeskminneHinne();
                if (keskmine > parimKeskmine)
                {
                    parimKeskmine = keskmine;
                    parim = õpilane;
                }
            }
            
            Console.WriteLine($"\nParim keskmine hinne on {parimKeskmine:F2} õpilasel {parim.Nimi}");
        }

        //Sorteerimine keskmise hinde järgi
        public void SorteeriÕpilased(bool kasvavalt = true)
        {
            if (kasvavalt)
            {
                õpilased = õpilased.OrderBy(õ => õ.KeskminneHinne()).ToList();
            }
            else
            {
                õpilased = õpilased.OrderByDescending(õ => õ.KeskminneHinne()).ToList();
            }
            
            Console.WriteLine($"\nÕpilased on sorteeritud {(kasvavalt ? "kasvavalt" : "kahanevalt")} keskmise hinde järgi:");
            foreach (var õpilane in õpilased)
            {
                Console.WriteLine($"{õpilane.Nimi}: {õpilane.KeskminneHinne():F2}");
            }
        }
    }

    // 5  massiivi statistika
    class ArvudeStatistika
    {
        public double[] Tekstist_arvud()
        {
            Console.WriteLine("Sisesta arvud komaga eraldatud (näiteks: 5.5,3.2,7,10.3): ");
            string sisend = Console.ReadLine();
            
            string[] osad = sisend.Split(',');
            double[] arvud = new double[osad.Length];
            
            for (int i = 0; i < osad.Length; i++)
            {
                if (double.TryParse(osad[i].Trim(), out double arv))
                {
                    arvud[i] = arv;
                }
                else
                {
                    Console.WriteLine($"Viga: '{osad[i]}' ei ole korrektne number. Asendame 0-ga.");
                    arvud[i] = 0;
                }
            }
            
            return arvud;
        }
        public void ArvutaStatistika(double[] arvud)
        {
            if (arvud.Length == 0)
            {
                Console.WriteLine("Massiiv on tühi, statistikat ei saa arvutada!");
                return;
            }
            double maksimum = arvud[0];
            double miinimum = arvud[0];
            double summa = 0;
            
            foreach (double arv in arvud)
            {
                if (arv > maksimum)
                    maksimum = arv;
                    
                if (arv < miinimum)
                    miinimum = arv;
                    
                summa += arv;
            }
            
            double keskmine = summa / arvud.Length;
            int suuremadKuiKeskmine = 0;
            foreach (double arv in arvud)
            {
                if (arv > keskmine)
                    suuremadKuiKeskmine++;
            }
            
            Console.WriteLine("\nArvude statistika:");
            Console.WriteLine($"Maksimum: {maksimum}");
            Console.WriteLine($"Miinimum: {miinimum}");
            Console.WriteLine($"Summa: {summa}");
            Console.WriteLine($"Keskmine: {keskmine:F2}");
            Console.WriteLine($"Arve suuremad kui keskmine: {suuremadKuiKeskmine}");
            Array.Sort(arvud);
            Console.WriteLine("\nSorteeritud arvud:");
            foreach (double arv in arvud)
            {
                Console.Write($"{arv} ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valige ülesande number (2, 3 või 5):");
            string valik = Console.ReadLine();
            
            switch (valik)
            {
                case "2":
                    Console.WriteLine("Ülesanne 2: Maakonnad ja pealinnad");
                    MaakonnadJaPealinnad maakondadeProgramm = new MaakonnadJaPealinnad();
                    maakondadeProgramm.AlgusMenu();
                    break;
                    
                case "3":
                    Console.WriteLine("Ülesanne 3: Õpilased ja hinnete analüüs");
                    ÕpilasedAnalüüs õpilasedProgramm = new ÕpilasedAnalüüs();
                    
                    Console.Write("Kas soovid kasutada valmis näidisandmeid (jah/ei)? ");
                    string kasutaNäidist = Console.ReadLine().ToLower();
                    
                    if (kasutaNäidist == "jah")
                    {
                        õpilasedProgramm.LisaÕpilased();
                    }
                    else
                    {
                        õpilasedProgramm.LisaKasutajaÕpilased();
                    }
                    
                    õpilasedProgramm.ArvutaJaKuvaKeskmised();
                    õpilasedProgramm.LeiaParimKeskmine();
                    
                    Console.Write("\nKas soovid õpilasi sorteerida (jah/ei)? ");
                    if (Console.ReadLine().ToLower() == "jah")
                    {
                        Console.Write("Sorteeri kasvavalt (k) või kahanevalt (v)? ");
                        string sorteerimissuund = Console.ReadLine().ToLower();
                        
                        õpilasedProgramm.SorteeriÕpilased(sorteerimissuund != "v");
                    }
                    break;
                    
                case "5":
                    Console.WriteLine("Ülesanne 5: Arvude massiivi statistika");
                    ArvudeStatistika statistikaProgramm = new ArvudeStatistika();
                    double[] arvud = statistikaProgramm.Tekstist_arvud();
                    statistikaProgramm.ArvutaStatistika(arvud);
                    break;
                    
                default:
                    Console.WriteLine("Vale valik, palun valige 2, 3 või 5");
                    break;
            }
            
            Console.WriteLine("\nProgrammi lõpp, vajuta Enter klahvi lõpetamiseks");
            Console.ReadLine();
        }
    }
}
