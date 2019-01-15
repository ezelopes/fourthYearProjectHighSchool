using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopes_Ezequiel_21_5_15
{
    class AccessorioModa:Premi
    {
        private string materiale;
        private bool pietre;

        public AccessorioModa() { }
        public AccessorioModa(AccessorioModa p): base(p)
        {
            Materiale = p.Materiale;
            Pietre = p.Pietre;
        }
        public AccessorioModa(string c, string d, double p, string m, bool piet): base(c, d, p)
        {
            Materiale = m;
            Pietre = piet;
        }

        public string Materiale
        {
            get { return materiale; }
            set 
            {
                if (value.Trim() != "")
                    materiale = value;
                else
                    throw new ArgumentNullException("Materiale vuoto!");
            }
        }

        public bool Pietre
        {
            get { return pietre; }
            set { pietre = value; }
        }

        public override string ToString()
        {
            return base.ToString() + Materiale + ";" + Pietre.ToString();
        }
    }
}
