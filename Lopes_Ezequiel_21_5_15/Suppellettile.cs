using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopes_Ezequiel_21_5_15
{
    class Suppellettile:Premi
    {
        private DateTime annocostruzione;
        private string tipologia;

        public Suppellettile() { }
        public Suppellettile(Suppellettile p):base(p)
        {
            Annocostruzione = p.Annocostruzione;
            Tipologia = p.Tipologia;
        }
        public Suppellettile(string c, string d, double p, DateTime anno, string t): base(c, d, p)
        {
            Annocostruzione = anno;
            Tipologia = t;
        }

        public DateTime Annocostruzione
        {
            get { return annocostruzione; }
            set 
            {
                if (value.Day <= DateTime.Now.Day)
                    annocostruzione = value;
                else
                    throw new ArgumentOutOfRangeException("Data di Costruzione non può essere al futuro!");
            }
        }

        public string Tipologia
        {
            get { return tipologia; }
            set 
            {
                if (value.Trim() != "")
                    tipologia = value;
                else
                    throw new ArgumentNullException("Tipologia vuoto!");
            }
        }

        public override string ToString()
        {
            return base.ToString() + Annocostruzione.ToString("dd/MM/yyyy") + ";" + Tipologia;
        }
    }
}
