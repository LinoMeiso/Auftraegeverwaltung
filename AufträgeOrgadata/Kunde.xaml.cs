using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static AufträgeOrgadata.Get_set;

namespace AufträgeOrgadata
{
    public partial class Kunde
    {
        private TGetCustomer set;

        public Kunde(int Selection)
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

            foreach (TKunde t in kd.KundeListe)
            {
                lvKunde.Items.Add(new TKunde
                {
                    ID = t.ID,
                    Name = t.Name,
                    Ort = t.Ort,
                    Str = t.Str,
                    PLZ = t.PLZ,
                    Ansprechpartner = t.Ansprechpartner,
                    VertragsNr = t.VertragsNr
                });
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var aded = new add_edit();
            aded.ShowDialog();

            TKundeAdd kdadd = new TKundeAdd
            {
                name = aded.txtName.Text,
                ort = aded.txtOrt.Text,
                str = aded.txtStr.Text,
                plz = aded.txtPLZ.Text,
                partner = aded.txtAnsrpechpartner.Text,
                vertrnr = aded.txtVertragsNr.Text
            };

            var kdcs = new kundecs();
            kdcs.AddKunde(kdadd);

            //Refresh lvKunden
            lvKunde.Items.Clear();
            var kd = new kundecs();
            foreach (var t in kd.KundeListe)
            {
                lvKunde.Items.Add(new TKunde
                {
                    ID = t.ID,
                    Name = t.Name,
                    Ort = t.Ort,
                    Str = t.Str,
                    PLZ = t.PLZ,
                    Ansprechpartner = t.Ansprechpartner,
                    VertragsNr = t.VertragsNr
                });
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var selectitem = (dynamic)lvKunde.SelectedItems[0];
            var kdedit = new TKundeEdit {id = Convert.ToString(selectitem.ID)};

            var aded = new add_edit
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

            var kdcs = new kundecs();
            kdcs.EditKunde(kdedit);

            //Refresh lvKunden
            lvKunde.Items.Clear();
            var kd = new kundecs();
            foreach (var t in kd.KundeListe)
            {
                lvKunde.Items.Add(new TKunde
                {
                    ID = t.ID,
                    Name = t.Name,
                    Ort = t.Ort,
                    Str = t.Str,
                    PLZ = t.PLZ,
                    Ansprechpartner = t.Ansprechpartner,
                    VertragsNr = t.VertragsNr
                });
            }
        }

        private void delete_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Möchtest du den Eintrag löschen?", "Warnung!",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;
            var selectitem = (dynamic)lvKunde.SelectedItems[0];

            var kddel = new TKundeDelete {id = Convert.ToString(selectitem.ID)};

            var kdcs = new kundecs();
            kdcs.DeleteKunde(kddel);

            //Refresh lvKunden
            lvKunde.Items.Clear();
            foreach (var t in kdcs.KundeListe)
            {
                lvKunde.Items.Add(new TKunde
                {
                    ID = t.ID,
                    Name = t.Name,
                    Ort = t.Ort,
                    Str = t.Str,
                    PLZ = t.PLZ,
                    Ansprechpartner = t.Ansprechpartner,
                    VertragsNr = t.VertragsNr
                });
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield break;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                var children = child as T;
                if (children != null)
                {
                    yield return children;
                }

                foreach (var childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            var aded = new add_edit
            {
                Title = "Suchen",
                lbladd_edit = {Content = "Suchdaten"}
            };

            foreach (var tb in FindVisualChildren<TextBox>(aded))
            {
                tb.Clear();
            }

            aded.ShowDialog();

            var tkdsearch = new TKundeSearch
            {
                name = aded.txtName.Text,
                ort = aded.txtOrt.Text,
                str = aded.txtStr.Text,
                plz = aded.txtPLZ.Text,
                partner = aded.txtAnsrpechpartner.Text,
                vertrnr = aded.txtVertragsNr.Text
            };

            var kdcs = new kundecs();
            kdcs.SearchKunde(tkdsearch);
            
            var kdsearch = new Kunde_search();

            foreach (var t1 in kdcs.KundeFindList)
                foreach (var t in kdcs.KundeFindList)
                {
                    kdsearch.lvKundeSearch.Items.Add(new TKundeFind
                    {
                        IDFind = t1.IDFind,
                        NameFind = t1.NameFind,
                        OrtFind = t1.OrtFind,
                        StrFind = t1.StrFind,
                        PLZFind = t1.PLZFind,
                        AnsprechpartnerFind = t1.AnsprechpartnerFind,
                        VertragsNrFind = t1.VertragsNrFind
                    });
                }
            kdsearch.ShowDialog();
        }

        public void cmeintragen_Click(object sender, RoutedEventArgs e)
        {
            SelectKunde();
        }

        public void SelectKunde()
        {
            if (lvKunde.SelectedIndex < 0) return;
            var selectitem = (dynamic) lvKunde.SelectedItem;

            string id = Convert.ToString(selectitem.ID);
            string name = selectitem.Name;
            string ort = selectitem.Ort;
            string plz = selectitem.PLZ;
            string str = selectitem.Str;
            string partner = selectitem.Ansprechpartner;

            set = new TGetCustomer
            {
                id = id,
                name = name,
                ort = ort,
                plz = plz,
                str = str,
                partner = partner
            };
            Close();
        }

        private void lvKunde_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectKunde();
        }
    }
}