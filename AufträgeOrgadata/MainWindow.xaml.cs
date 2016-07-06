using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static AufträgeOrgadata.Get_set;

namespace AufträgeOrgadata
{
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
        private TProgramms setpro = null;
        private TInstallArt setinstallart = null;
        private Twizt settwizt;
        private TAusstattung_Data setausstattung = null;
        private Tstamm setstamm = null;

        public MainWindow()
        {
            InitializeComponent();
            Left = 0;
            Top = 0;
        }

        private void Program_Loaded(object sender, RoutedEventArgs e)
        {
            ProgrammName programme = new ProgrammName();

            foreach (TProgramm t in programme.ProgrammListe)
            {
                CheckBox cb = new CheckBox
                {
                    Width = 115,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = t.Name
                };
                stackPanelPrograms.Children.Add(cb);
            }

            Installationsart installationsart = new Installationsart();

            foreach (TInstallationsart t in installationsart.Installationsliste)
            {
                CheckBox cb = new CheckBox
                {
                    Width = 200,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = t.Installationsart
                };
                stackPanelInstallation.Children.Add(cb);
            }

            StammName stamm = new StammName();

            foreach (TStamm t in stamm.StammListe)
            {
                CheckBox cb = new CheckBox
                {
                    Width = 200,
                    Height = 15,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = t.StammName
                };
                wpanelStamm.Children.Add(cb);
            }

            Ausstattung Auss = new Ausstattung();
            Auss.LoadProgramms();

            foreach (Ausstattung t in Auss.Ausstattungsliste)
            {
                CheckBox cb = new CheckBox
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

        public Get_set.Tstamm GetStammSet()
        {
            return setstamm;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var MsgResult =
                MessageBox.Show("Sind Sie sicher, dass Sie einen neuen Auftrag erstellen möchten?", "Frage",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MsgResult != MessageBoxResult.Yes) return;
            DateTime date = DateTime.Now;
            var date1 = date.ToString("yyyy-MM-dd");
            var dateOnly = date1.Substring(0, 10);
            var timeOnly = DateTime.Now.ToShortTimeString();

            lblDate.Content = dateOnly;
            lblTime.Content = timeOnly;
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
            var MsgRes =
                MessageBox.Show("Sind Sie sicher, dass Sie Beenden wollen?\r\nÄnderungen werden dabei verworfen.",
                    "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MsgRes != MessageBoxResult.Yes) return;
            Close();
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
            OpenKunde(-1);
        }

        private void OpenKunde(int Selection)
        {
            if (Selection == -1)
            {
                Kunde kd = new Kunde(-1);
                kd.ShowDialog();

                TGetCustomer customer = kd.GetCustomerSet();
                if (customer != null)
                {
                    customerid = customer.id;
                    txtKundeName.Text = customer.name;
                    txtKundeOrt.Text = customer.ort;
                    txtKundeStr.Text = customer.str;
                    txtKundePlz.Text = customer.plz;
                    txtKundeAnsprechPartner.Text = customer.partner;
                }
            }
            else
            {
                Kunde kd = new Kunde(0);
                kd.ShowDialog();

                TGetCustomer customer = kd.GetCustomerSet();
                if (customer != null)
                {
                    customerid = customer.id;
                    txtAnAdresseName.Text = customer.name;
                    txtAnAdresseOrt.Text = customer.ort;
                    txtAnAdresseStr.Text = customer.str;
                    txtAnAdressePlz.Text = customer.plz;
                    txtAnAdresseAnsprechPartner.Text = customer.partner;
                }
            }
        }

        private void mCheck_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKundeName.Text) || string.IsNullOrWhiteSpace(txtKundeAnsprechPartner.Text) || string.IsNullOrWhiteSpace(txtKundeStr.Text) ||
                string.IsNullOrWhiteSpace(txtKundeOrt.Text) || string.IsNullOrWhiteSpace(txtKundePlz.Text))

                MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");


            else if (txtKundeName.Text.Length < 3 || txtKundeAnsprechPartner.Text.Length < 3 ||
                     txtKundeStr.Text.Length < 3 || txtKundeOrt.Text.Length < 3 || txtKundePlz.Text.Length < 3)
                MessageBox.Show(
                    "Ihre Eingabe war Fehlerhaft. .Bitte tätigen sie eine Eingabe mit min. 3 Buchstaben ein!");
            else if (string.IsNullOrWhiteSpace(txtAnAdresseName.Text) || string.IsNullOrWhiteSpace(txtAnAdresseAnsprechPartner.Text) ||
                     string.IsNullOrWhiteSpace(txtAnAdresseStr.Text) || string.IsNullOrWhiteSpace(txtAnAdresseOrt.Text) || string.IsNullOrWhiteSpace(txtAnAdressePlz.Text))

                MessageBox.Show("Es wurden keine Angaben zum Kunden getätigt! - Bitte korrigieren! ");
            else if (txtAnAdresseName.Text.Length < 3 || txtAnAdresseAnsprechPartner.Text.Length < 3 ||
                     txtAnAdresseStr.Text.Length < 3 || txtAnAdresseOrt.Text.Length < 3 ||
                     txtAnAdressePlz.Text.Length < 3)
                MessageBox.Show(
                    "Ihre Eingabe war Fehlerhaft. .Bitte tätigen sie eine Eingabe mit min. 3 Buchstaben ein!");

            if (string.IsNullOrWhiteSpace(txtKundeName.Text) || txtKundeName.Text.Length < 3)
                txtKundeName.Background = Brushes.Red;
            else
                txtKundeName.Background = Brushes.White;

            if
                (string.IsNullOrWhiteSpace(txtKundeAnsprechPartner.Text) || txtKundeAnsprechPartner.Text.Length < 3)
                txtKundeAnsprechPartner.Background = Brushes.Red;
            else
                txtKundeAnsprechPartner.Background = Brushes.White;
            if
                (string.IsNullOrWhiteSpace(txtKundeStr.Text) || txtKundeStr.Text.Length < 3)
                txtKundeStr.Background = Brushes.Red;
            else
                txtKundeStr.Background = Brushes.White;
            if
                (string.IsNullOrWhiteSpace(txtKundeOrt.Text) || txtKundeOrt.Text.Length < 3)
                txtKundeOrt.Background = Brushes.Red;
            else
                txtKundeOrt.Background = Brushes.White;
            if
                (string.IsNullOrWhiteSpace(txtKundePlz.Text) || txtKundePlz.Text.Length < 3)
                txtKundePlz.Background = Brushes.Red;
            else
                txtKundePlz.Background = Brushes.White;

            if (string.IsNullOrWhiteSpace(txtAnAdresseName.Text) || txtAnAdresseName.Text.Length < 3)
                txtAnAdresseName.Background = Brushes.Red;
            else
                txtAnAdresseName.Background = Brushes.White;

            if (string.IsNullOrWhiteSpace(txtAnAdresseAnsprechPartner.Text) || txtAnAdresseAnsprechPartner.Text.Length < 3)
                txtAnAdresseAnsprechPartner.Background = Brushes.Red;
            else
                txtAnAdresseAnsprechPartner.Background = Brushes.White;

            if (string.IsNullOrWhiteSpace(txtAnAdresseStr.Text) || txtAnAdresseStr.Text.Length < 3)
                txtAnAdresseStr.Background = Brushes.Red;
            else
                txtAnAdresseStr.Background = Brushes.White;

            if (string.IsNullOrWhiteSpace(txtAnAdresseOrt.Text) || txtAnAdresseOrt.Text.Length < 3)
                txtAnAdresseOrt.Background = Brushes.Red;
            else
                txtAnAdresseOrt.Background = Brushes.White;

            if (string.IsNullOrWhiteSpace(txtAnAdressePlz.Text) || txtAnAdressePlz.Text.Length < 3)
                txtAnAdressePlz.Background = Brushes.Red;
            else
                txtAnAdressePlz.Background = Brushes.White;
            
            ProgrammName PName = new ProgrammName();
            bool atleastOneChecked = false;

            for (int i = 0; i < PName.ProgrammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelPrograms.Children[i];

                if (checkbox.IsChecked != true) continue;
                atleastOneChecked = true;
                break;
            }

            if (atleastOneChecked != false)
                cbAutoProl.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            else
            {
                MessageBox.Show("Kein Programm ausgewählt");
                cbAutoProl.Background  = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private void mstamm_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten stamm = new Stammdaten();
            stamm.ShowDialog();
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            //Auslesen Kunden Daten
            TKundeAdresse kdadresse = new TKundeAdresse
            {
                name = txtKundeName.Text,
                str = txtKundeStr.Text,
                ort = txtKundeOrt.Text,
                plz = txtKundePlz.Text,
                ansprechpartner = txtKundeAnsprechPartner.Text
            };

            //Auslesen An-Adresse
            setanadresse = new TAnAdresse
            {
                name = txtAnAdresseName.Text,
                str = txtAnAdresseStr.Text,
                ort = txtAnAdresseOrt.Text,
                plz = txtAnAdressePlz.Text,
                ansprechpartner = txtAnAdresseAnsprechPartner.Text
            };

            //Auslesen Programm Daten ID & Name
            ProgrammName PName = new ProgrammName();
            //setpro = new TProgramms {ProList = new List<TProgramms>()};

            for (int i = 0; i < PName.ProgrammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelPrograms.Children[i];

                if (checkbox.IsChecked != true) continue;
                //Zuweisen der Programm Daten
                setpro.id = Convert.ToString(PName.ProgrammListe[i].ID);
                setpro.name = checkbox.Content.ToString();

                //Ausgelesende Daten in eine Liste hinzufügen
                //setpro.ProList.Add(setpro);
            }

            //Auslesen Installationsarten ID & Name
            Installationsart art = new Installationsart();
            //setinstallart = new TInstallArt {InstallList = new List<TInstallArt>()};

            for (int i = 0; i < art.Installationsliste.Count; i++)
            {
                CheckBox checkbox = (CheckBox)stackPanelInstallation.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Installationsarten
                    setinstallart.id = Convert.ToString(art.Installationsliste[i].ID);
                    setinstallart.installart = checkbox.Content.ToString();
                    //Ausgelesende Daten in eine Liste hinzufügen
                    //setinstallart.InstallList.Add(setinstallart);
                }
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

            TVNummer vnummer = new TVNummer
            {
                adkunden = cballedesKunden.IsChecked == true,
                vnummer = txtKunden.Text + txtVertragsnummern.Text,
                rnummer = txtRn.Text,
                rnummer2 = txtRn2.Text,
                rnumemr3 = txtRn3.Text,
                serverdongle = txtServerdongle.Text,
                zeitdongle = txtZeitDongle.Text,
                autopro = cbAutoProl.IsChecked == true
            };


            //Auslesen StammDaten ID & Name
            StammName daten = new StammName();
            //setstamm = new Tstamm {StammListUebergabe = new List<Tstamm>()};
            for (int i = 0; i < daten.StammListe.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wpanelStamm.Children[i];
                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Stammdaten
                    setstamm.id = Convert.ToString(daten.StammListe[i].ID);
                    setstamm.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    //setstamm.StammListUebergabe.Add(setstamm);
                }
            }

            Ausstattung aus = new Ausstattung();
            aus.LoadProgramms();
            //setausstattung = new TAusstattung_Data {Ausstattung_DataList = new List<TAusstattung_Data>()};

            for (int i = 0; i < aus.Ausstattungsliste.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wpanelAusstattung.Children[i];

                if (checkbox.IsChecked == true)
                {
                    //Zuweisen der Ausstattung
                    setausstattung.id = Convert.ToString(aus.Ausstattungsliste[i].ID);
                    setausstattung.name = checkbox.Content.ToString();

                    //Ausgelesende Daten in eine Liste hinzufügen
                    //setausstattung.Ausstattung_DataList.Add(setausstattung);

                }
            }

            //Übergabe der WIZT Daten
            settwizt = new Twizt();

            for (int i = 0; i < wrapPanelsVersand.Children.Count; i++)
            {
                CheckBox checkbox = (CheckBox)wrapPanelsVersand.Children[i];

                if (checkbox.IsChecked != true) continue;
                settwizt.express = cbexpress.IsChecked == true;
                settwizt.tnt = cbtnt.IsChecked == true;
                settwizt.mitarbeiter = cbmitarbeiter.IsChecked == true;
            }

            settwizt.anhaenger = cbanhaenger.IsChecked == true;
            settwizt.ewtest = cbewtest.IsChecked == true;

            //Übergabe der Kontroll Daten
            TKontroll kontroll = new TKontroll
            {
                donglegepr = cbgeprueft.IsChecked == true,
                verschickt = cbdelivered.IsChecked == true,
                geprkuerzel = combgeprueft.Text,
                delivkuerzel = combdelivered.Text
            };

            //Übergabe der TAuftrag Daten
            setauftrag = new TAuftrag {kuerzel = txtauftrag.Text};

            //Übergabe der TAusgefuehrt Daten
            setausgefuehrt = new TAusgefuehrt
            {
                kuerzel = txtausgefuehrt.Text,
                date = txtausgefuehrtdate.Text
            };

            //Übergabe der TPost Daten
            TPost post = new TPost
            {
                kuerzel = txtpost.Text,
                date = txtpostdate.Text
            };

            //Übergabe der TAnschreiben Daten
            setanschreiben = new TAnschreiben {anschreiben = cbanschreiben.IsChecked == true};

            //Übergabe der THandbuch Daten
            sethandbuch = new THandbuch {handbuch = cbhandbuch.IsChecked == true};

            set = new TDateTime();
            DateTime date = DateTime.Now;
            string date1 = date.ToString();
            string dateOnly = date1.Substring(0, 10);
            string timeOnly = DateTime.Now.ToShortTimeString();
            set.date = dateOnly;
            set.timer = timeOnly;

            Main_auftrag mainauftrag = new Main_auftrag();
            mainauftrag.dongle();

            mainauftrag.dongleIndetity();
            mainauftrag.donglestamm();
            mainauftrag.Kunde();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AusstattungWindow AusstattungWin = new AusstattungWindow();
            AusstattungWin.ShowDialog();
        }

        private void txtKundeName_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenKunde(-1);
        }

        private void txtAnAdresseName_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenKunde(0);
        }
    }
}