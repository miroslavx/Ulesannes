using System;

class Startclass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Tere tulemast!");
        
        Console.Write("Sisestage oma nimi: ");
        string eesnimi = Console.ReadLine();
        
        Console.WriteLine("Tere, " + eesnimi);
        
        Console.Write("Sisestage esimene arv: ");
        int arv1 = int.Parse(Console.ReadLine());
        
        Console.Write("Sisestage teine arv: ");
        int arv2 = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Arvude {0} ja {1} korrutis võrdub {2}", arv1, arv2, arv1 * arv2);
        
        Console.WriteLine("Vajutage Enter klahvi väljumiseks...");
        Console.ReadLine();
    }
}
