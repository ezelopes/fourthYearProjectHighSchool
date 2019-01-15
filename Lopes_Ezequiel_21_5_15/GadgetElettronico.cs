using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopes_Ezequiel_21_5_15
{
    class GadgetElettronico:Premi
    {
        private DateTime annocostruzione;
        private bool batterie, giocattolo, dacollezione;
        private string tipobatterie;

        public GadgetElettronico() { }
        public GadgetElettronico(GadgetElettronico p): base(p)
        {
            Annocostruzione = p.Annocostruzione;
            Batterie = p.Batterie;
            Giocattolo = p.Giocattolo;
            Dacollezione = p.Dacollezione;
            Tipobatterie = p.Tipobatterie;
        }
        public GadgetElettronico(string c, string d, double p, DateTime anno, bool batt, bool gioc, bool coll, string tipo): base(c, d, p)
        {
            Annocostruzione = anno;
            Batterie = batt;
            Giocattolo = gioc;
            Dacollezione = coll;
            Tipobatterie = tipo;
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

        public bool Batterie
        {
            get { return batterie; }
            set { batterie = value; }
        }

        public bool Giocattolo
        {
            get { return giocattolo; }
            set { giocattolo = value; }
        }

        public bool Dacollezione
        {
            get { return dacollezione; }
            set { dacollezione = value; }
        }

        public string Tipobatterie
        {
            get { return tipobatterie; }
            set
            {
                if (Batterie == true)
                {
                    if (value.Trim() != "")
                        tipobatterie = value;
                    else
                        throw new ArgumentNullException("Batterie vuoto!");
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + Annocostruzione + ";" + Batterie.ToString() + ";" + Tipobatterie + ";" + Giocattolo.ToString() + ";" + Dacollezione.ToString();
        }
    }
}
