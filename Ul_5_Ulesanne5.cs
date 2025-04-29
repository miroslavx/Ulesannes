using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sisesta arvud eraldatud tühikutega:");
        string input = Console.ReadLine();

        double[] arvud = Tekstist_arvud(input);

        if (arvud.Length == 0)
        {Console.WriteLine("Arvud ei sisestatud!");
            return;
        }
        double max = arvud[0];
        double min = arvud[0];
        double summa = 0;

        foreach (double arv in arvud)
        {
            if (arv > max) max = arv;
            if (arv < min) min = arv;
            summa += arv;
        }

        double keskmine = summa / arvud.Length;
        int suuremKuiKeskmine = 0;
        foreach (double arv in arvud)
        {
            if (arv > keskmine) suuremKuiKeskmine++;
        }
        Console.WriteLine($"Maksimaalne: {max}");
        Console.WriteLine($"Minimaalne: {min}");
        Console.WriteLine($"Keskmine: {keskmine}");
        Console.WriteLine($"Kogusumma: {summa}");
        Console.WriteLine($"Suurem kui keskmine: {suuremKuiKeskmine} arvu");
        Array.Sort(arvud);
        Console.WriteLine("Järjestatud arvud:");
        foreach (double arv in arvud)
        {
            Console.Write(arv + " ");
        }

        Console.ReadLine();
    }
    static double[] Tekstist_arvud(string text)
    {
        string[] osad = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double[] tulemus = new double[osad.Length];

        for (int i = 0; i < osad.Length; i++)
        {
            if (double.TryParse(osad[i], out double arv))
            {
                tulemus[i] = arv;}
        }
        return tulemus;}
}
