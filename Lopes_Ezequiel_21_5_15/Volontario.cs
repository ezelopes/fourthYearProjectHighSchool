using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lopes_Ezequiel_21_5_15
{
    class Volontario //produttore
    {
        private List<Premi> listapremi = new List<Premi>();
        private ListBox lbx;
        private Random rand;
        private Buffer Buff;
        public Volontario(ListBox l, Buffer b, List<Premi> p, Random r)
        {
            lbx = l;
            Buff = b;
            listapremi = p;
            rand = r;
        }

        public void PortaPremio()
        {
            for ( ; ; )
            {
                Thread.Sleep(rand.Next(2000));
                Premi premitemp = listapremi[rand.Next(0, listapremi.Count)];
                if(premitemp is Suppellettile)
                {
                    Suppellettile s1 = (Suppellettile)premitemp;
                    //Buff.Buff = s1;
                    Suppellettile s2 = new Suppellettile(s1);
                    Buff.Buff = s2;
                }
                else if (premitemp is GadgetElettronico)
                {
                    GadgetElettronico g1 = (GadgetElettronico)premitemp;
                    //Buff.Buff = g1;
                    GadgetElettronico g2 = new GadgetElettronico(g1);
                    Buff.Buff = g1;
                }
                else if (premitemp is AccessorioModa)
                {
                    AccessorioModa a1 = (AccessorioModa)premitemp;
                    //Buff.Buff = a1;
                    AccessorioModa a2 = new AccessorioModa(a1);
                    Buff.Buff = a1;
                }
            }
        }
    }
}
