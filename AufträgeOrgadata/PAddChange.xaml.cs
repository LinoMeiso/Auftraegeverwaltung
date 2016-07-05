using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde.xaml
    /// </summary>
    public partial class PAddChange : Window
    {
        public PAddChange()
        {
            InitializeComponent();
        }
        public class TProgram
        {
            public int ID { get; set; }
            public string ProgrammName { get; set; }

        }

        public class PAddChangeCs
        {
            public List<TProgram> ProgramListe { get; set; }

            public PAddChangeCs()
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
        private void btnEditChange_Click(object sender, RoutedEventArgs e)

        {
            string TextFeldProgrammName;

            TextFeldProgrammName = txtProgramName.Text;
            string connstring = "Server = localhost; database = auftraege; uid = root ";
            MySqlConnection connection = new MySqlConnection(connstring);
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO programm (Programmname) VALUES (?Programmname)";
                command.Parameters.AddWithValue("?Programmname", TextFeldProgrammName);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            this.Close();
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            PAddChange EditChange = new PAddChange();
            EditChange.ShowDialog();
        }
    }
}