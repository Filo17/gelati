using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrogiani.Filippo._4i.Rubrica
{
    public enum TipoIngrediente { nessuno, Panna, Colorante, Aroma, PannaSoia, Cacao, Latte, Caffe, Mascarpone, Uovo }
    //public enum TipoAltro { nessuno, 100Kj, Azzurro, 123Lattosio }
    public class Ingrediente
    {
        public int idGelato { get; set; }
        public TipoIngrediente Tipo { get; set; }
        public string Valore { get; set; }
        public string Altro { get; set; }

        public Ingrediente()
        {
            Tipo = TipoIngrediente.nessuno;
        }
        public Ingrediente(string riga)
        {
            string[] Campi = riga.Split(";"); //divido una riga csv
            
            int id = 0;
            int.TryParse(Campi[0], out id);
            idGelato = id;

            TipoIngrediente c;
            Enum.TryParse(Campi[1], out c);
            this.Tipo = c;

            this.Valore = Campi[2];
            if (Campi.Count() == 4)
                this.Altro = Campi[3];

        }
        public static Ingrediente MakeIngrediente(string riga)
        {
            string[] Campi = riga.Split(";"); //divido una riga csv

            TipoIngrediente c;
            Enum.TryParse(Campi[1], out c);
            switch (c)
            {
                case TipoIngrediente.Panna:
                    return new IngredientePanna(riga);
                    break;
                case TipoIngrediente.Colorante:
                    return new IngredienteColorante(riga);
                    break;
                case TipoIngrediente.Aroma:
                    return new IngredienteAroma(riga);
                    break;
                case TipoIngrediente.PannaSoia:
                    return new IngredientePannaSoia(riga);
                    break;
                case TipoIngrediente.Cacao:
                    return new IngredienteCacao(riga);
                    break;
                case TipoIngrediente.Latte:
                    return new IngredienteLatte(riga);
                    break;
                case TipoIngrediente.Caffe:
                    return new IngredienteCaffe(riga);
                    break;
                case TipoIngrediente.Mascarpone:
                    return new IngredienteMascarpone(riga);
                    break;
                case TipoIngrediente.Uovo:
                    return new IngredienteUovo(riga);
                    break;
            }
            return new Ingrediente(riga);
        }

    }
    public class Ingredienti:List<Ingrediente>
    {
        public Ingredienti() { }
        public Ingredienti(string nomeFile)
        {
            //leggi ingredienti
            StreamReader fin = new StreamReader("Ingredienti.csv");
            fin.ReadLine();
            while (!fin.EndOfStream)
            {
                Add( Ingrediente.MakeIngrediente( fin.ReadLine() ));
            }
            fin.Close();
        }

    }
    public class IngredientePanna : Ingrediente //eredita da ingrediente
    {
        public IngredientePanna() { }
        public IngredientePanna(string riga)
            : base(riga) //chiamo il costruttore base
        {

        }
    }
    public class IngredienteColorante : Ingrediente //eredita da ingrediente
    {
        public IngredienteColorante() { }
        public IngredienteColorante(string riga)
            : base(riga) //chiamo il costruttore base
        {

        }
    }
    public class IngredienteAroma : Ingrediente
    {
        public IngredienteAroma() { }
        public IngredienteAroma(string riga)
            :base(riga)
        {

        }
    }
    public class IngredientePannaSoia : Ingrediente
    {
        public IngredientePannaSoia() { }
        public IngredientePannaSoia(string riga)
            : base(riga)
        {

        }
    }

    public class IngredienteCacao : Ingrediente
    {
        public IngredienteCacao() { }
        public IngredienteCacao(string riga)
            : base(riga)
        {

        }
    }
    public class IngredienteLatte : Ingrediente
    {
        public IngredienteLatte() { }
        public IngredienteLatte(string riga)
            : base(riga)
        {

        }
    }
    public class IngredienteCaffe : Ingrediente
    {
        public IngredienteCaffe() { }
        public IngredienteCaffe(string riga)
            : base(riga)
        {

        }
    }
    public class IngredienteMascarpone : Ingrediente
    {
        public IngredienteMascarpone() { }
        public IngredienteMascarpone(string riga)
            : base(riga)
        {

        }
    }
    public class IngredienteUovo : Ingrediente
    {
        public IngredienteUovo() { }
        public IngredienteUovo(string riga)
            : base(riga)
        {

        }
    }
}
