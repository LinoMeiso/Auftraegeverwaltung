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
        public string customerid = null;
        private TDateTime set = null;
        private TGrund setgrund = null;
        private TAuftrag setauftrag = null;
        private TAusgefuehrt setausgefuehrt = null;
        private TAnschreiben setanschreiben = null;
        private THandbuch sethandbuch = null;
        private TAnAdresse setanadresse = null;
        private TProgramms setpro = null;
        private TInstallArt setinstallart = null;
        private Twizt settwizt = null;
        private TAusstattung_Data setausstattung = null;
        private TVNummer setvnummer = null;
        private Tstamm setstamm = null;

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

        public Get_set.TDateTime GetDateTimeSet()
        {
            return set;
        }

        public Get_set.TGrund GetGrundSet()
        {
            return setgrund;
        }

        public Get_set.TAuftrag GetAuftragSet()
        {
            return setauftrag;
        }

        public Get_set.TAusgefuehrt GetAusgefuehrtSet()
        {
            return setausgefuehrt;
        }

        public Get_set.TAnschreiben GetAnschreibenSet()
        {
            return setanschreiben;
        }
        
        public Get_set.THandbuch GetHandbuchSet()
        {
            return sethandbuch;
        }

        public Get_set.TAnAdresse GetAnAdresseSet()
        {
            return setanadresse;
        }

        public Get_set.TProgramms GetProgrammsSet()
        {
            return setpro;
        }

        public Get_set.TInstallArt GetInstallArtSet()
        {
            return setinstallart;
        }

        public Get_set.Twizt GetTwiztSet()
        {
            return settwizt;
        }

        public Get_set.TAusstattung_Data GetAusstattungSet()
        {
            return setausstattung;
        }

        public Get_set.TVNummer GetVNummerSet()
        {
            return setvnummer;
        }

        public Get_set.Tstamm GetStammSet()
        {
            return setstamm;
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

            Main_auftrag mauftr = new Main_auftrag();
            //mauftr.auftr_neu();
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

            Get_set.TGetCustomer customer = kd.GetCustomerSet();
            if (customer == null)
            {
                MessageBox.Show("Es wurde kein Kunde ausgewählt.");
            }
            else
            {
                customerid = customer.id;
                txtKundeName.Text = customer.name;
                txtKundeOrt.Text = customer.ort;
                txtKundeStr.Text = customer.str;
                txtKundePlz.Text = customer.plz;
                txtKundeAnsprechPartner.Text = customer.partner;
            }
        }

        private void mCheck_Click(object sender, RoutedEventArgs e)
        {
            if (txtKundeName.Text == "" || txtKundeAnsprechPartner.Text == "" || txtKundeStr.Text == "" || txtKundeOrt.Text == "" || txtKundePlz.Text == "")

                    MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");

                   
            else
            if (txtKundeName.Text.Length < 3 || txtKundeAnsprechPartner.Text.Length < 3 || txtKundeStr.Text.Length < 3 || txtKundeOrt.Text.Length < 3 || txtKundePlz.Text.Length < 3)
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
                (txtKundeStr.Text == "" || txtKundeStr.Text.Length < 3)
                  txtKundeStr.Background = Brushes.Red;
            else
                    txtKundeStr.Background = Brushes.White;
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
            kdadresse.land = txtKundeStr.Text;
            kdadresse.ort = txtKundeOrt.Text;
            kdadresse.plz = txtKundePlz.Text;
            kdadresse.ansprechpartner = txtKundeAnsprechPartner.Text;

            //Auslesen An-Adresse
            setanadresse = new TAnAdresse();
            setanadresse.name = txtAnAdresseName.Text;
            setanadresse.land = txtAnAdresseLand.Text;
            setanadresse.ort = txtAnAdresseOrt.Text;
            setanadresse.plz = txtAnAdressePlz.Text;
            setanadresse.ansprechpartner = txtAnAdresseAnsprechPartner.Text;

            //Auslesen Programm Daten ID & Name
            ProgrammName PName = new ProgrammName();
            setpro = new TProgramms();
            setpro.ProList = new List<TProgramms>();
            bool atleastOneChecked = false;

            for (int i = 0; i < PName.ProgrammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelPrograms.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Programm Daten
                    setpro.id = Convert.ToString(PName.ProgrammListe[i].ID);
                    setpro.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    setpro.ProList.Add(setpro);
                    atleastOneChecked = true;
                }
            }

            if (atleastOneChecked == false)
            {

            }

            //Auslesen Installationsarten ID & Name
            Installationsart art = new Installationsart();
            setinstallart = new TInstallArt();
            setinstallart.InstallList = new List<TInstallArt>();
            bool atChecked = false;
            for(int i = 0; i < art.Installationsliste.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelInstallation.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Installationsarten
                    setinstallart.id = Convert.ToString(art.Installationsliste[i].ID);
                    setinstallart.installart = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    setinstallart.InstallList.Add(setinstallart);
                    atChecked = true;
                }
            }

            if(atChecked == false)
            {
            }

            //Zuweisen der Installationsarten
            setinstallart.tuerfuellung = txtTuer.Text;
            setinstallart.stkusb = txtStk_USB.Text;
            setinstallart.stkzeit = txtStk_Zeit.Text;
            setinstallart.server1 = cbServer1.IsChecked == true;
            setinstallart.server2 = cbServer2.IsChecked == true;

            //Auslesen der Grund Daten
            setgrund = new TGrund();
            setgrund.grund = txtGrund.Text;
            setgrund.austausch = txtAustausch.Text;

            setvnummer = new TVNummer();
            setvnummer.adkunden = cballedesKunden.IsChecked == true;
            setvnummer.vnummer = txtKunden.Text + txtVertragsnummern.Text;
            setvnummer.rnummer = txtRn.Text;
            setvnummer.rnummer2 = txtRn2.Text;
            setvnummer.rnumemr3 = txtRn3.Text;
            setvnummer.serverdongle = txtServerdongle.Text;
            setvnummer.zeitdongle = txtZeitDongle.Text;
            setvnummer.autopro = cbAutoProl.IsChecked == true;


            //Auslesen StammDaten ID & Name
            StammName daten = new StammName();
            setstamm = new Tstamm();
            setstamm.StammListUebergabe = new List<Tstamm>();
            bool atCheckedStamm = false;
            for (int i = 0; i < daten.StammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wpanelStamm.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Stammdaten
                    setstamm.id = Convert.ToString(daten.StammListe[i].ID);
                    setstamm.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    setstamm.StammListUebergabe.Add(setstamm);
                    atCheckedStamm = true;
                }
            }

            if (atCheckedStamm == false)
            {
            }

            Ausstattung aus = new Ausstattung();
            setausstattung = new TAusstattung_Data();
            setausstattung.Ausstattung_DataList = new List<TAusstattung_Data>();

            bool atCheckedAusstattung = false;
            for(int i = 0; i < aus.Ausstattungsliste.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wpanelAusstattung.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Ausstattung
                    setausstattung.id = Convert.ToString(aus.Ausstattungsliste[i].ID);
                    setausstattung.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    setausstattung.Ausstattung_DataList.Add(setausstattung);
                    atCheckedAusstattung = true;

                }
            
            }

            if (atCheckedAusstattung == false)
            {
            }

            //Übergabe der WIZT Daten
            settwizt = new Twizt();

            for(int i = 0; i < wrapPanelsVersand.Children.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wrapPanelsVersand.Children[i];

                if(checkbox.IsChecked == true)
                {

                    settwizt.express = cbexpress.IsChecked == true;
                    settwizt.tnt = cbtnt.IsChecked == true;
                    settwizt.mitarbeiter = cbmitarbeiter.IsChecked == true;
                }
            }

            settwizt.anhaenger = cbanhaenger.IsChecked == true;
            settwizt.ewtest = cbewtest.IsChecked == true;

            //Übergabe der Kontroll Daten
            TKontroll kontroll = new TKontroll();
            kontroll.donglegepr = cbgeprueft.IsChecked == true;
            kontroll.verschickt = cbdelivered.IsChecked == true;
            kontroll.geprkuerzel = combgeprueft.Text;
            kontroll.delivkuerzel = combdelivered.Text;

            //Übergabe der TAuftrag Daten
            setauftrag = new TAuftrag();
            setauftrag.kuerzel = txtauftrag.Text;

            //Übergabe der TAusgefuehrt Daten
            setausgefuehrt = new TAusgefuehrt();
            setausgefuehrt.kuerzel = txtausgefuehrt.Text;
            setausgefuehrt.date = txtausgefuehrtdate.Text;

            //Übergabe der TPost Daten
            TPost post = new TPost();
            post.kuerzel = txtpost.Text;
            post.date = txtpostdate.Text;

            //Übergabe der TAnschreiben Daten
            setanschreiben = new TAnschreiben();
            setanschreiben.anschreiben = cbanschreiben.IsChecked == true;

            //Übergabe der THandbuch Daten
            sethandbuch = new THandbuch();
            sethandbuch.handbuch = cbhandbuch.IsChecked == true;

            set = new TDateTime();
            DateTime date = DateTime.Now;
            string date1 = date.ToString();
            string dateOnly = date1.Substring(0, 10);
            string timeOnly = DateTime.Now.ToShortTimeString();
            set.date = dateOnly;
            set.timer = timeOnly;

            Main_auftrag mainauftrag = new Main_auftrag();
            mainauftrag.Kunde();       
        }
    }
}