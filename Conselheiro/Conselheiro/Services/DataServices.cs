using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Conselheiro.Model;
using Microsoft.CSharp;
using System.Data;

namespace Conselheiro.Services
{
    public class DataServices
    {
        public static async Task<Conselhos> GetConselhoRandom()
        {
            string queryString = "https://api.adviceslip.com/advice/";
            dynamic result = await getDataFromService(queryString).ConfigureAwait(false);

            if (result["slip"] != null)
            {
                Conselhos conselhos = new Conselhos();
                conselhos.Conselho = (string)result["slip"]["conselho"];
                conselhos.Slip_ID = (string)result["slip"]["id"];
                return conselhos;

            }
            else
            {
                return null;
            }


        }

        public static async Task<Conselhos> GetConselhoNum(string Conselho_Num)
        {
            string queryString = "https://api.adviceslip.com/advice/" + Conselho_Num;
            dynamic result = await getDataFromService(queryString).ConfigureAwait(false);

            if (result["slip"] != null)
            {
                Conselhos conselhos = new Conselhos();
                conselhos.Conselho = (string)result["slip"]["conselho"];
                conselhos.Slip_ID = (string)result["slip"]["id"];
                return conselhos;
            }
            else
            {
                return null;
            }
        }


        private static async Task<dynamic> getDataFromService(string queryString)
        {
            throw new NotImplementedException();

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<dynamic>(json);
            }
            return data;
        }
    }
}
