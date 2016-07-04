using System;
using System.Windows;

namespace AufträgeOrgadata
{
    /// <summary>
    ///     Interaktionslogik für Kunde_search.xaml
    /// </summary>
    public partial class Kunde_search
    {
        public Kunde_search()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Möchtest du den Eintrag löschen?", "Warnung!",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;
            var selectitem = (dynamic)lvKundeSearch.SelectedItems[0];

            var kddel = new Kunde.TKundeDelete { id = Convert.ToString(selectitem.IDFind) };

            var kdcs = new kundecs();
            kdcs.DeleteKunde(kddel);

            lvKundeSearch.Items.Clear();
        }
    }
}