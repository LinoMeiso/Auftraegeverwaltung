using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Windows;
using System.Data;

namespace AufträgeOrgadata
{
    public class TLogin
    {
        public string uid { get; set; }
        public string pw { get; set; }
        public string server { get; set; }
        public string port { get; set; }
        public string db { get; set; }
        public string table { get; set; }
    }

    public class login
    {
        public List<TLogin> lgnList { get; set; }

        public login()
        {
            lgnList = new List<TLogin>();
            loadLogin();
        }

        public void loadLogin()
        {
            TLogin lgn = new TLogin();

            XmlDocument doc = new XmlDocument();
            doc.Load("login.xml");
            XmlNodeList ndList = doc.DocumentElement.SelectNodes("/AufträgeOrgadata/login");
            
            foreach(XmlNode node in ndList)
            {
                lgn.uid = node.SelectSingleNode("username").InnerText;
                lgn.pw = node.SelectSingleNode("password").InnerText;
                lgn.server = node.SelectSingleNode("server").InnerText;
                lgn.port = node.SelectSingleNode("port").InnerText;
                lgn.db = node.SelectSingleNode("database").InnerText;
            }
            lgnList.Add(lgn);
        }
    }
}
