using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                        var programm = new TProgramm
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

                var cmd = new MySqlCommand("SELECT * FROM installationsart") { Connection = conn };

                using (var Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        var installationsart = new TInstallationsart
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

                var cmd = new MySqlCommand("SELECT * FROM stammdaten") { Connection = conn };

                using (var Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        var stamm = new TStamm
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

    public class TAusstattung
    {
        public int ID { get; set; }
        public string Ausstatung { get; set; }
    }

    public class Ausstattung
    {
        public List<TAusstattung> Ausstattungsliste { get; set; }

        public Ausstattung()
        {
            Ausstattungsliste = new List<TAusstattung>();
            LoadProgramms();
        }

        public void LoadProgramms()
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

                var cmd = new MySqlCommand("SELECT * FROM ausstatung") { Connection = conn };

                using (var Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        var Ausstattung = new TAusstattung
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Ausstatung = Reader["ausstatungName"].ToString()
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