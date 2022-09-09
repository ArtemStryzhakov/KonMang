using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonMang
{
    class Ese : Uksus
    {
        private string nimetus;
        public int punktide_Arv;
        public Ese() { }
        public Ese(string nimetus, int punktide_Arv)
        {
            this.nimetus = nimetus;
            this.punktide_Arv = punktide_Arv;
        }

        public string info()
        {
            return nimetus;
        }

        public int PuntkideArv()
        {
            return punktide_Arv;
        }
    }
}
