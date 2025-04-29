using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");
        
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Jaanuar");
                sw.WriteLine("Juuni");
                sw.WriteLine("Märts");
            }
            List<string> kuudList = new List<string>(File.ReadAllLines(path));
            kuudList.Remove("Juuni");
            if (kuudList.Count > 0) kuudList[0] = "Veeel kuuu";
            Console.WriteLine("Kuu nimekiri:");
            foreach (string kuu in kuudList) Console.WriteLine(kuu);
            
            Console.Write("\nSisesta otsitav kuu: ");
            string otsitav = Console.ReadLine();
            Console.WriteLine(kuudList.Contains(otsitav) ? "Kuu on olemas!" : "Kuu puudub!");
            File.WriteAllLines(path, kuudList);
            Console.WriteLine("\nFail uuendatud!");
        }
        catch (Exception)
        {
            Console.WriteLine("Tekkis viga failitöötluses!");}
    }
}
