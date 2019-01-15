using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Lopes_Ezequiel_21_5_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Premi> listapremi = new List<Premi>();
        List<Thread> listathread = new List<Thread>();
        Suppellettile SupDaMod = new Suppellettile();
        GadgetElettronico GadDaMod = new GadgetElettronico();
        AccessorioModa AccDaMod = new AccessorioModa();

       public void DisegnaSuListView(List<Premi> l)
       {
           lvw_elenco.Items.Clear();
           foreach (Premi p1 in l)
           {
               if (p1.GetType().Name == "Suppellettile")
               {
                   Suppellettile s1 = (Suppellettile)p1;
                   string[] row = { s1.GetType().Name, s1.Codice, s1.Descrizione, s1.Prezzo.ToString(), s1.Annocostruzione.ToString("dd/MM/yyyy"), s1.Tipologia, "/", "/", "/", "/", "/", "/" };
                   ListViewItem riga = new ListViewItem(row);
                   lvw_elenco.Items.Add(riga);
               }
               else if (p1.GetType().Name == "GadgetElettronico")
               {
                   GadgetElettronico g1 = (GadgetElettronico)p1;
                   string[] row = { g1.GetType().Name, g1.Codice, g1.Descrizione, g1.Prezzo.ToString(), g1.Annocostruzione.ToString("dd/MM/yyyy"), "/", g1.Batterie.ToString(), g1.Tipobatterie, g1.Giocattolo.ToString(), g1.Dacollezione.ToString(), "/", "/" };
                   ListViewItem riga = new ListViewItem(row);
                   lvw_elenco.Items.Add(riga);
               }
               else
               {
                   AccessorioModa a1 = (AccessorioModa)p1;
                   string[] row = { a1.GetType().Name, a1.Codice, a1.Descrizione, a1.Prezzo.ToString(), "/", "/", "/", "/", "/", "/", a1.Materiale, a1.Pietre.ToString() };
                   ListViewItem riga = new ListViewItem(row);
                   lvw_elenco.Items.Add(riga);
               }
           }
       }

       public void Pulisci()
       {
           txt_codice.Clear();
           txt_descrizione.Clear();
           txt_materiale.Clear();
           txt_prezzo.Clear();
           txt_tipobatt.Clear();
           cmb_tipologia.Text = "";
           rb_battsi.Checked = true;
           rb_collsi.Checked = true;
           rb_giocatsi.Checked = true;
           rb_pietresi.Checked = true;
           rb_suppellettile.Checked = true;
       }

        private void rb_suppellettile_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_suppellettile.Checked == false)
            {
                cmb_tipologia.Enabled = false;
                if (rb_gadget.Checked)
                {
                    rb_battsi.Enabled = true;
                    if (rb_battsi.Checked)
                        txt_tipobatt.Enabled = true;
                    else
                        txt_tipobatt.Enabled = false;
                    rb_battno.Enabled = true;
                    rb_giocatsi.Enabled = true;
                    rb_giocatno.Enabled = true;
                    rb_collsi.Enabled = true;
                    rb_collno.Enabled = true;
                }
                else if (rb_accessorio.Checked)
                {
                    dtp_annocostruzione.Enabled = false;
                    txt_materiale.Enabled = true;
                    rb_pietresi.Enabled = true;
                    rb_pietreno.Enabled = true;
                }
            }
        }

        private void rb_gadget_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_gadget.Checked == false)
            {
                rb_battsi.Enabled = false;
                txt_tipobatt.Enabled = false;
                rb_battno.Enabled = false;
                rb_giocatsi.Enabled = false;
                rb_giocatno.Enabled = false;
                rb_collsi.Enabled = false;
                rb_collno.Enabled = false;

                if (rb_suppellettile.Checked)
                    cmb_tipologia.Enabled = true;
                else if (rb_accessorio.Checked)
                {
                    dtp_annocostruzione.Enabled = false;
                    txt_materiale.Enabled = true;
                    rb_pietresi.Enabled = true;
                    rb_pietreno.Enabled = true;
                }
            }
        }

        private void rb_accessorio_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_accessorio.Checked == false)
            {
                txt_materiale.Enabled = false;
                rb_pietresi.Enabled = false;
                rb_pietreno.Enabled = false;
                dtp_annocostruzione.Enabled = true;
                if (rb_suppellettile.Checked)
                    cmb_tipologia.Enabled = true;
                else if (rb_gadget.Checked)
                {
                    rb_battsi.Enabled = true;
                    if (rb_battsi.Checked)
                        txt_tipobatt.Enabled = true;
                    else
                        txt_tipobatt.Enabled = false;
                    rb_battno.Enabled = true;
                    rb_giocatsi.Enabled = true;
                    rb_giocatno.Enabled = true;
                    rb_collsi.Enabled = true;
                    rb_collno.Enabled = true;
                }
            }
        }

        private void btn_inserisci_Click(object sender, EventArgs e)
        {
            try
            {
                if (rb_suppellettile.Checked)
                {
                    Suppellettile s1 = new Suppellettile(txt_codice.Text, txt_descrizione.Text, Convert.ToDouble(txt_prezzo.Text), dtp_annocostruzione.Value, cmb_tipologia.SelectedItem.ToString());
                    listapremi.Add(s1);
                }
                else if (rb_gadget.Checked)
                {
                    bool batt = false; bool gioc = false; bool coll = false;
                    if (rb_battsi.Checked)
                        batt = true;
                    if (rb_collsi.Checked)
                        coll = true;
                    if (rb_giocatsi.Checked)
                        gioc = true;
                    GadgetElettronico g1 = new GadgetElettronico(txt_codice.Text, txt_descrizione.Text, Convert.ToDouble(txt_prezzo.Text), dtp_annocostruzione.Value, batt, gioc, coll, txt_tipobatt.Text);
                    listapremi.Add(g1);
                }
                else if (rb_accessorio.Checked)
                {
                    bool pietre = false;
                    if (rb_pietresi.Checked)
                        pietre = true;
                    AccessorioModa a1 = new AccessorioModa(txt_codice.Text, txt_descrizione.Text, Convert.ToDouble(txt_prezzo.Text), txt_materiale.Text, pietre);
                    listapremi.Add(a1);
                }
                Pulisci();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_visualizza_Click(object sender, EventArgs e)
        {
            DisegnaSuListView(listapremi);
        }

        private void btn_cerca_Click(object sender, EventArgs e)
        {
            string cercacodice = txt_cerca.Text;
            var listatemp = from p1 in listapremi
                            where p1.Codice == cercacodice
                            select p1;

            foreach (Premi p1 in listatemp)
            {
                    txt_moddescrizione.Text = p1.Descrizione;
                    txt_modprezzo.Text = p1.Prezzo.ToString();
                    if (p1.GetType().Name == "Suppellettile")
                    {
                        SupDaMod = (Suppellettile)p1;
                        dtp_modanno.Value = SupDaMod.Annocostruzione;
                        cmb_modtipologia.SelectedItem = SupDaMod.Tipologia;
                        GadDaMod = null;
                        AccDaMod = null;
                    }
                    else if (p1.GetType().Name == "GadgetElettronico")
                    {
                        GadDaMod = (GadgetElettronico)p1;
                        dtp_modanno.Value = GadDaMod.Annocostruzione;
                        if (GadDaMod.Batterie == false)
                            rb_modbattno.Checked = true;
                        if (GadDaMod.Giocattolo == false)
                            rb_modgiocno.Checked = true;
                        if (GadDaMod.Dacollezione == false)
                            rb_modcollno.Checked = true;
                        txt_modtipobatt.Text = GadDaMod.Tipobatterie;
                        SupDaMod = null;
                        AccDaMod = null;
                    }
                    else if (p1.GetType().Name == "AccessorioModa")
                    {
                        AccDaMod = (AccessorioModa)p1;
                        txt_modmateriale.Text = AccDaMod.Materiale;
                        if (AccDaMod.Pietre == false)
                            rb_modpietreno.Checked = true;
                        SupDaMod = null;
                        GadDaMod = null;
                    }
            }
        }

        private void btn_modifica_Click(object sender, EventArgs e)
        {
            if (SupDaMod != null)
            {
                SupDaMod.Descrizione = txt_moddescrizione.Text;
                SupDaMod.Prezzo = Convert.ToDouble(txt_modprezzo.Text);
                SupDaMod.Annocostruzione = dtp_modanno.Value;
                SupDaMod.Tipologia = cmb_modtipologia.SelectedItem.ToString();
                SupDaMod = null;
            }
            else if (GadDaMod != null)
            {
                GadDaMod.Descrizione = txt_moddescrizione.Text;
                GadDaMod.Prezzo = Convert.ToDouble(txt_modprezzo.Text);
                bool batt = false; bool gioc = false; bool coll = false;
                if (rb_modbattsi.Checked)
                    batt = true;
                if (rb_modcollsi.Checked)
                    coll = true;
                if (rb_modgiocsi.Checked)
                    gioc = true;
                GadDaMod.Batterie = batt;
                GadDaMod.Dacollezione = coll;
                GadDaMod.Giocattolo = gioc;
                GadDaMod.Tipobatterie = txt_modtipobatt.Text;
                GadDaMod = null;
            }
            else if (AccDaMod != null)
            {
                AccDaMod.Descrizione = txt_moddescrizione.Text;
                AccDaMod.Prezzo = Convert.ToDouble(txt_modprezzo.Text);
                bool pietre = false;
                if (rb_modpietresi.Checked)
                    pietre = true;
                AccDaMod.Pietre = pietre;
                AccDaMod.Materiale = txt_modmateriale.Text;
                AccDaMod = null;
            }
        }

        private void btn_elimina_Click(object sender, EventArgs e)
        {
            if (SupDaMod != null)
            {
                listapremi.Remove(SupDaMod);
                SupDaMod = null;
            }
            else if (GadDaMod != null)
            {
                listapremi.Remove(GadDaMod);
                GadDaMod = null;
            }
            else if (AccDaMod != null)
            {
                listapremi.Remove(AccDaMod);
                AccDaMod = null;
            }
        }

        private void btn_avvia_Click(object sender, EventArgs e)
        {
            try
            {
                listathread.Clear();
                CheckForIllegalCrossThreadCalls = false;
                Buffer buff = new Buffer(lbx_visualizza);
                Random r = new Random();

                Volontario volontario1 = new Volontario(lbx_visualizza, buff, listapremi, r);
                Partecipante partecipant1 = new Partecipante(lbx_visualizza, buff, r);

                Thread volon = new Thread(new ThreadStart(volontario1.PortaPremio));
                Thread partecip = new Thread(new ThreadStart(partecipant1.OttieniPremio));
                Thread partecip2 = new Thread(new ThreadStart(partecipant1.OttieniPremio));

                volon.Name = "Volontario";
                partecip.Name = "Partecipante";
                partecip2.Name = "Partecipante2";
                volon.Start();
                partecip.Start();
                partecip2.Start();
                listathread.Add(volon);
                listathread.Add(partecip);
                listathread.Add(partecip2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread t in listathread)
            {
                t.Abort();
                t.Join();
            }
        }

        private void btn_range_Click(object sender, EventArgs e)
        {
            try
            {
                double prezzomin = Convert.ToDouble(txt_partenza.Text);
                double prezzomax = Convert.ToDouble(txt_max.Text);
                var listatemp = from p1 in listapremi
                                  where p1.Prezzo > prezzomin && p1.Prezzo < prezzomax
                                  select p1;
                DisegnaSuListView(listatemp.ToList());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static class GlobalVar
        {
            public static string txtpremi = "Premi.txt";
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter(GlobalVar.txtpremi);
                foreach (Premi p1 in listapremi)
                {
                    if (p1 is Suppellettile)
                    {
                        SupDaMod = (Suppellettile)p1;
                        string datipremi = SupDaMod.ToString();
                        file.WriteLine(datipremi);
                    }
                    else if (p1 is GadgetElettronico)
                    {
                        GadDaMod = (GadgetElettronico)p1;
                        string datipremi = GadDaMod.ToString();
                        file.WriteLine(datipremi);
                    }
                    else if (p1 is AccessorioModa)
                    {
                        AccDaMod = (AccessorioModa)p1;
                        string datipremi = AccDaMod.ToString();
                        file.WriteLine(datipremi);
                    }
                }
                file.Close();
                SupDaMod = null;
                GadDaMod = null;
                AccDaMod = null;
                MessageBox.Show("Salvataggio Terminato!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader file = new StreamReader(GlobalVar.txtpremi);
                listapremi.Clear();
                lvw_elenco.Items.Clear();
                string linea;
                string[] vettore = new string[10];
                while (!file.EndOfStream)
                {
                    linea = file.ReadLine();
                    vettore = linea.Split(';');
                    if (vettore[0] == "Suppellettile")
                    {
                        Suppellettile s1 = new Suppellettile(vettore[1], vettore[2], Convert.ToDouble(vettore[3]), Convert.ToDateTime(vettore[4]), vettore[5]);
                        listapremi.Add(s1);
                    }
                    else if (vettore[0] == "GadgetElettronico")
                    {
                        GadgetElettronico g1 = new GadgetElettronico(vettore[1], vettore[2], Convert.ToDouble(vettore[3]), Convert.ToDateTime(vettore[4]), Convert.ToBoolean(vettore[5]), Convert.ToBoolean(vettore[6]), Convert.ToBoolean(vettore[7]), vettore[8]);
                        listapremi.Add(g1);
                    }
                    else if (vettore[0] == "AccessorioModa")
                    {
                        AccessorioModa a1 = new AccessorioModa(vettore[1], vettore[2], Convert.ToDouble(vettore[3]), vettore[4], Convert.ToBoolean(vettore[5]));
                        listapremi.Add(a1);
                    }
                }
                file.Close();
                DisegnaSuListView(listapremi);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_calcola_Click(object sender, EventArgs e)
        {
            double min = 99999999;
            double max = -1;
            double tot = 0;
            double media;
            foreach (Premi p in listapremi)
            {
                if (p.Prezzo > max)
                    max = p.Prezzo;
                if (p.Prezzo < min)
                    min = p.Prezzo;
                tot += p.Prezzo;
            }
            media = tot / listapremi.Count;
            MessageBox.Show("Max: " + max.ToString() + "\n Min: " + min.ToString() + "\n Media: " + media.ToString());
        }
    }
}
