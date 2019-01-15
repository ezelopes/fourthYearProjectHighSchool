using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopes_Ezequiel_21_5_15
{
    public abstract class Premi
    {
        protected string codice, descrizione;
        protected double prezzo;

        public Premi() { }
        public Premi(Premi p) 
        {
            Codice = p.Codice;
            Descrizione = p.Descrizione;
            Prezzo = p.Prezzo;
        }
        public Premi(string c, string d, double p)
        {
            Codice = c;
            Descrizione = d;
            Prezzo = p;
        }

        public string Codice
        {
            get { return codice; }
            protected set 
            {
                if (value.Trim() != "")
                    codice = value;
                else
                    throw new ArgumentNullException("Codice vuoto!");
            }
        }

        public string Descrizione
        {
            get { return descrizione; }
            set
            {
                if (value.Trim() != "")
                    descrizione = value;
                else
                    throw new ArgumentNullException("Descrzione vuoto!");
            }
        }

        public double Prezzo
        {
            get { return prezzo; }
            set
            {
                if (value > 0)
                    prezzo = value;
                else
                    throw new ArgumentOutOfRangeException("Prezzo non può essere negativo!");
            }
        }

        public virtual string ToString()
        {
            return this.GetType().Name + ";" + Codice + ";" + Descrizione + ";" + Prezzo.ToString() + ";";
        }
    }
}
