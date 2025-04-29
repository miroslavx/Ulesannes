using System;

class Program
{
    public static void Main(string[] args)
    {
        // Ülesanne 7: Korrutustabel
        Console.Write("Sisesta ridade arv: ");
        int ridadearv = int.Parse(Console.ReadLine());
        Console.Write("Sisesta veergude arv: ");
        int veergudearv = int.Parse(Console.ReadLine());

        int[,] tabel = GenereeriKorrutustabel(ridadearv, veergudearv);
        Console.WriteLine("\nSisesta korrutis (nt '7 x 8'), või 'exit' lõpetamiseks:");
        string sisend;
        while ((sisend = Console.ReadLine().ToLower()) != "exit")
        {
            if (sisend.Contains("x"))
            {
                string[] osad = sisend.Split(new[] { 'x', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (osad.Length == 2 && int.TryParse(osad[0], out int a) && int.TryParse(osad[1], out int b))
                {
                    if (a > 0 && a <= ridadearv && b > 0 && b <= veergudearv)
                        Console.WriteLine($"{a} x {b} = {tabel[a - 1, b - 1]}");
                    else
                        Console.WriteLine("Väärtused ei sobi tabelisse!");
                }
                else
                    Console.WriteLine("Vigane formaat!");
            }
            else
                Console.WriteLine("Kasuta kujul 'arv x arv'");

            Console.Write("Sisesta uus korrutis või 'exit': ");
        }
    }    static int[,] GenereeriKorrutustabel(int read, int veerud)
    {
        int[,] tabel = new int[read, veerud];
        for (int i = 0; i < read; i++)
        {
            for (int j = 0; j < veerud; j++)
            {
                tabel[i, j] = (i + 1) * (j + 1);
                Console.Write($"{tabel[i, j],4}");
            }
            Console.WriteLine();
        }
        return tabel;
    }
}
