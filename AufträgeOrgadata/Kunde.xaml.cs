using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.IO;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde.xaml
    /// </summary>
    public partial class Kunde : Window
    {
        public Kunde()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kundecs kd = new kundecs();

            for (int i = 0; i < kd.KundeListe.Count; i++)
            {
                // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR
                lvKunde.Items.Add(new TKunde { ID = kd.KundeListe[i].ID, Name = kd.KundeListe[i].Name, Ort = kd.KundeListe[i].Ort,
                    Str = kd.KundeListe[i].Str, PLZ = kd.KundeListe[i].PLZ, Ansprechpartner = kd.KundeListe[i].Ansprechpartner,
                    VertragsNr = kd.KundeListe[i].VertragsNr});
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_edit aded = new add_edit();
            aded.Show();
        }
    }
}
