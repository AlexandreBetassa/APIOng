using ApiOng.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using MongoDB.Bson;
using System;

namespace ApiOng.Repositories
{
    public class AdressRepository
    {
        public AdressRepository() { }
        //{
        //    _adress = new HttpClient();

        //}

        public async Task<String> GetAdress(string cep)
        {
            using (HttpClient _adressClient = new HttpClient())
            {
                HttpResponseMessage response = await _adressClient.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                var adress = await response.Content.ReadAsStringAsync();
                return adress;
            }
        }
    }
}
