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

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde_search.xaml
    /// </summary>
    public partial class Kunde_search : Window
    {
        public Kunde_search()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Möchtest du den Eintrag löschen?", "Warnung!",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var selectitem = (dynamic)lvKundeSearch.SelectedItems[0];

                Kunde.TKundeDelete kddel = new Kunde.TKundeDelete();
                kddel.id = Convert.ToString(selectitem.IDFind);

                kundecs kdcs = new kundecs();
                kdcs.DeleteKunde(kddel);

                lvKundeSearch.Items.Clear();
            }
        }
    }
}
