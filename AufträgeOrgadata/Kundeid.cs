using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AufträgeOrgadata
{
    class Kundeid
    {
        //public void KIDAbfrage()
        //{
        //    login lgn = new login();

        //    string uid, pw, server, port, db;
        //    uid = lgn.lgnList[0].uid;
        //    pw = lgn.lgnList[0].pw;
        //    server = lgn.lgnList[0].server;
        //    port = lgn.lgnList[0].port;
        //    db = lgn.lgnList[0].db;

        //    String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

        //    MySqlConnection conn = new MySqlConnection(connstring);

        //    try
        //    {
        //        //string name, ort, str, plz, partner, vertrags;
        //        conn.Open();

        //        MySqlCommand cmd = new MySqlCommand();
        //        string sql = "INSERT INTO kunden(name,ort,str,plz,ansprechpartner,vertragsnr) VALUES (?Name,?Ort,?Str,?PLZ,?Ansprechpartner,?VertragsNr)";
        //        cmd.CommandText = sql;

        //        cmd.Parameters.AddWithValue("?Name", kunde.name);
        //        cmd.Parameters.AddWithValue("?Ort", kunde.ort);
        //        cmd.Parameters.AddWithValue("?Str", kunde.str);
        //        cmd.Parameters.AddWithValue("?PLZ", kunde.plz);
        //        cmd.Parameters.AddWithValue("?Ansprechpartner", kunde.partner);
        //        cmd.Parameters.AddWithValue("?VertragsNr", kunde.vertrnr);

        //        cmd.Connection = conn;
        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

    }
}
