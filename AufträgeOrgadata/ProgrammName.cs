using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;


namespace AufträgeOrgadata
{
    public class TProgramm
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ProgrammName
    {
        public List<TProgramm> ProgrammListe { get; set; }

        public ProgrammName()
        {
            ProgrammListe = new List<TProgramm>();
            LoadProgramms();
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

                string connstring = "uid="+uid+";" + "password="+pw+";" + "server="+server+";" + "port="+port+";" + "database="+db+";" + "table="+table+";";
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
    }

    public class TInstallationsart
    {
        public int ID { get; set; }
        public string Installationsart { get; set; }
    }

    public class Installationsart
    {
        public List<TInstallationsart> Installationsliste { get; set; }

        public Installationsart()
        {
            Installationsliste = new List<TInstallationsart>();
            LoadProgramms();
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM installationsart") {Connection = conn};

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TInstallationsart installationsart = new TInstallationsart
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Installationsart = Reader["installationsart"].ToString()
                        };
                        Installationsliste.Add(installationsart);
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

    public class TStamm
    {
        public int ID { get; set; }
        public string StammName { get; set; }
    }

    public class StammName
    {
        public List<TStamm> StammListe { get; set; }

        public StammName()
        {
            StammListe = new List<TStamm>();
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM stammdaten") {Connection = conn};

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TStamm stamm = new TStamm
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            StammName = Reader["StammName"].ToString()
                        };
                        StammListe.Add(stamm);
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

    public partial class Ausstattung
    {
        public int ID { get; set; }
        public string Ausstatung { get; set; }
    }

    public partial class Ausstattung
    {
        public List<Ausstattung> Ausstattungsliste { get; set; }

        public Ausstattung()
        {
            Ausstattungsliste = new List<Ausstattung>();
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ausstattung") {Connection = conn};

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Ausstattung Ausstattung = new Ausstattung
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Ausstatung = Reader["ausstattungName"].ToString()
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