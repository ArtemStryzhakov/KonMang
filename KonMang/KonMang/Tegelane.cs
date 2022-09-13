using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KonMang
{
    internal class Tegelane : Uksus, IComparable<Tegelane>
    {
        
        private string nimi;
        List<Ese> eseList = new List<Ese>();

        public Tegelane(string nimi)
        {
            this.nimi = nimi;
        }

        public int CompareTo(Tegelane? other)
        {
            if (other == null) return 1;
            return this.eseList.Count - other.ItemCount();
        }
        public int ItemCount() { return eseList.Count; }

        public string Info()
        {
            double summary = 0;
            Console.WriteLine($"Nimi: {nimi}", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine("--------------------------", Console.ForegroundColor = ConsoleColor.White);
            foreach (string line in File.ReadLines(@"..\..\..\file.txt"))
            {
                string[] row = line.Split(';');
                summary += Double.Parse(row[1]);
                Ese ese = new Ese(row[0], Int32.Parse(row[1]));
                eseList.Add(ese);             
                Console.WriteLine($"Nimetus: {row[0]}, Punktide arvu: {row[1]}", Console.ForegroundColor = ConsoleColor.White);
            }
            Console.WriteLine($"Esemete arvu: {eseList.Count}, Summa: {summary}\n");
            return $"{nimi} info:\n Esemete arv: {eseList.Count}\n Punktide arv: {PunktideArv()}\n";
        }

        public int lisaEse(int punktide_Arv)
        {
            return punktide_Arv;
        }

        public void Equip(Ese item) { eseList.Add(item); }

        public int PunktideArv()
        {
            int sum = 0;
            foreach (Ese item in eseList) { sum += item.PunktideArv(); }
            return sum;
        }

        public void väljastaEsemed()
        {
            foreach (Ese item in eseList)
            {
                Console.WriteLine(item.Info() + " " + item.PunktideArv());
            }
        }
    }
}
