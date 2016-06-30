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
using static AufträgeOrgadata.Get_set;

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
            //Boolean CheckStatus;

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
            if (txtRn.Text.Length > 0)
                cbRn.IsChecked = true;
            else
                cbRn.IsChecked = false;
        }
        private void textRn3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRn.Text.Length > 0)
                cbRn.IsChecked = true;
            else
                cbRn.IsChecked = false;
        }
        private void textRn4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRn.Text.Length > 0)
                cbRn.IsChecked = true;
            else
                cbRn.IsChecked = false;
        }
        private void textZeitDongle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtZeitDongle.Text.Length > 0)
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

            Get_set getset = new Get_set();
            txtKundeName.Text = getset.name;
            txtKundeOrt.Text = getset.ort;
            txtKundePlz.Text = getset.plz;
            txtKundeAnsprechPartner.Text = getset.partner;
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

            if (txtKundeName.Text == "" || txtKundeName.Text.Length < 3)
                 txtKundeName.Background = Brushes.Red;
            else
                   txtKundeName.Background = Brushes.White;

            if
                (txtKundeAnsprechPartner.Text == "" || txtKundeAnsprechPartner.Text.Length < 3)
                  txtKundeAnsprechPartner.Background = Brushes.Red;
            else
                    txtKundeAnsprechPartner.Background = Brushes.White;
            if
                (txtKundeLand.Text == "" || txtKundeLand.Text.Length < 3)
                  txtKundeLand.Background = Brushes.Red;
            else
                    txtKundeLand.Background = Brushes.White;
            if
                (txtKundeOrt.Text == "" || txtKundeOrt.Text.Length < 3)
                  txtKundeOrt.Background = Brushes.Red;
            else
                    txtKundeOrt.Background = Brushes.White;
            if
                (txtKundePlz.Text == "" || txtKundePlz.Text.Length < 3)
                  txtKundePlz.Background = Brushes.Red;
            else
                    txtKundePlz.Background = Brushes.White;

            if (txtAnAdresseName.Text == "" || txtAnAdresseName.Text.Length < 3)
                  txtAnAdresseName.Background = Brushes.Red;
            else
                    txtAnAdresseName.Background = Brushes.White;

            if (txtAnAdresseAnsprechPartner.Text == "" || txtAnAdresseAnsprechPartner.Text.Length < 3)
                  txtAnAdresseAnsprechPartner.Background = Brushes.Red;
            else
                    txtAnAdresseAnsprechPartner.Background = Brushes.White;

            if (txtAnAdresseLand.Text == "" || txtAnAdresseLand.Text.Length < 3)
                  txtAnAdresseLand.Background = Brushes.Red;
            else
                    txtAnAdresseLand.Background = Brushes.White;

            if (txtAnAdresseOrt.Text == "" || txtAnAdresseOrt.Text.Length < 3)
                  txtAnAdresseOrt.Background = Brushes.Red;
            else
                    txtAnAdresseOrt.Background = Brushes.White;

            if (txtAnAdressePlz.Text == "" || txtAnAdressePlz.Text.Length < 3)
                  txtAnAdressePlz.Background = Brushes.Red;
            else
                    txtAnAdressePlz.Background = Brushes.White;

          
            ProgrammName PName = new ProgrammName();

            bool atleastOneChecked = false;

            for (int i = 0; i < PName.ProgrammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelPrograms.Children[i];
                    
                if (checkbox.IsChecked == true)
                {
                    atleastOneChecked = true;
                    break;
                }
            }

            if(atleastOneChecked == false)
            {
                MessageBox.Show("Kein Programm ausgewählt");
                ProgrammGrid.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }

            else
                ProgrammGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }
        private void mstamm_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten stamm = new Stammdaten();
            stamm.ShowDialog();
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            //Auslesen Kunden Daten
            TKundeAdresse kdadresse = new TKundeAdresse();
            kdadresse.name = txtKundeName.Text;
            kdadresse.land = txtKundeLand.Text;
            kdadresse.ort = txtKundeOrt.Text;
            kdadresse.plz = txtKundePlz.Text;
            kdadresse.ansprechpartner = txtKundeAnsprechPartner.Text;

            //Auslesen An-Adresse
            TAnAdresse anadresse = new TAnAdresse();
            anadresse.name = txtAnAdresseName.Text;
            anadresse.land = txtAnAdresseLand.Text;
            anadresse.ort = txtAnAdresseOrt.Text;
            anadresse.plz = txtAnAdressePlz.Text;
            anadresse.ansprechpartner = txtAnAdresseAnsprechPartner.Text;

            //Auslesen Programm Daten ID & Name
            ProgrammName PName = new ProgrammName();
            TProgramms tpro = new TProgramms();
            tpro.ProList = new List<TProgramms>();
            bool atleastOneChecked = false;

            for (int i = 0; i < PName.ProgrammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelPrograms.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Programm Daten
                    tpro.id = Convert.ToString(PName.ProgrammListe[i].ID);
                    tpro.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    tpro.ProList.Add(tpro);
                    atleastOneChecked = true;
                }
            }

            if (atleastOneChecked == false)
            {

            }

            //Auslesen Installationsarten ID & Name
            Installationsart art = new Installationsart();
            TInstallArt installart = new TInstallArt();
            installart.InstallList = new List<TInstallArt>();
            bool atChecked = false;
            for(int i = 0; i < art.Installationsliste.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelInstallation.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Installationsarten
                    installart.id = Convert.ToString(art.Installationsliste[i].ID);
                    installart.installart = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    installart.InstallList.Add(installart);
                    atChecked = true;
                }
            }

            if(atChecked == false)
            {
            }

            //Zuweisen der Installationsarten
            installart.tuerfuellung = txtTuer.Text;
            installart.stkusb = txtStk_USB.Text;
            installart.stkzeit = txtStk_Zeit.Text;
            installart.server1 = cbServer1.IsChecked == true;
            installart.server2 = cbServer2.IsChecked == true;

            //Auslesen der Grund Daten
            TGrund tgrund = new TGrund();
            tgrund.grund = txtGrund.Text;
            tgrund.austausch = txtAustausch.Text;

            TVNummer vnummer = new TVNummer();
            vnummer.adkunden = cballedesKunden.IsChecked == true;
            vnummer.vnummer = txtKunden.Text + txtVertragsnummern.Text;
            vnummer.rnummer = txtRn.Text;
            vnummer.rnummer2 = txtRn2.Text;
            vnummer.rnumemr3 = txtRn3.Text;
            vnummer.serverdongle = txtServerdongle.Text;
            vnummer.zeitdongle = txtZeitDongle.Text;
            vnummer.autopro = cbAutoProl.IsChecked == true;


            //Auslesen StammDaten ID & Name
            StammName daten = new StammName();
            Tstamm stamm = new Tstamm();
            stamm.StammListUebergabe = new List<Tstamm>();
            bool atCheckedStamm = false;
            for (int i = 0; i < daten.StammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wpanelStamm.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Stammdaten
                    stamm.id = Convert.ToString(daten.StammListe[i].ID);
                    stamm.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                   stamm.StammListUebergabe.Add(stamm);
                    atCheckedStamm = true;
                }
            }

            if (atCheckedStamm == false)
            {
            }

            Ausstattung aus = new Ausstattung();
            TAusstattung_Data ausstattungdata = new TAusstattung_Data();
            ausstattungdata.Ausstattung_DataList = new List<TAusstattung_Data>();

            bool atCheckedAusstattung = false;
            for(int i = 0; i < aus.Ausstattungsliste.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wpanelAusstattung.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Ausstattung
                    ausstattungdata.id = Convert.ToString(aus.Ausstattungsliste[i].ID);
                    ausstattungdata.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    ausstattungdata.Ausstattung_DataList.Add(ausstattungdata);
                    atCheckedAusstattung = true;

                }
            
            }

            if (atCheckedAusstattung == false)
            {
            }

            //Übergabe der WIZT Daten
            Twizt twizt = new Twizt();
            twizt.express = cbexpress.IsChecked == true;
            twizt.tnt = cbtnt.IsChecked == true;
            twizt.mitarbeiter = cbmitarbeiter.IsChecked == true;
            twizt.anhaenger = cbanhaenger.IsChecked == true;
            twizt.ewtest = cbewtest.IsChecked == true;

            //Übergabe der Kontroll Daten
            TKontroll kontroll = new TKontroll();
            kontroll.donglegepr = cbgeprueft.IsChecked == true;
            kontroll.verschickt = cbdelivered.IsChecked == true;
            kontroll.geprkuerzel = combgeprueft.Text;
            kontroll.delivkuerzel = combdelivered.Text;

            //Übergabe der TAuftrag Daten
            TAuftrag auftrag = new TAuftrag();
            auftrag.kuerzel = combauftrag.Text;

            //Übergabe der TAusgefuehrt Daten
            TAusgefuehrt ausge = new TAusgefuehrt();
            ausge.kuerzel = combausgefuehrt.Text;
            ausge.date = txtausgefuehrt.Text;

            //Übergabe der TPost Daten
            TPost post = new TPost();
            post.kuerzel = combpost.Text;
            post.date = txtpost.Text;

            //Übergabe der TAnschreiben Daten
            TAnschreiben tanschreiben = new TAnschreiben();
            tanschreiben.anschreiben = cbanschreiben.IsChecked == true;

            //Übergabe der THandbuch Daten
            THandbuch thandbuch = new THandbuch();
            thandbuch.handbuch = cbhandbuch.IsChecked == true;

        }
    }
}