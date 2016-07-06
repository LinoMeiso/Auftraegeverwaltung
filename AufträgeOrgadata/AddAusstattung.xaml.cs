using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaction logic for AddAusstattung.xaml
    /// </summary>
    public partial class AddAusstattung : Window
    {
        public AddAusstattung()
        {
            InitializeComponent();
        }
        public class TAusstattung
        {
            public int ID { get; set; }
            public string Ausstattung { get; set; }
        }

        public class AusstatungChange
        {
            public List<TAusstattung> ausstattungliste { get; set; }

            public AusstatungChange()
            {
                ausstattungliste = new List<TAusstattung>();
                LoadAusstattung();
            }

            public void LoadAusstattung()
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

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM programm") { Connection = conn };

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {

                            TAusstattung ProgramName = new TAusstattung
                            {
                                ID = int.Parse(Reader["ID"].ToString()),
                                Ausstattung = Reader["ProgrammName"].ToString()
                            };
                            ausstattungliste.Add(ProgramName);
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

        private void btnEditChange_Click(object sender, RoutedEventArgs e)
        {
            string TextAusstattung;

            TextAusstattung = txtAusstattung.Text;
            string connstring = "Server = localhost; database = auftraege; uid = root ";
            MySqlConnection connection = new MySqlConnection(connstring);
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO ausstattung (Ausstattungname) VALUES (?Ausstattungsnamename)";
                command.Parameters.AddWithValue("?Ausstattungsnamename", TextAusstattung);
                connection.Open();
                command.ExecuteNonQuery();

                AusstatungChange AddChange = new AusstatungChange();
                AddChange.LoadAusstattung();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            Close();
        }
    }
}