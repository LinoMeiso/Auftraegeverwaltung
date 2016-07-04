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
    /// <summary>
    /// Interaktionslogik für Stammdaten.xaml
    /// </summary>
    public partial class Stammdaten : Window
    {
        public Stammdaten()
        {
            InitializeComponent();
        }
        public class TStammDaten
        {
            public int ID { get; set; }
            public String StammName { get; set; }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }  


        public class StammdatenCs
        {
            public List<TStammDaten> StammDatenliste { get; set; }

            public StammdatenCs()
            {
                StammDatenliste = new List<TStammDaten>();
                LoadStammdaten();
            }

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

        public void PWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StammdatenCs SName = new StammdatenCs();

            for (int i = 0; i < SName.StammDatenliste.Count; i++)
            {
                lvStammDaten.Items.Add(new TStammDaten
                {
                    ID = SName.StammDatenliste[i].ID,
                    StammName = SName.StammDatenliste[i].StammName

                });
            }
        }

        public void mDelete_Click(object sender, RoutedEventArgs e)
        {

            var selectitem = (dynamic)lvStammDaten.SelectedItems[0];

            String connstring = "Server = localhost; database = auftraege; uid = root ";

            MySqlConnection conn = new MySqlConnection(connstring);


            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("Delete from stammdaten where StammName = ?ItemClick");
  

                cmd.Parameters.AddWithValue("?ItemClick", selectitem.StammName);

                MessageBox.Show("Projekt: "+ (Convert.ToString(selectitem.StammName)+(" erfolgreich gelöscht!")));

                
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }
    }
    }













