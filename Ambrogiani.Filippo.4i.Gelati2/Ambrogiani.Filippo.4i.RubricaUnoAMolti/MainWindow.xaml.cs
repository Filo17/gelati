using Ambrogiani.Filippo._4i.Rubrica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ambrogiani.Filippo._4i.RubricaUnoAMolti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Ingredienti contatti;
        Persone persone;
        List<Ingrediente> ListaVuota = new List<Ingrediente>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Gelato p = e.AddedItems[0] as Gelato; //salva le informazioni della tabella selezionata
            if (p != null)
            {
                statusBar.Text = $"Nome: {p.Nome}";
                testoContatti.Text = $"ID: {p.idGelato}";
                        List<Ingrediente> contattiFiltrati = new List<Ingrediente>();
                        foreach (var item in contatti)
                        {
                            if (item.idGelato == p.idGelato)
                            {
                                contattiFiltrati.Add(item);
                            }
                        }
                    dgContatti.ItemsSource = contattiFiltrati; //se selezionato una persona mostro tutti i contatti con lo stesso ID
                    
            }
            else { 
                statusBar.Text = "Nome: ...";
                testoContatti.Text = "ID: ...";
                dgContatti.ItemsSource = ListaVuota; //svuoto la lista se niente è selezionato
            }
                

            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                persone = new Persone("Persone.csv");
                dgPersone.ItemsSource = persone;

                contatti = new Ingredienti("Contatti.csv");

                statusBar.Text = $"Ho letto dal file {persone.Count} persone";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgPersone_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Gelato p = e.Row.Item as Gelato;
            if(p != null)
            {
                if (p.idGelato == 1)
                {
                   //e.Row.Background = Brushes.Red;
                   //e.Row.Foreground = Brushes.Green;
                }
            }
        }
    }
}
