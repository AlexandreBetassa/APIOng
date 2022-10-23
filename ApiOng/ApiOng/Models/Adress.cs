using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace ApiOng.Models
{
    public class Adress
    {
        [BsonId]
        public string Id { get; set; }
        public string Cep { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }


        /*
         *         [JsonProperty("cep")]
        public string CEP { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string UF { get; set; }
        [JsonProperty("unidade")]
        public string Unidade { get; set; }
        [JsonProperty("ibge")]
        public string IBGE { get; set; }
        [JsonProperty("gia")]
        public string Gia { get; set; }
         * */
    }
}
