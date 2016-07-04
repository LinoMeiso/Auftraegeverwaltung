using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AufträgeOrgadata
{
    /// <summary>
    ///     Interaktionslogik für Kunde.xaml
    /// </summary>
    public partial class ProWindow
    {
        public ProWindow()
        {
            InitializeComponent();
        }

        private void PWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var PG = new ProWindowCs();

            foreach (var t in PG.ProgramListe)
            {
                lvProWindow.Items.Add(new TProgram
                {
                    ID = t.ID,
                    ProgrammName = t.ProgrammName
                });
            }
        }

        public class TProgram
        {
            public int ID { get; set; }
            public string ProgrammName { get; set; }
        }

        public class ProWindowCs
        {
            public List<TProgram> ProgramListe { get; set; }

            public ProWindowCs()
            {
                ProgramListe = new List<TProgram>();
                LoadProgram();
            }

            public void LoadProgram()
            {
                var lgn = new login();

                var uid = lgn.lgnList[0].uid;
                var pw = lgn.lgnList[0].pw;
                var server = lgn.lgnList[0].server;
                var port = lgn.lgnList[0].port;
                var db = lgn.lgnList[0].db;
                var table = lgn.lgnList[0].table;

                var connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" +
                                 port + ";" + "database=" + db + ";" + "table=" + table + ";";
                var conn = new MySqlConnection(connstring);

                try
                {
                    conn.Open();

                    var cmd = new MySqlCommand("SELECT * FROM programm") { Connection = conn };

                    using (var Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            var ProgramName = new TProgram
                            {
                                ID = int.Parse(Reader["ID"].ToString()),
                                ProgrammName = Reader["ProgrammName"].ToString()
                            };
                            ProgramListe.Add(ProgramName);
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

        private void btnMClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMDelete_Click(object sender, RoutedEventArgs e)
        {
            //string ItemClick;
            // ItemClick = ((TProgram)lvProWindow.SelectedItem).ProgrammName;
            var selectitem = (dynamic)lvProWindow.SelectedItems[0];

            var connstring = "Server = localhost; database = auftraege; uid = root ";
            var conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                var cmd = new MySqlCommand("Delete from  programm where ID = ?ItemClick");
                //MySqlCommand cmd = new MySqlCommand("Delete from programm where ID = 50");

                cmd.Parameters.AddWithValue("?ItemClick", selectitem.ID);

                MessageBox.Show("Programm: "+(Convert.ToString(selectitem.ProgrammName)+ (" erfolgreich gelöscht!")));
               

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            var EditChange = new PAddChange();
            EditChange.ShowDialog();
        }
    }
}
