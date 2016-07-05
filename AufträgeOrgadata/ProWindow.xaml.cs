using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde.xaml
    /// </summary>
    public partial class ProWindow
    {
        public ProWindow()
        {
            InitializeComponent();
            LoadProgrammData();
        }

        private void LoadProgrammData()
        {
            var pg = new ProWindowCs();

            foreach (var t in pg.ProgramListe)
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
                login lgn = new login();

                var uid = lgn.lgnList[0].uid;
                var pw = lgn.lgnList[0].pw;
                var server = lgn.lgnList[0].server;
                var port = lgn.lgnList[0].port;
                var db = lgn.lgnList[0].db;
                var table = lgn.lgnList[0].table;

                string connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";" + "table=" + table + ";";
                MySqlConnection conn = new MySqlConnection(connstring);

                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM programm") {Connection = conn};

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {

                            TProgram ProgramName = new TProgram
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
            if (lvProWindow.SelectedIndex < 0) return;
            var selectitem = (dynamic) lvProWindow.SelectedItems[0];

            var connstring = "Server=localhost; database=auftraege; uid=root ";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("Delete from  programm where ID = ?ItemClick");

                cmd.Parameters.AddWithValue("?ItemClick", selectitem.ID);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
                lvProWindow.Items.Clear();
                LoadProgrammData();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lvProWindow.SelectedIndex < 0) return;
            PAddChange EditChange = new PAddChange();
            EditChange.ShowDialog();
            lvProWindow.Items.Clear();
            LoadProgrammData();
        }
    }
}