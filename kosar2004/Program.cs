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
        static Dictionary<string, int> dmeccsek = new Dictionary<string, int>();
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

            //int megszamol = 0;
            //foreach (var m in meccsek)
            //{
            //    if (m.Hazai == "Real Madrid")
            //    {
            //        megszamol++;
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
        static void NegyedikFeladat()
        {
            var dontetlen= from m in meccsek
                        where m.HPont == m.IPont
                        select m;

            int meccsDB = dontetlen.ToList().Count;
            if (meccsDB == 0)
            {
                Console.WriteLine($"4. feladat: Volt döntetlen? nem");
            }
            else
            {
                Console.WriteLine($"4. feladat: Volt döntetlen? igen");
            }
        }
        static void OtodikFeladat()
        {
            var barca = from m in meccsek
                        where m.Hazai.Contains("Barcelona")
                        select new { Hazai = m.Hazai };
            var barcaNev = barca.ToArray()[0].Hazai;
            Console.WriteLine($"5. feladat barcelonai csapat neve:  {barcaNev}");
        }
        static void HatodikFeladat()
        {
            Console.WriteLine("6. feladat:");


            //var november = from m in meccsek
            //               where m.Ido == "2004-11-21"
            //               select new { Hazai = m.Hazai, Idegen = m.Idegen, HP = m.HPont, IP = m.IPont };
            //foreach (var n in november)
            //{
            //    Console.WriteLine($"\t{n.Hazai} - {n.Idegen} ({n.HP} : {n.IP})");
            //}


            foreach (var m in meccsek)
            {
                if (m.Ido.Contains("2004-11-21"))
                {
                    Console.WriteLine($"\t{m.Hazai} {m.Idegen} ({m.HPont} : {m.IPont})");
                }
            }
        }
        static void HetedikFeladat()
        {
            Console.WriteLine("7. feladat:");

               var stadionok = from m in meccsek
                            orderby m.Hely
                            group m by m.Hely into stadion
                            select stadion;
            foreach (var stadion in stadionok)
            {
                if (stadion.Count() > 20)
                {
                    Console.WriteLine($"\t{stadion.Key}: {stadion.Count()}");
                }
            }

        }
        static void NyolcadikFeladat()
        {
            // meccsek.txt-be kiírni a meccsek eredményeit

            StreamWriter ir = new StreamWriter("meccsek.txt");
            foreach (var m in meccsek)
            {
                ir.WriteLine(m.Atalakit());
            }
            ir.Close();
        }
        static void Main(string[] args)
        {
            //7up Joventut;Adecco Estudiantes;81;73;Palacio Mun. De Deportes De Badalona;2005-04-03
            //var m = new Meccs("7up Joventut", "Adecco Estudiantes", 81, 73, "Palacio Mun. De Deportes De Badalona", "2005-04-03");
            //Console.WriteLine($"{m.Hazai} -- {m.Idegen} ({m.HPont} : {m.IPont})");

            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();

            Console.ReadKey();
        }
    }
}
