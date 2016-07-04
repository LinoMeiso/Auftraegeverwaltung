using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static AufträgeOrgadata.Get_set;

namespace AufträgeOrgadata
{
    /// <summary>
    ///     Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public string customerid;
        private TDateTime set;
        private TGrund setgrund;
        private TAuftrag setauftrag;
        private TAusgefuehrt setausgefuehrt;
        private TAnschreiben setanschreiben;
        private THandbuch sethandbuch;
        private TAnAdresse setanadresse;
        private TProgramms setpro;
        private TInstallArt setinstallart;
        private Twizt settwizt;
        private TAusstattung_Data setausstattung;
        private TVNummer setvnummer;
        private Tstamm setstamm;

        public MainWindow()
        {
            InitializeComponent();
            this.Left = 100;
            this.Top = 0;
        }

        private void Program_Loaded(object sender, RoutedEventArgs e)
        {
            var programme = new ProgrammName();
            //Boolean CheckStatus;

            for (var i = 0; i < programme.ProgrammListe.Count; i++)
            {
                var cb = new CheckBox
                {
                    Width = 115,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = Name
                };
                stackPanelPrograms.Children.Add(cb);
            }

            var installationsart = new Installationsart();

            foreach (var t in installationsart.Installationsliste)
            {
                var cb = new CheckBox
                {
                    Width = 200,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = t.Installationsart
                };
                stackPanelInstallation.Children.Add(cb);
            }

            var stamm = new StammName();

            foreach (var t in stamm.StammListe)
            {
                var cb = new CheckBox
                {
                    Width = 200,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = t.StammName
                };
                wpanelStamm.Children.Add(cb);
            }
            var Auss = new Ausstattung();

            foreach (var t in Auss.Ausstattungsliste)
            {
                var cb = new CheckBox
                {
                    Width = 200,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = t.Ausstatung
                };
                wpanelAusstattung.Children.Add(cb);
            }
        }

        public TDateTime GetDateTimeSet() => set;

        public TGrund GetGrundSet() => setgrund;

        public TAuftrag GetAuftragSet() => setauftrag;

        public TAusgefuehrt GetAusgefuehrtSet() => setausgefuehrt;

        public TAnschreiben GetAnschreibenSet() => setanschreiben;

        public THandbuch GetHandbuchSet() => sethandbuch;

        public TAnAdresse GetAnAdresseSet() => setanadresse;

        public TProgramms GetProgrammsSet() => setpro;

        public TInstallArt GetInstallArtSet() => setinstallart;

        public Twizt GetTwiztSet() => settwizt;

        public TAusstattung_Data GetAusstattungSet() => setausstattung;

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
            var date = DateTime.Now;
            var date1 = date.ToString();
            var dateOnly = date1.Substring(0, 10);
            var timeOnly = DateTime.Now.ToShortTimeString();

            lblDate.Content = dateOnly;
            lblTime.Content = timeOnly;

            Main_auftrag mauftr = new Main_auftrag();
            //mauftr.auftr_neu();
        }

        private void txtGrund_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbGrund.IsChecked = txtGrund.Text.Length > 0;
        }

        private void txtAustausch_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbAustausch.IsChecked = txtAustausch.Text.Length > 0;
        }

        private void txtRn2_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbRn.IsChecked = txtRn.Text.Length > 0;
        }

        private void textRn3_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbRn.IsChecked = txtRn.Text.Length > 0;
        }

        private void textRn4_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbRn.IsChecked = txtRn.Text.Length > 0;
        }

        private void textZeitDongle_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbZeitDongle.IsChecked = txtZeitDongle.Text.Length > 0;
        }

        private void txtServerdongle_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbServerdongle.IsChecked = txtServerdongle.Text.Length > 0;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close(); //Schließt das Fenster
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var db = new database();
            db.ShowDialog();
        }

        private void mprogramms_Click(object sender, RoutedEventArgs e)
        {
            var Pro = new ProWindow();
            Pro.ShowDialog();
        }

        private void mkunde_Click(object sender, RoutedEventArgs e)
        {
            var kd = new Kunde();

            kd.ShowDialog();

            var customer = kd.GetCustomerSet();
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
            if (txtKundeName.Text != "" && txtKundeAnsprechPartner.Text != "" && txtKundeStr.Text != "" &&
                txtKundeOrt.Text != "" && txtKundePlz.Text != "")
                if (txtKundeName.Text.Length < 3 || txtKundeAnsprechPartner.Text.Length < 3 ||
                    txtKundeStr.Text.Length < 3 || txtKundeOrt.Text.Length < 3 || txtKundePlz.Text.Length < 3)
                    MessageBox.Show(
                        "Ihre Eingabe war Fehlerhaft.\r\nBitte tätigen sie eine Eingabe, welche mindestens eine Länge von 3 umfasst!");
                else if (txtAnAdresseName.Text == "" || txtAnAdresseAnsprechPartner.Text == "" ||
                         txtAnAdresseLand.Text == "" || txtAnAdresseOrt.Text == "" || txtAnAdressePlz.Text == "")

                    MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");
                else if (txtAnAdresseName.Text.Length < 3 || txtAnAdresseAnsprechPartner.Text.Length < 3 ||
                         txtAnAdresseLand.Text.Length < 3 || txtAnAdresseOrt.Text.Length < 3 ||
                         txtAnAdressePlz.Text.Length < 3)
                    MessageBox.Show(
                        "Ihre Eingabe war Fehlerhaft.\r\nBitte tätigen sie eine Eingabe mit min. 3 Buchstaben ein!");
                else
                    MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");

            if (txtKundeName.Text == "" || txtKundeName.Text.Length < 3)
                txtKundeName.Background = Brushes.Red;
            else
                txtKundeName.Background = Brushes.White;

            if (txtKundeAnsprechPartner.Text == "" || txtKundeAnsprechPartner.Text.Length < 3)
                txtKundeAnsprechPartner.Background = Brushes.Red;
            else
                txtKundeAnsprechPartner.Background = Brushes.White;

            if (txtKundeStr.Text == "" || txtKundeStr.Text.Length < 3)
                txtKundeStr.Background = Brushes.Red;
            else
                txtKundeStr.Background = Brushes.White;

            if (txtKundeOrt.Text == "" || txtKundeOrt.Text.Length < 3)
                txtKundeOrt.Background = Brushes.Red;
            else
                txtKundeOrt.Background = Brushes.White;

            if (txtKundePlz.Text == "" || txtKundePlz.Text.Length < 3)
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

            var PName = new ProgrammName();

            var atleastOneChecked = false;

            for (var i = 0; i < PName.ProgrammListe.Count; i++)
            {
                var checkbox = (CheckBox)stackPanelPrograms.Children[i];

                if (checkbox.IsChecked != true) continue;
                atleastOneChecked = true;
                break;
            }

            if (atleastOneChecked)
                ProgrammGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            else
            {
                MessageBox.Show("Kein Programm ausgewählt");
                ProgrammGrid.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private void mstamm_Click(object sender, RoutedEventArgs e)
        {
            var stamm = new Stammdaten();
            stamm.ShowDialog();
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            //Auslesen Kunden Daten
            var kdadresse = new TKundeAdresse
            {
                name = txtKundeName.Text,
                land = txtKundeStr.Text,
                ort = txtKundeOrt.Text,
                plz = txtKundePlz.Text,
                ansprechpartner = txtKundeAnsprechPartner.Text
            };

            //Auslesen An-Adresse
            setanadresse = new TAnAdresse
            {
                name = txtAnAdresseName.Text,
                land = txtAnAdresseLand.Text,
                ort = txtAnAdresseOrt.Text,
                plz = txtAnAdressePlz.Text,
                ansprechpartner = txtAnAdresseAnsprechPartner.Text
            };

            //Auslesen Programm Daten ID & Name
            var PName = new ProgrammName();
            setpro = new TProgramms { ProList = new List<TProgramms>() };
            var atleastOneChecked = false;

            for (var i = 0; i < PName.ProgrammListe.Count; i++)
            {
                var checkbox = (CheckBox)stackPanelPrograms.Children[i];

                if (checkbox.IsChecked != true) continue;
                //Zuweisen der Programm Daten
                setpro.id = Convert.ToString(PName.ProgrammListe[i].ID);
                setpro.name = checkbox.Content.ToString();

                //Ausgelesende Daten in eine Liste hinzufügen
                setpro.ProList.Add(setpro);
            }

            //Auslesen Installationsarten ID & Name
            var art = new Installationsart();
            setinstallart = new TInstallArt { InstallList = new List<TInstallArt>() };
            var atChecked = false;
            for (var i = 0; i < art.Installationsliste.Count; i++)
            {
                var checkbox = (CheckBox)stackPanelInstallation.Children[i];

                if (checkbox.IsChecked != true) continue;
                //Zuweisen der Installationsarten
                setinstallart.id = Convert.ToString(art.Installationsliste[i].ID);
                setinstallart.installart = checkbox.Content.ToString();

                //Ausgelesende Daten in eine Liste hinzufügen
                setinstallart.InstallList.Add(setinstallart);
                atChecked = true;
            }

            if (atChecked == false)
            {
            }

            //Zuweisen der Installationsarten
            setinstallart.tuerfuellung = txtTuer.Text;
            setinstallart.stkusb = txtStk_USB.Text;
            setinstallart.stkzeit = txtStk_Zeit.Text;
            setinstallart.server1 = cbServer1.IsChecked == true;
            setinstallart.server2 = cbServer2.IsChecked == true;

            //Auslesen der Grund Daten
            setgrund = new TGrund
            {
                grund = txtGrund.Text,
                austausch = txtAustausch.Text
            };

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
                var checkbox = (CheckBox)wpanelStamm.Children[i];

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

            var aus = new Ausstattung();
            setausstattung = new TAusstattung_Data { Ausstattung_DataList = new List<TAusstattung_Data>() };

            var atCheckedAusstattung = false;
            for (var i = 0; i < aus.Ausstattungsliste.Count; i++)
            {
                var checkbox = (CheckBox)wpanelAusstattung.Children[i];

                if (checkbox.IsChecked != true) continue;
                setausstattung.id = Convert.ToString(aus.Ausstattungsliste[i].ID);
                setausstattung.name = checkbox.Content.ToString();

                //Ausgelesende Daten in eine Liste hinzufügen
                setausstattung.Ausstattung_DataList.Add(setausstattung);
                //Zuweisen der Ausstattung
            }

            //Übergabe der WIZT Daten
            settwizt = new Twizt();

            for (var i = 0; i < wrapPanelsVersand.Children.Count; i++)
            {
                var checkbox = (CheckBox)wrapPanelsVersand.Children[i];

                if (checkbox.IsChecked == true)
                {
                    settwizt.express = cbexpress.IsChecked == true;
                    settwizt.tnt = cbtnt.IsChecked == true;
                    settwizt.mitarbeiter = cbmitarbeiter.IsChecked == true;
                }
            }

            settwizt.anhaenger = cbanhaenger.IsChecked == true;
            settwizt.ewtest = cbewtest.IsChecked == true;

            //Übergabe der Kontroll Daten
            var kontroll = new TKontroll
            {
                donglegepr = cbgeprueft.IsChecked == true,
                verschickt = cbdelivered.IsChecked == true,
                geprkuerzel = combgeprueft.Text,
                delivkuerzel = combdelivered.Text
            };

            //Übergabe der TAuftrag Daten
            setauftrag = new TAuftrag { kuerzel = txtauftrag.Text };

            //Übergabe der TAusgefuehrt Daten
            setausgefuehrt = new TAusgefuehrt
            {
                kuerzel = txtausgefuehrt.Text,
                date = txtausgefuehrtdate.Text
            };

            //Übergabe der TPost Daten
            var post = new TPost
            {
                kuerzel = txtpost.Text,
                date = txtpostdate.Text
            };

            //Übergabe der TAnschreiben Daten
            setanschreiben = new TAnschreiben { anschreiben = cbanschreiben.IsChecked == true };

            //Übergabe der THandbuch Daten
            sethandbuch = new THandbuch { handbuch = cbhandbuch.IsChecked == true };

            set = new TDateTime();
            var date = DateTime.Now;
            var date1 = date.ToString();
            var dateOnly = date1.Substring(0, 10);
            var timeOnly = DateTime.Now.ToShortTimeString();
            set.date = dateOnly;
            set.timer = timeOnly;

            var mainauftrag = new Main_auftrag();
            mainauftrag.Kunde();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AusstattungWindow AusstattungWin = new AusstattungWindow();
            AusstattungWin.ShowDialog();

            

        }
    }
}//Ende
