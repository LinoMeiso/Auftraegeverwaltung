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
            Close();
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

                var uid = lgn.lgnList[0].uid;
                var pw = lgn.lgnList[0].pw;
                var server = lgn.lgnList[0].server;
                var port = lgn.lgnList[0].port;
                var db = lgn.lgnList[0].db;
                var table = lgn.lgnList[0].table;

                var connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port +
                                 ";" + "database=" + db + ";" + "table=" + table + ";";
                MySqlConnection conn = new MySqlConnection(connstring);

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM stammdaten") {Connection = conn};

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {

                            TStammDaten StammN = new TStammDaten
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

        public void PWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StammdatenCs SName = new StammdatenCs();

            foreach (TStammDaten t in SName.StammDatenliste)
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
            var selectitem = (dynamic) lvStammDaten.SelectedItems[0];
            var connstring = "Server = localhost; database = auftraege; uid = root ";

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                try
                {
                    conn.Open();
                    var cmd = new MySqlCommand("Delete from  stammdaten where ID = ?ItemClick");

                    cmd.Parameters.AddWithValue("?ItemClick", selectitem.StammName);

                    MessageBox.Show(Convert.ToString(selectitem.ID));

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
}