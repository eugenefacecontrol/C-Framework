using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Common.Internal;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    public class SettigsChecker
    {
        [Test]
        public void CheckSettings()
        {
            Console.WriteLine(TestSettings.ExplicitTimeout);
            TestSettings.GetAllSettings();
        }

        [Test]
        public static async Task GetProjects()
        {
            try
            {
                var personalaccesstoken = "lATfnbLusjvXvm8UheUb2900";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = await client.GetAsync(
                        "https://dev.azure.com/leaptestcompany/_apis/projects"))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
//                        return responseBody;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
