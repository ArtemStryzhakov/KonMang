using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonMang
{
    internal static class Peaklass
    {
        static List<string> names = new List<string>{ };
        public static Random rnd = new Random();
        public static List<Ese> LoeEsemed()
        {
            List<Ese> list = new List<Ese>();
            using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/file.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] info = sr.ReadLine().Split(";");
                    Ese item = new Ese( info[0], stringToInt(info[1]) );
                    list.Add(item);
                }
            }
            return list;
        }

        static int stringToInt(string s)
        {
            int y = 0;
            int total = 0;
            for (int i = 0; i < s.Length; i++)
                y = y * 10 + (s[i] - '0');
            total += y;
            return total;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        static Tegelane[] asustadaMangijaid(int plrCount)
        {
            if (plrCount < names.Count) throw new Exception();
            Tegelane[] plrs = new Tegelane[plrCount];
            for (int i = 0; i < names.Count; i++)
            {
                Tegelane plr = new Tegelane(names[i]);
                plrs[i] = plr;
            }

            return giveOutItems(plrs);
        }

        static Tegelane[] giveOutItems(Tegelane[] plrs)
        {
            List<Ese> itemList = LoeEsemed();
            if (itemList.Count <= 0) throw new ArgumentOutOfRangeException();
            foreach (Tegelane plr in plrs)
            {
                if(plr==null) continue;
                Shuffle(itemList);
                int amount = rnd.Next(2, 10);
                for (int i = 0; i < amount; i++)
                {
                    plr.Equip(itemList[i]);
                }
            }
            return plrs;
        }

        static public void PlayGame(int plrCount)
        {
            Console.Write("Kui palju mängijad mängivad: ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Kirjutage {i + 1}-ne mängija nimi: ");
                string name = Console.ReadLine();
                names.Add(name);
            }

            Tegelane[] plrs = asustadaMangijaid(plrCount);
            Mang mang = new Mang(plrs);
            foreach (Tegelane winner in mang.SuurimaEsemeteArvuga())
            {
                Console.WriteLine(winner.Info());
            }
            Tegelane win = mang.SuurimaPunktideArvuga();
            Console.WriteLine(win.Info());
            Console.WriteLine("Игрок имел следующие предметы:\n", Console.ForegroundColor = ConsoleColor.Yellow);
            win.väljastaEsemed();
        }
    }
}
