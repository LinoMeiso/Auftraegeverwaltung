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
            String connstring = "uid=root;" + "password=;" + "server=localhost;" + "database=auftraege";
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
            String connstring = "uid=root;" + "password=;" + "server=localhost;" + "database=auftraege";
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
                        TInstallationsart installationsart = new TInstallationsart();
                        installationsart.ID = int.Parse(Reader["ID"].ToString());
                        installationsart.Installationsart = Reader["Installationsart"].ToString();
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
            String connstring = "uid=root;" + "password=;" + "server=localhost;" + "database=auftraege";
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
                        TStamm stamm = new TStamm();
                        stamm.ID = int.Parse(Reader["ID"].ToString());
                        stamm.StammName = Reader["StammName"].ToString();
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
            String connstring = "uid=root;" + "password=;" + "server=localhost;" + "database=auftraege";
            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ausstatung");
                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TAusstattung Ausstattung = new TAusstattung();
                        Ausstattung.ID = int.Parse(Reader["ID"].ToString());
                        Ausstattung.Ausstatung = Reader["ausstatungName"].ToString();
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