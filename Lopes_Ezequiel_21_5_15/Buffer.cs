using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lopes_Ezequiel_21_5_15
{
    class Buffer
    {
        ListBox lbx;
        public Buffer(ListBox l) { lbx = l; }

        private const int N = 5;
        private Premi PremiTemp;
        private Queue<Premi> BuffTemp = new Queue<Premi>();
        private Object thisLock = new Object();
        private Semaphore pieno = new Semaphore(0, N);
        private Semaphore vuoto = new Semaphore(N, N);
        private int QuotaFissa = 20;

        public Premi Buff
        {
            get
            {
                //partecipante
                pieno.WaitOne();
                lock (thisLock)
                {
                    PremiTemp = BuffTemp.Dequeue();
                    lbx.Items.Add(Thread.CurrentThread.Name + " ha comprato il premio " + PremiTemp.GetType().Name + " con il codice '" + PremiTemp.Codice + "' e descrizione : '" + PremiTemp.Descrizione + " pagando " + QuotaFissa.ToString() + "€");
                }
                vuoto.Release();
                return PremiTemp;
            }

            set
            {
                //volontario
                vuoto.WaitOne();
                BuffTemp.Enqueue(value);
                lbx.Items.Add(Thread.CurrentThread.Name + " ha reso disponibile il premio di tipo " + value.GetType().Name + " con il codice '" + value.Codice + "' e descrizione : '" + value.Descrizione +"'");
                pieno.Release();
            }
        }
    }
}
