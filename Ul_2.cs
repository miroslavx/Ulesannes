using System;

class Program
{
    public static void Main(string[] args)
    {
        // Ülesanne 1: Juku vanus ja pilet
        Console.WriteLine("Tere tulemast!");
        Console.Write("Sisesta eesnimi: ");
        string eesnimi = Console.ReadLine();
        Console.WriteLine("Tere, " + eesnimi);
        
        if (eesnimi.ToLower() == "juku")
        {
            Console.Write("Sisesta Juku vanus: ");
            int vanus = int.Parse(Console.ReadLine());
            
            if (vanus < 0 || vanus > 100)
                Console.WriteLine("Vigased andmed!");
            else if (vanus < 6)
                Console.WriteLine("Tasuta pilet");
            else if (vanus <= 14)
                Console.WriteLine("Lastepilet");
            else if (vanus <= 65)
                Console.WriteLine("Täispilet");
            else
                Console.WriteLine("Sooduspilet");
        }
        else
        {
            Console.WriteLine("Täna mind kodus pole!");
        }

        // Ülesanne 2: Pinginaabrid
        Console.Write("Sisesta esimene nimi: ");
        string nimi1 = Console.ReadLine();
        Console.Write("Sisesta teine nimi: ");
        string nimi2 = Console.ReadLine();
        Console.WriteLine($"{nimi1} ja {nimi2} on täna pinginaabrid!");

        // Ülesanne 3: Põranda pindala
        Console.Write("Sisesta seina pikkus: ");
        double pikkus = double.Parse(Console.ReadLine());
        Console.Write("Sisesta seina laius: ");
        double laius = double.Parse(Console.ReadLine());
        double pindala = pikkus * laius;
        Console.WriteLine($"Põranda pindala: {pindala} m²");
        
        Console.Write("Kas soovid remonti teha (jah/ei)? ");
        if (Console.ReadLine().ToLower() == "jah")
        {
            Console.Write("Sisesta ruutmeetri hind: ");
            double hind = double.Parse(Console.ReadLine());
            Console.WriteLine($"Remondi hind: {pindala * hind}€");
        }

        // Ülesanne 4: Hinnasoodustus
        Console.Write("Sisesta soodushind: ");
        double soodushind = double.Parse(Console.ReadLine());
        Console.WriteLine($"Alghind: {soodushind / 0.7:0.00}€");

        // Ülesanne 5: Temperatuur
        Console.Write("Sisesta temperatuur: ");
        int temp = int.Parse(Console.ReadLine());
        Console.WriteLine(temp > 18 ? "Toasoojus on piisav" : "Toasoojus on liiga madal");

        // Ülesanne 6: Pikkus
        Console.Write("Sisesta pikkus (cm): ");
        int pikkusCm = int.Parse(Console.ReadLine());
        if (pikkusCm < 160) Console.WriteLine("Lühike");
        else if (pikkusCm <= 180) Console.WriteLine("Keskmine");
        else Console.WriteLine("Pikk");

        // Ülesanne 7: Pikkus ja sugu
        Console.Write("Sisesta sugu (m/n): ");
        char sugu = Console.ReadLine().ToLower()[0];
        Console.Write("Sisesta pikkus (cm): ");
        int pikkusSugu = int.Parse(Console.ReadLine());
        
        if (sugu == 'm')
        {
            if (pikkusSugu < 170) Console.WriteLine("Lühike mees");
            else if (pikkusSugu <= 190) Console.WriteLine("Keskmine mees");
            else Console.WriteLine("Pikk mees");
        }
        else
        {
            if (pikkusSugu < 160) Console.WriteLine("Lühike naine");
            else if (pikkusSugu <= 175) Console.WriteLine("Keskmine naine");
            else Console.WriteLine("Pikk naine");
        }

        // Ülesanne 8: Poekorv
        double summa = 0;
        Console.Write("Kas soovid piima (jah/ei)? ");
        if (Console.ReadLine().ToLower() == "jah") summa += 1.5;
        Console.Write("Kas soovid saia (jah/ei)? ");
        if (Console.ReadLine().ToLower() == "jah") summa += 0.8;
        Console.Write("Kas soovid leiba (jah/ei)? ");
        if (Console.ReadLine().ToLower() == "jah") summa += 1.2;
        Console.WriteLine($"Kokku ostude summa: {summa}€");
    }
}
