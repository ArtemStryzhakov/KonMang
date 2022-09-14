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
            //väljastaEsemed();
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
