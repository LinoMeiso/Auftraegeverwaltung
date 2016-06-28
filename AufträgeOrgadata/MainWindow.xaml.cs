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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Program_Loaded(object sender, RoutedEventArgs e)
        {
            ProgrammName programme = new ProgrammName();

            for (int i = 0; i < programme.ProgrammListe.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 115;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = programme.ProgrammListe[i].Name;
                stackPanelPrograms.Children.Add(cb);
            }

            Installationsart installationsart = new Installationsart();

            for (int i = 0; i < installationsart.Installationsliste.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 200;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = installationsart.Installationsliste[i].Installationsart;
                stackPanelInstallation.Children.Add(cb);
            }

            StammName stamm = new StammName();

            for (int i = 0; i < stamm.StammListe.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 200;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = stamm.StammListe[i].StammName;
                wpanelStamm.Children.Add(cb);
            }
            Ausstattung Auss = new Ausstattung();

            for (int i = 0; i < Auss.Ausstattungsliste.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 200;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = Auss.Ausstattungsliste[i].Ausstatung;
                wpanelAusstattung.Children.Add(cb);
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Datum und Zeit Ausgabe
            DateTime date = DateTime.Now;
            string date1 = date.ToString();
            string dateOnly = date1.Substring(0, 10);
            string timeOnly = DateTime.Now.ToShortTimeString();

            lblDate.Content = dateOnly;
            lblTime.Content = timeOnly;
        }

        private void txtGrund_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtGrund.Text.Length > 0)
                cbGrund.IsChecked = true;
            else
                cbGrund.IsChecked = false;
        }

        private void txtAustausch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAustausch.Text.Length > 0)
                cbAustausch.IsChecked = true;
            else
                cbAustausch.IsChecked = false;
        }
        private void txtRn2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRn2.Text.Length > 0)
                cbRn.IsChecked = true;
            else
                cbRn.IsChecked = false;
        }
        private void textRn3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRn2.Text.Length > 0)
                cbRn.IsChecked = true;
            else
                cbRn.IsChecked = false;
        }
        private void textRn4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRn2.Text.Length > 0)
                cbRn.IsChecked = true;
            else
                cbRn.IsChecked = false;
        }
        private void textZeitDongle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textZeitDongle.Text.Length > 0)
                cbZeitDongle.IsChecked = true;
            else
                cbZeitDongle.IsChecked = false;
        }
        private void txtServerdongle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtServerdongle.Text.Length > 0)
                cbServerdongle.IsChecked = true;
            else
                cbServerdongle.IsChecked = false;

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close(); //Schließt das Fenster

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            database db = new database();
            db.ShowDialog();
        }

        private void mprogramms_Click(object sender, RoutedEventArgs e)
        {

            ProWindow Pro = new ProWindow();
            Pro.ShowDialog();
        }

        private void mkunde_Click(object sender, RoutedEventArgs e)
        {
            Kunde kd = new Kunde();

            kd.ShowDialog();
        }

        private void mCheck_Click(object sender, RoutedEventArgs e)
        {
            if (txtKundeName.Text == "" || txtKundeAnsprechPartner.Text == "" || txtKundeLand.Text == "" || txtKundeOrt.Text == "" || txtKundePlz.Text == "")

                    MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");
            else
            if (txtKundeName.Text.Length < 3 || txtKundeAnsprechPartner.Text.Length < 3 || txtKundeLand.Text.Length < 3 || txtKundeOrt.Text.Length < 3 || txtKundePlz.Text.Length < 3)
                    MessageBox.Show("Ihre Eingabe war Fehlerhaft. .Bitte tätigen sie eine Eingabe mit min. 3 Buchstaben ein!");
            else 
            if (txtAnAdresseName.Text == "" || txtAnAdresseAnsprechPartner.Text == "" || txtAnAdresseLand.Text == "" || txtAnAdresseOrt.Text == "" || txtAnAdressePlz.Text == "")

                    MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");
            else
            if (txtAnAdresseName.Text.Length < 3 || txtAnAdresseAnsprechPartner.Text.Length < 3 || txtAnAdresseLand.Text.Length < 3 || txtAnAdresseOrt.Text.Length < 3 || txtAnAdressePlz.Text.Length < 3)
                    MessageBox.Show("Ihre Eingabe war Fehlerhaft. .Bitte tätigen sie eine Eingabe mit min. 3 Buchstaben ein!");

        }

    }
}

