using Hackatown2020.Models.RSAQ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hackatown2020.Services
{
    public class RSAQService
    {
        const string BASE_URL = "http://ville.montreal.qc.ca/rsqa/servlet/makeXmlActuel";
        public RSAQService()
        {
        }
        public async Task<Response> GetDataFromRSAQ(DateTime today)
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                response = await client.GetAsync($"{BASE_URL}?date= {today.Year - 2000}{today.Month}{today.Day}");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Response));

            Response result;

            using (TextReader reader = new StringReader(response.Content.ToString()))
            {
                result = (Response)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
