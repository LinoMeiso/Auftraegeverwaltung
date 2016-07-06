using System;
using System.Windows;
using System.Windows.Input;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde_search.xaml
    /// </summary>
    public partial class Kunde_search
    {
        public Kunde_search()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            if (lvKundeSearch.SelectedIndex < 0) return;
            try
            {
                if (MessageBox.Show("Möchtest du den Eintrag löschen?", "Warnung!",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;
                var selectitem = (dynamic) lvKundeSearch.SelectedItems[0];

                var kddel = new Kunde.TKundeDelete {id = Convert.ToString(selectitem.IDFind)};

                var kdcs = new kundecs();
                kdcs.DeleteKunde(kddel);

                lvKundeSearch.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Delete))
            {
                Delete();
            }
        }
    }
}
