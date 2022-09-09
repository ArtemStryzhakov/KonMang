using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KonMang
{
    class Tegelane : Uksus, IComparable<Tegelane>
    {
        double summary;
        private string nimi;
        List<Ese> eseList = new List<Ese>();

        public Tegelane(string nimi)
        {
            this.nimi = nimi;
        }

        public int CompareTo(Tegelane? other)
        {
            throw new NotImplementedException();
        }

        public string info()
        {
            Console.WriteLine($"Nimi: {nimi}");
            foreach (string line in File.ReadLines(@"..\..\..\file.txt"))
            {
                string[] row = line.Split(';');
                summary += Double.Parse(row[1]);
                Ese ese = new Ese(row[0], Int32.Parse(row[1]));
                eseList.Add(ese);             
                Console.WriteLine($"Nimetus: {row[0]}, Punktide arvu: {row[1]}"); 
            }
            Console.WriteLine($"Esemete arvu: {eseList.Count}, Summa: {summary}");
            return $"{nimi}";
        }

        public int lisaEse(int punktide_Arv)
        {
            return punktide_Arv;
        }

        public int PunktideArv()
        {
            int sum = 0;
            foreach (Ese item in eseList) { sum += item.PunktideArv(); }
            return sum;
        }
    }
}
