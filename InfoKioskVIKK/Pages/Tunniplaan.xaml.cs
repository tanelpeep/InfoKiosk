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
using Windows.UI.Popups;


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
                gruppButton.Click += NewButton_Click;
                gruppButton.Content = grupp.nimi;
                gruppButton.Tag = grupp.id;
                gruppButton.Style = (Style)App.Current.Resources["NimekiriNupudStyle"];
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

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Button newButton = sender as Button;
            string id = newButton.Tag.ToString();

            var popup = new MessageDialog("Valisid ID: " + id);
            popup.ShowAsync();
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
                ruumButton.Click += NewButton_Click;
                ruumButton.Content = ruum.nimi;
                ruumButton.Tag = ruum.id;
                ruumButton.Style = (Style)App.Current.Resources["NimekiriNupudStyle"];

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
            VeebileheAndmed andmed = new VeebileheAndmed();
            string sisu = await andmed.LaeVeebiandmed("nimekiri", "opetaja");

            var root = JsonConvert.DeserializeObject<OpetajaObject>(sisu);
            int counter = 1;
            foreach (var opetaja in root.opetaja)
            {
                Button opetajaButton = new Button();
                opetajaButton.Click += NewButton_Click;
                opetajaButton.Content = opetaja.nimi;
                opetajaButton.Tag = opetaja.id;
                opetajaButton.Style = (Style)App.Current.Resources["NimekiriNupudStyle"];

                if (counter == 1)
                {
                    OpetajaPanel1.Children.Add(opetajaButton);
                    counter = 2;
                }
                else if (counter == 2)
                {
                    OpetajaPanel2.Children.Add(opetajaButton);
                    counter = 3;
                }
                else if (counter == 3)
                {
                    OpetajaPanel3.Children.Add(opetajaButton);
                    counter = 1;
                }
            }
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
