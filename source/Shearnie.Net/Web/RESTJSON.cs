using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shearnie.Net.Web
{
    public class RESTJSON
    {
        public static string GetSync(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var rs = client.GetAsync(url).Result;
                if (!rs.IsSuccessStatusCode) throw new Exception(rs.ReasonPhrase);

                return rs.Content.ReadAsStringAsync().Result;
            }
        }

        public static string PostSync(string url, List<KeyValuePair<string, string>> postData)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var rs = client.PostAsync(url, new FormUrlEncodedContent(postData)).Result;
                if (!rs.IsSuccessStatusCode) throw new Exception(rs.ReasonPhrase);

                return rs.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
