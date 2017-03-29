using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
//using Windows.Data.Json;
using Newtonsoft.Json;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InfoKioskVIKK.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class Tunniplaan : Page
    {
        public Tunniplaan()
        {
            this.InitializeComponent();
            LoadItems();
            
            
        }
        

        public void LoadItems()
        {
            laeGrupid();
            laeRuumid();
            laeOpetajad();
        }
        
        public async void laeGrupid()
        {
            VeebileheAndmed andmed = new VeebileheAndmed();
            string sisu = await andmed.LaeVeebiandmed("nimekiri", "grupp");

            var root = JsonConvert.DeserializeObject<GruppObject>(sisu);
            int counter = 1;
            foreach (var grupp in root.grupp)
            {
                Button gruppButton = new Button();
                gruppButton.Content = grupp.nimi;
                gruppButton.Tag = grupp.id;
                if (counter == 1)
                {
                    GruppPanel1.Children.Add(gruppButton);
                    counter = 2;
                }
                else if (counter == 2)
                {
                    GruppPanel2.Children.Add(gruppButton);
                    counter = 3;
                }
                else if (counter == 3)
                {
                    GruppPanel3.Children.Add(gruppButton);
                    counter = 1;
                }

            }
        }
        public async void laeRuumid()
        {
            VeebileheAndmed andmed = new VeebileheAndmed();
            string sisu = await andmed.LaeVeebiandmed("nimekiri","ruum");

            var root = JsonConvert.DeserializeObject<RuumObject>(sisu);
            int counter = 1;
            foreach (var ruum in root.ruum)
            {
                Button ruumButton = new Button();
                ruumButton.Content = ruum.nimi;
                ruumButton.Tag = ruum.id;

                if (counter == 1)
                {
                    RuumPanel1.Children.Add(ruumButton);
                    counter = 2;
                }
                else if (counter == 2)
                {
                    RuumPanel2.Children.Add(ruumButton);
                    counter = 3;
                }
                else if (counter == 3)
                {
                    RuumPanel3.Children.Add(ruumButton);
                    counter = 1;
                }
            }
        }
        public async void laeOpetajad()
        {

        }

        public class Grupp
        {
            public string id { get; set; }
            public string nimi { get; set; }
        }

        public class Ruum
        {
            public string id { get; set; }
            public string nimi { get; set; }
        }

        public class Opetaja
        {
            public string id { get; set; }
            public string nimi { get; set; }
        }

        public class GruppObject
        {
            public string nadal { get; set; }
            public List<Grupp> grupp { get; set; }
        }
        public class RuumObject
        {
            public string nadal { get; set; }
            public List<Ruum> ruum { get; set; }
        }
        public class OpetajaObject
        {
            public string nadal { get; set; }
            public List<Opetaja> opetaja { get; set; }
        }

    }
}
