using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrogiani.Filippo._4i.Rubrica
{
    public class Gelato
    {
        public int idGelato { get; set; } //è un ID o anche detto chiave primaria
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public Gelato()
        {
            idGelato = 1;
        }

        public Gelato(string riga)
        {
            string[] Campi = riga.Split(";"); //divido una riga csv
            if (Campi.Count() != 4)
                throw new Exception("Le righe del file Persone.csv devono essere di 4 colonne");

            int id = 0;
            int.TryParse(Campi[0], out id); //converto la stringa in un numero
            idGelato = id;

            this.Nome = Campi[1];
            this.Descrizione = Campi[2];
            this.Prezzo = Convert.ToDouble(Campi[3]);

        }
    }

    public class Persone : List<Gelato> //rendo la classe una vera e propria lista
    {
        public Persone() { }
        public Persone(string nomeFile)
        {
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                this.Add(new Gelato(fin.ReadLine()));
            }
            fin.Close();
        }
    }
}
