using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AufträgeOrgadata
{
    /// <summary>
    ///     Interaktionslogik für Stammdaten.xaml
    /// </summary>
    public partial class Stammdaten
    {
        public Stammdaten()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void PWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var SName = new StammdatenCs();

            foreach (var t in SName.StammDatenliste)
            {
                lvStammDaten.Items.Add(new TStammDaten
                {
                    ID = t.ID,
                    StammName = t.StammName
                });
            }
        }

        public void mDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectitem = (dynamic)lvStammDaten.SelectedItems[0];
            var connstring = "Server = localhost; database = auftraege; uid = root ";
            var conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                using (var cmd = new MySqlCommand("Delete from  stammdaten where ID = ?ItemClick"))
                {
                    cmd.Parameters.AddWithValue("?ItemClick", selectitem.StammName);

                    MessageBox.Show(Convert.ToString(selectitem.ID));

                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public class TStammDaten
        {
            public int ID { get; set; }
            public string StammName { get; set; }
        }

        public class StammdatenCs
        {
            public StammdatenCs()
            {
                StammDatenliste = new List<TStammDaten>();
                LoadStammdaten();
            }

            public List<TStammDaten> StammDatenliste { get; set; }

            public void LoadStammdaten()
            {
                login lgn = new login();

                string uid, pw, server, port, db, table;
                uid = lgn.lgnList[0].uid;
                pw = lgn.lgnList[0].pw;
                server = lgn.lgnList[0].server;
                port = lgn.lgnList[0].port;
                db = lgn.lgnList[0].db;
                table = lgn.lgnList[0].table;

                String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";" + "table=" + table + ";";
                MySqlConnection conn = new MySqlConnection(connstring);

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM stammdaten");
                    cmd.Connection = conn;

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {

                            TStammDaten StammN = new TStammDaten();
                            StammN.ID = int.Parse(Reader["ID"].ToString());
                            StammN.StammName = Reader["StammName"].ToString();
                            StammDatenliste.Add(StammN);
                        }
                    }
                    conn.Close();
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


        private void mAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}