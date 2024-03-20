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
        Ingredienti ingredienti;
        Gelati gelati;
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
                testoIngredienti.Text = $"ID: {p.idGelato}";
                        List<Ingrediente> ingredientiFiltrati = new List<Ingrediente>();
                        foreach (var item in ingredienti)
                        {
                            if (item.idGelato == p.idGelato)
                            {
                                ingredientiFiltrati.Add(item);
                            }
                        }
                dgIngredienti.ItemsSource = ingredientiFiltrati; //se selezionato un gelato mostro tutti gli ingredienti con lo stesso ID
                    
            }
            else { 
                statusBar.Text = "Nome: ...";
                testoIngredienti.Text = "ID: ...";
                dgIngredienti.ItemsSource = ListaVuota; //svuoto la lista se niente è selezionato
            }
        }
            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                gelati = new Gelati("Gelati.csv");
                dgGelati.ItemsSource = gelati;

                ingredienti = new Ingredienti("Ingredienti.csv");

                statusBar.Text = $"Ho letto dal file {gelati.Count} gelati";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dgGelati_LoadingRow(object sender, DataGridRowEventArgs e)
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