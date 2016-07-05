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
        public List<TAusstattung> Ausstattungsliste { get; set; }


        public MYSQLRefresh()
        {
            ProgrammListe = new List<TProgramm>();
            Installationsliste = new List<TInstallationsart>();
            StammdatenListe = new List<TStamm>();
            Ausstattungsliste = new List<TAusstattung>();

            LoadProgramms();
            LoadInstallation();
            LoadStammdaten();
            LoadAusstattung();

        }

        public void LoadProgramms()
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM programm");
                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TProgramm programm = new TProgramm();
                        programm.ID = int.Parse(Reader["ID"].ToString());
                        programm.Name = Reader["ProgrammName"].ToString();
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Installationsart");
                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TInstallationsart Install = new TInstallationsart();
                        Install.ID = int.Parse(Reader["ID"].ToString());
                        Install.Installationsart = Reader["Installationsart"].ToString();
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Stammdaten");
                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TStamm Stamm = new TStamm();
                        Stamm.ID = int.Parse(Reader["ID"].ToString());
                        Stamm.StammName = Reader["StammName"].ToString();
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Ausstattung");
                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TAusstattung Ausstattung = new TAusstattung();
                        Ausstattung.ID = int.Parse(Reader["ID"].ToString());
                        Ausstattung.Ausstatung = Reader["AusstattungName"].ToString();
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