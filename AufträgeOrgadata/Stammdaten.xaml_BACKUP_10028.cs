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

<<<<<<< HEAD
                using (var cmd = new MySqlCommand("Delete from  stammdaten where ID = ?ItemClick"))
                {
                    cmd.Parameters.AddWithValue("?ItemClick", selectitem.StammName);

                    MessageBox.Show(Convert.ToString(selectitem.ID));
=======
                MySqlCommand cmd = new MySqlCommand("Delete from stammdaten where StammName = ?ItemClick");
  

                cmd.Parameters.AddWithValue("?ItemClick", selectitem.StammName);

                MessageBox.Show("Projekt: "+ (Convert.ToString(selectitem.StammName)+(" erfolgreich gelöscht!")));
>>>>>>> 34164b00cafe1eb4ed0b669d00a0a6d43f6d1004

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
<<<<<<< HEAD
=======

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }





>>>>>>> 34164b00cafe1eb4ed0b669d00a0a6d43f6d1004

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
                var lgn = new login();

                var uid = lgn.lgnList[0].uid;
                var pw = lgn.lgnList[0].pw;
                var server = lgn.lgnList[0].server;
                var port = lgn.lgnList[0].port;
                var db = lgn.lgnList[0].db;
                var table = lgn.lgnList[0].table;

                var connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port +
                                 ";" + "database=" + db + ";" + "table=" + table + ";";
                var conn = new MySqlConnection(connstring);

                try
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM stammdaten") { Connection = conn };

                    using (var Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            var StammN = new TStammDaten
                            {
                                ID = int.Parse(Reader["ID"].ToString()),
                                StammName = Reader["StammName"].ToString()
                            };
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
    }
}