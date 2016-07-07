using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace AufträgeOrgadata
{
    public partial class ADDStammdaten : Window
    {
        public ADDStammdaten()
        {
            InitializeComponent();
        }
        private void AddStamm()
        {
            TStamm stamm = new TStamm();
            stamm.StammName = txtStammdaten.Text;
        }
        public class Stammchange
        {
            public List<TStamm> Stammliste { get; set; }

            public Stammchange()
            {
                Stammliste = new List<TStamm>();
                LoadStammdaten();
            }

            public void LoadStammdaten()
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

                            TStamm ProgramName = new TStamm
                            {
                                ID = int.Parse(Reader["ID"].ToString()),
                                StammName = Reader["ProgrammName"].ToString()
                            };
                            Stammliste.Add(ProgramName);
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
                string TextStamm;
                TextStamm = txtStammdaten.Text;
                string connstring = "Server = localhost; database = auftraege; uid = root ";
                MySqlConnection connection = new MySqlConnection(connstring);
                try
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO stammdaten (Stammname) VALUES (?Stammname)";
                    command.Parameters.AddWithValue("?Stammname", TextStamm);
                    connection.Open();
                    command.ExecuteNonQuery();

                    Stammchange AddChange = new Stammchange();
                    AddChange.LoadStammdaten();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }

                Close();
            }
        }
    }