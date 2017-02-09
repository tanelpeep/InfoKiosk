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
    public sealed partial class Tunniplaan : Page
    {
        public Tunniplaan()
        {
            this.InitializeComponent();
            LaeVeebiandmed();
        }

        public async void LaeVeebiandmed()
        {
            var veebileht = new HttpClient();
            HttpResponseMessage vastus = await veebileht.GetAsync(new Uri("https://vikk.siseveeb.ee/veebilehe_andmed/tunniplaan?nadal=06.02.2017&nimekiri=grupp"));
            var sisu = await vastus.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<RootObject>(sisu);
            foreach (var grupp in root.grupp)
            {
                sisuBlock.Text = sisuBlock.Text + grupp.nimi + System.Environment.NewLine;
            }


        }
        public class Grupp
        {
            public string id { get; set; }
            public string nimi { get; set; }
        }

        public class RootObject
        {
            public string nadal { get; set; }
            public List<Grupp> grupp { get; set; }
        }

    }
}
