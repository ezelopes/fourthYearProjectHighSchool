using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lopes_Ezequiel_21_5_15
{
    class Partecipante //consumatore
    {
        private ListBox lbx;
        private Random rand;
        private Buffer Buff;
        private Premi PremiTemp;
        private double incasso = 0;
        public Partecipante(ListBox l, Buffer b, Random r)
        {
            lbx = l;
            Buff = b;
            rand = r;
        }



        public void OttieniPremio()
        {
            for ( ; ; )
            {
                Thread.Sleep(rand.Next(6000));
                PremiTemp = Buff.Buff;
            }
        }
    }
}
