using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static AufträgeOrgadata.Get_set;
using System.Windows;

namespace AufträgeOrgadata
{
    class Main_auftrag
    {
        //Dongle: ReservierteNummer,Zeit,ServerDongle,auto_proglongation,AuftragNR
        //donglestammdaten: DongleID,StammdatenID

        public Main_auftrag()
        {
        }

        public void Kunde()
        {
            Kunde kd = Application.Current.MainWindow as Kunde;
            MainWindow main = Application.Current.MainWindow as MainWindow;
            Get_set.TDateTime dt = main.GetDateTimeSet();
            Get_set.TGrund grund = main.GetGrundSet();
            Get_set.TAuftrag auftrag = main.GetAuftragSet();
            Get_set.TAusgefuehrt ausgefuehrt = main.GetAusgefuehrtSet();
            Get_set.TAnschreiben anschreiben = main.GetAnschreibenSet();
            Get_set.THandbuch handbuch = main.GetHandbuchSet();
            Get_set.TAnAdresse anadresse = main.GetAnAdresseSet();
            Get_set.TProgramms programms = main.GetProgrammsSet();
            Get_set.TInstallArt installart = main.GetInstallArtSet();
            Get_set.TAusstattung_Data ausstattung = main.GetAusstattungSet();
            Get_set.Twizt twizt = main.GetTwiztSet();

            MessageBox.Show(grund.grund);

            login lgn = new login();

            string uid, pw, server, port, db;
            uid = lgn.lgnList[0].uid;
            pw = lgn.lgnList[0].pw;
            server = lgn.lgnList[0].server;
            port = lgn.lgnList[0].port;
            db = lgn.lgnList[0].db;

            String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                //string name, ort, str, plz, partner, vertrags;
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand();
                //Datum,Time,Anliegen,Austausch,Erteilt,Ausgeführt,Post,Anschreiben,Handbuch,AnAdresseName,
                //AnAdresseLand,AnAdresseOrt,AnAdressePartner,AnAdressePLZ,KundenID,ProgrammID,InstallationsartID
                //VersandID,AustattungID,Anhänger,Test,Geprüft,Verschickt,DongleStammdatenID
                string sql = "INSERT INTO auftrag(Datum,Time,Anliegen,Grund,Erteilt,Ausgeführt,Post,Anschreiben,Handbuch,AnAdresseName," +
                    "AnAdresseLand,AnAdresseOrt,AnAdressePartner,AnAdressePLZ,KundenID,ProgrammID,InstallationsartID,VersandID,AusstattungsID," +
                    "Anhänger,Test,Geprüft,Verschickt,DongleStammdatenID)" +
                    "VALUES (?Date,?Time,?Anliegen,?Grund,?Erteilt,?Ausgeführt,?Post,?Anschreiben,?Handbuch,?AnAdresseName," +
                    "?AnAdresseLand,?AnAdresseOrt,?AnAdressePartner,?AnAdressePLZ,?KundenID,?ProgrammID,?InstallationsartID,?VersandID,?AusstattungsID," +
                    "?Anhaenger,?Test,?Geprueft,?Verschickt,?DongleStammdatenID)";
                cmd.CommandText = sql;


                TKundeAdresse kdadresse = new TKundeAdresse();
                cmd.Parameters.AddWithValue("?Date", dt.date);
                cmd.Parameters.AddWithValue("?Time", dt.timer);
                cmd.Parameters.AddWithValue("?Grund", grund.grund);
                cmd.Parameters.AddWithValue("?Austausch", grund.austausch);
                cmd.Parameters.AddWithValue("?Erteilt", auftrag.kuerzel);
                /*Mit einer kleinen Anwendung*/cmd.Parameters.AddWithValue("?Ausgeführt", ausgefuehrt.kuerzel);
                /*Mit einer kleinen Anwendung*/cmd.Parameters.AddWithValue("?Post", "1");
                cmd.Parameters.AddWithValue("?Anschreiben", anschreiben.anschreiben);
                cmd.Parameters.AddWithValue("?Handbuch", handbuch.handbuch);
                cmd.Parameters.AddWithValue("?AnAdresseName", anadresse.name);
                cmd.Parameters.AddWithValue("?AnAdresseLand", "1");
                cmd.Parameters.AddWithValue("?AnAdresseOrt", anadresse.ort);
                cmd.Parameters.AddWithValue("?AnAdressePartner", anadresse.ansprechpartner);
                cmd.Parameters.AddWithValue("?AnAdressePLZ", anadresse.plz);
                cmd.Parameters.AddWithValue("?KundenID", main.customerid);
                cmd.Parameters.AddWithValue("?ProgrammID", programms.id);
                cmd.Parameters.AddWithValue("?InstallationsartID", installart.id);
                cmd.Parameters.AddWithValue("?VersandID", "1");
                /* Mehrere möglich */cmd.Parameters.AddWithValue("?AusstattungsID", ausstattung.id);
                cmd.Parameters.AddWithValue("?Anhaenger", twizt.anhaenger);
                cmd.Parameters.AddWithValue("?Test", twizt.ewtest);
                cmd.Parameters.AddWithValue("?Geprueft", "1");
                cmd.Parameters.AddWithValue("?Verschickt", "1");
                /* Mehrere möglich */cmd.Parameters.AddWithValue("?DongleStammdatenID", "1");

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
