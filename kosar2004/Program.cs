using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Tracing;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();
        static void MasodikFeladat()
        {
            StreamReader file = new StreamReader("eredmenyek.csv");
            file.ReadLine();

            while (!file.EndOfStream)
            {
                string[] adatok = file.ReadLine().Split(';');
                meccsek.Add(new Meccs(adatok[0], adatok[1], Convert.ToInt32(adatok[2]), Convert.ToInt32(adatok[3]), adatok[4], adatok[5]));
            }
            file.Close();
        }
        static void HarmadikFeladat()
        {
            //int hazai = 0;
            //int idegen = 0;

            //int megszamol = 0;
            //foreach (var m in meccsek)
            //{
            //    if (m.Hazai == "Real Madrid")
            //    {

            //    }
            //}

            var hazai = from m in meccsek
                        where m.Hazai == "Real Madrid"
                        select new { Hazai = m.Hazai };

            int hazaiDB = hazai.ToList().Count;

            var idegen = from m in meccsek
                         where m.Idegen == "Real Madrid"
                         select new { Idegen = m.Idegen };

            int idegenDB = idegen.ToList().Count;
            Console.WriteLine($"3. feladat:  Real Madrid:  Hazai: {hazaiDB} Idegen: {idegenDB}");
        }
        static void Main(string[] args)
        {
            //7up Joventut;Adecco Estudiantes;81;73;Palacio Mun. De Deportes De Badalona;2005-04-03
            //var m = new Meccs("7up Joventut", "Adecco Estudiantes", 81, 73, "Palacio Mun. De Deportes De Badalona", "2005-04-03");
            //Console.WriteLine($"{m.Hazai} -- {m.Idegen} ({m.HPont} : {m.IPont})");

            MasodikFeladat();
            HarmadikFeladat();
            Console.ReadKey();
        }
    }
}
