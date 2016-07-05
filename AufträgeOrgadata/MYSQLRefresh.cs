using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace AufträgeOrgadata
{
    public class Refresh
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class MYSQLRefresh
    {
        public List<TProgramm> ProgrammListe { get; set; }
        public List<TInstallationsart> Installationsliste { get; set; }
        public List<TStamm> StammdatenListe { get; set; }
        public List<AusstattungWindow.TAusstattung> Ausstattungsliste { get; set; }


        public MYSQLRefresh()
        {
            ProgrammListe = new List<TProgramm>();
            Installationsliste = new List<TInstallationsart>();
            StammdatenListe = new List<TStamm>();
            Ausstattungsliste = new List<AusstattungWindow.TAusstattung>();

            LoadProgramms();
            LoadInstallation();
            LoadStammdaten();
            LoadAusstattung();

        }

        public void LoadProgramms()
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
                        TProgramm programm = new TProgramm
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Name = Reader["ProgrammName"].ToString()
                        };
                        ProgrammListe.Add(programm);
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void LoadInstallation()
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Installationsart") {Connection = conn};

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TInstallationsart Install = new TInstallationsart
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Installationsart = Reader["Installationsart"].ToString()
                        };
                        Installationsliste.Add(Install);
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Stammdaten") {Connection = conn};

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TStamm Stamm = new TStamm
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            StammName = Reader["StammName"].ToString()
                        };
                        StammdatenListe.Add(Stamm);
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Ausstattung") {Connection = conn};

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        AusstattungWindow.TAusstattung Ausstattung = new AusstattungWindow.TAusstattung
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Ausstatung = Reader["AusstattungName"].ToString()
                        };
                        Ausstattungsliste.Add(Ausstattung);
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