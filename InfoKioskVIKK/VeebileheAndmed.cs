using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace InfoKioskVIKK
{
    class VeebileheAndmed
    {

        public static string LooKuupaev()
        {
            DayOfWeek monday = DayOfWeek.Monday;
            DateTime algus = DateTime.Today;

            while (algus.DayOfWeek != monday)
            {
                algus = algus.AddDays(-1);
            }
            string esmasp = algus.ToString("dd.MM.yyyy");

            return esmasp;
        }

        public string koostaURL(string nimekiri, string id)
        {
            string kuupaev = LooKuupaev();
            string url = "https://vikk.siseveeb.ee/veebilehe_andmed/tunniplaan?nadal=" + kuupaev + "&" + nimekiri + "=" + id;
            return url;
        }

        public async Task<string> LaeVeebiandmed(string nimekiri, string id)
        {
            string url = koostaURL(nimekiri,id);
            var veebileht = new HttpClient();
            HttpResponseMessage vastus = await veebileht.GetAsync(new Uri(url));
            string sisu = await vastus.Content.ReadAsStringAsync();
            return sisu;
        }
        

    }

    
}
