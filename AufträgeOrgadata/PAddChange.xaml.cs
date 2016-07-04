using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AufträgeOrgadata
{
    /// <summary>
    ///     Interaktionslogik für Kunde.xaml
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

        private void btnEditChange_Click(object sender, RoutedEventArgs e)

        {
            string TextFeldID;
            string TextFeldProgrammName;

            TextFeldID = txtID.ToString();
            TextFeldProgrammName = txtProgramName.ToString();

            var connstring = "Server = localhost; database = auftraege; uid = root ";

            var conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                var cmd = new MySqlCommand("Update programmm (?ItemClick) Values (TextFeldProgrammName) ");
                //MySqlCommand cmd = new MySqlCommand("Delete from programm where ID = 50");

                //var selectitem = (dynamic)lvProWindow.SelectedItems[0];
                //cmd.Parameters.AddWithValue("?ItemClick", selectitem.ID);

                //                MessageBox.Show(Convert.ToString(selectitem.ID));

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            Close();
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            var EditChange = new PAddChange();
            EditChange.ShowDialog();
        }
    }
}