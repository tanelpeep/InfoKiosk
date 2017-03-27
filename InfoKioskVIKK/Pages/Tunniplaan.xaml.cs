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

        public void LaeVeebiandmed()
        {
            DateTime today = DateTime.Now;
            String sisu = today.ToString("dd.MM.yyyy");
            sisuBlock.Text = sisu;
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
