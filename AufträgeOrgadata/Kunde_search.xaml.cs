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

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für Kunde_search.xaml
    /// </summary>
    public partial class Kunde_search : Window
    {
        public Kunde_search()
        {
            InitializeComponent();
        }

        private void lvKundeSearch_Loaded(object sender, RoutedEventArgs e)
        {
            kundecs kdcs = new kundecs();

            for (int i = 0; i < kdcs.KundeFindList.Count; i++)
            {
                lvKundeSearch.Items.Add(new TKundeFind
                {
                    //IDFind = kdcs.KundeFindList[i].ID,
                    NameFind = kdcs.KundeFindList[i].NameFind,
                    OrtFind = kdcs.KundeFindList[i].OrtFind,
                    StrFind = kdcs.KundeFindList[i].StrFind,
                    PLZFind = kdcs.KundeFindList[i].PLZFind,
                    AnsprechpartnerFind = kdcs.KundeFindList[i].AnsprechpartnerFind,
                    VertragsNrFind = kdcs.KundeFindList[i].VertragsNrFind
                });
            }
        }
    }
}
