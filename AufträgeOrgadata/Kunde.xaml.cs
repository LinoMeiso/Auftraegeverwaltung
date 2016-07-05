using System;
using System.Collections.Generic;
using System.Windows;
using static AufträgeOrgadata.Get_set;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde.xaml
    /// </summary>
    public partial class Kunde : Window
    {
        private TGetCustomer set = null;

        public Kunde()
        {
            InitializeComponent();
        }

        public class TKundeEdit
        {
            public string id { get; set; }
            public string name { get; set; }
            public string ort { get; set; }
            public string str { get; set; }
            public string plz { get; set; }
            public string partner { get; set; }
            public string vertrnr { get; set; }
        }

        public class TKundeAdd
        {
            public string name { get; set; }
            public string ort { get; set; }
            public string str { get; set; }
            public string plz { get; set; }
            public string partner { get; set; }
            public string vertrnr { get; set; }
        }

        public class TKundeDelete
        {
            public string id { get; set; }
            public string name { get; set; }
            public string ort { get; set; }
            public string str { get; set; }
            public string plz { get; set; }
            public string partner { get; set; }
            public string vertrnr { get; set; }
        }

        public class TKundeSearch
        {
            public string id { get; set; }
            public string name { get; set; }
            public string ort { get; set; }
            public string str { get; set; }
            public string plz { get; set; }
            public string partner { get; set; }
            public string vertrnr { get; set; }
        }

        public Get_set.TGetCustomer GetCustomerSet()
        {
            return set;
        }

        public List<TKundeEdit> KundeEditList { get; set; }

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
                lvKunde.Items.Add(new TKunde
                {
                    ID = kd.KundeListe[i].ID,
                    Name = kd.KundeListe[i].Name,
                    Ort = kd.KundeListe[i].Ort,
                    Str = kd.KundeListe[i].Str,
                    PLZ = kd.KundeListe[i].PLZ,
                    Ansprechpartner = kd.KundeListe[i].Ansprechpartner,
                    VertragsNr = kd.KundeListe[i].VertragsNr
                });
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_edit aded = new add_edit();
            aded.ShowDialog();

            TKundeAdd kdadd = new TKundeAdd();
            kdadd.name = aded.txtName.Text;
            kdadd.ort = aded.txtOrt.Text;
            kdadd.str = aded.txtStr.Text;
            kdadd.plz = aded.txtPLZ.Text;
            kdadd.partner = aded.txtAnsrpechpartner.Text;
            kdadd.vertrnr = aded.txtVertragsNr.Text;

            kundecs kdcs = new kundecs();
            kdcs.AddKunde(kdadd);

            //Refresh lvKunden
            lvKunde.Items.Clear();
            kundecs kd = new kundecs();
            for (int i = 0; i < kd.KundeListe.Count; i++)
            {
                // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR
                lvKunde.Items.Add(new TKunde
                {
                    ID = kd.KundeListe[i].ID,
                    Name = kd.KundeListe[i].Name,
                    Ort = kd.KundeListe[i].Ort,
                    Str = kd.KundeListe[i].Str,
                    PLZ = kd.KundeListe[i].PLZ,
                    Ansprechpartner = kd.KundeListe[i].Ansprechpartner,
                    VertragsNr = kd.KundeListe[i].VertragsNr
                });
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var selectitem = (dynamic)lvKunde.SelectedItems[0];

            TKundeEdit kdedit = new TKundeEdit {id = Convert.ToString(selectitem.ID)};

            add_edit aded = new add_edit
            {
                txtName = {Text = selectitem.Name},
                txtOrt = {Text = selectitem.Ort},
                txtStr = {Text = selectitem.Str},
                txtPLZ = {Text = selectitem.PLZ},
                txtAnsrpechpartner = {Text = selectitem.Ansprechpartner},
                txtVertragsNr = {Text = selectitem.VertragsNr}
            };

            aded.ShowDialog();

            kdedit.name = aded.txtName.Text;
            kdedit.ort = aded.txtOrt.Text;
            kdedit.str = aded.txtStr.Text;
            kdedit.plz = aded.txtPLZ.Text;
            kdedit.partner = aded.txtAnsrpechpartner.Text;
            kdedit.vertrnr = aded.txtVertragsNr.Text;

            kundecs kdcs = new kundecs();
            kdcs.EditKunde(kdedit);

            //Refresh lvKunden
            lvKunde.Items.Clear();
            kundecs kd = new kundecs();
            for (int i = 0; i < kd.KundeListe.Count; i++)
            {
                // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR nbvh
                lvKunde.Items.Add(new TKunde
                {
                    ID = kd.KundeListe[i].ID,
                    Name = kd.KundeListe[i].Name,
                    Ort = kd.KundeListe[i].Ort,
                    Str = kd.KundeListe[i].Str,
                    PLZ = kd.KundeListe[i].PLZ,
                    Ansprechpartner = kd.KundeListe[i].Ansprechpartner,
                    VertragsNr = kd.KundeListe[i].VertragsNr
                });
            }
        }

        private void delete_Click_1(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Möchtest du den Eintrag löschen?", "Warnung!",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var selectitem = (dynamic)lvKunde.SelectedItems[0];

                TKundeDelete kddel = new TKundeDelete {id = Convert.ToString(selectitem.ID)};

                kundecs kdcs = new kundecs();
                kdcs.DeleteKunde(kddel);

                //Refresh lvKunden
                lvKunde.Items.Clear();
                for (int i = 0; i < kdcs.KundeListe.Count; i++)
                {
                    // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR nbvh
                    lvKunde.Items.Add(new TKunde
                    {
                        ID = kdcs.KundeListe[i].ID,
                        Name = kdcs.KundeListe[i].Name,
                        Ort = kdcs.KundeListe[i].Ort,
                        Str = kdcs.KundeListe[i].Str,
                        PLZ = kdcs.KundeListe[i].PLZ,
                        Ansprechpartner = kdcs.KundeListe[i].Ansprechpartner,
                        VertragsNr = kdcs.KundeListe[i].VertragsNr
                    });
                }
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Kunde_search kdsearch = new Kunde_search();
            kundecs kdcs = new kundecs();

            foreach (TKundeFind t in kdcs.KundeFindList)
            {
                kdsearch.lvKundeSearch.Items.Add(new TKundeFind
                {
                    IDFind = t.IDFind,
                    NameFind = t.NameFind,
                    OrtFind = t.OrtFind,
                    StrFind = t.StrFind,
                    PLZFind = t.PLZFind,
                    AnsprechpartnerFind = t.AnsprechpartnerFind,
                    VertragsNrFind = t.VertragsNrFind
                });
            }
            kdsearch.ShowDialog();
        }

        public void cmeintragen_Click(object sender, RoutedEventArgs e)
        {
            string id, name, ort, plz, str, partner;
            var selectitem = (dynamic)lvKunde.SelectedItem;

            id = Convert.ToString(selectitem.ID);
            name = selectitem.Name;
            ort = selectitem.Ort;
            plz = selectitem.PLZ;
            str = selectitem.Str;
            partner = selectitem.Ansprechpartner;

            set = new TGetCustomer();
            set.id = id;
            set.name = name;
            set.ort = ort;
            set.plz = plz;
            set.str = str;
            set.partner = partner;

            Close();
        }
    }
}
