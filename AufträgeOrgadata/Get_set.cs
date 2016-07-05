using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AufträgeOrgadata
{
    public class Get_set
    {
        public class TKundeAdresse
        {
            public string id { get; set; }
            public string name { get; set; }
            public string str { get; set; }
            public string ort { get; set; }
            public string plz { get; set; }
            public string ansprechpartner { get; set; }
        }

        public class TAnAdresse
        {
            public string name { get; set; }
            public string str { get; set; }
            public string ort { get; set; }
            public string plz { get; set; }
            public string ansprechpartner { get; set; }
        }

        public class TProgramms
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class TProgrammsList
        {
            public List<TProgramms> ProList { get; set; }
        }

        public class TInstallArt
        {
            public string id { get; set; }
            public string installart { get; set; }
            public string tuerfuellung { get; set; }
            public string stkusb { get; set; }
            public string stkzeit { get; set; }
            public bool server1 { get; set; }
            public bool server2 { get; set; }
        }

        public class TInstallList
        {
            public List<TInstallArt> InstallList { get; set; }
        }

        public class TGrund
        {
            public string grund { get; set; }
            public string austausch { get; set; }
        }

        public class TVNummer
        {
            public bool adkunden { get; set; }
            public string vnummer { get; set; }
            public string rnummer { get; set; }
            public string rnummer2 { get; set; }
            public string rnumemr3 { get; set; }
            public string zeitdongle { get; set; }
            public string serverdongle { get; set; }
            public bool autopro { get; set; }
        }

        public class Tstamm
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class TstammList
        {
            public List<Tstamm> StammListUebergabe { get; set; }
        }

        public class TAusstattung_Data
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class TAusstattung_List
        {
            public List<TAusstattung_Data> Ausstattung_DataList { get; set; }
        }

        public class Twizt
        {
            public bool express { get; set; }
            public bool tnt { get; set; }
            public bool mitarbeiter { get; set; }
            public bool anhaenger { get; set; }
            public bool ewtest { get; set; }
        }

        public class TKontroll
        {
            public string geprkuerzel { get; set; }
            public string delivkuerzel { get; set; }
            public bool donglegepr { get; set; }
            public bool verschickt { get; set; }
        }

        public class TAuftrag
        {
            public string kuerzel { get; set; }
        }

        public class TAusgefuehrt
        {
            public string kuerzel { get; set; }
            public string date { get; set; }
        }

        public class TPost
        {
            public string kuerzel { get; set; }
            public string date { get; set; }
        }

        public class TAnschreiben
        {
            public bool anschreiben { get; set; }
        }

        public class THandbuch
        {
            public bool handbuch { get; set; }
        }

        public class TGetCustomer
        {
            public string id { get; set; }
            public string name { get; set; }
            public string ort { get; set; }
            public string plz { get; set; }
            public string str { get; set; }
            public string partner { get; set; }
        }

        public class TDateTime
        {
            public string date { get; set; }
            public string timer { get; set; }
        }

        public class TLastIdentityDongle
        {
            public int id { get; set; }
        }
    }
}
