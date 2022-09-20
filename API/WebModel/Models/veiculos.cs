using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Web.Model.Models
{

    public class veiculos
    {
        public veiculos()
        {
        }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("veiculo")]
        public string Veiculo { get; set; }
        [JsonProperty("marca")]
        public string Marca { get; set; }
        [JsonProperty("cor")]
        public string Cor { get; set; }
        [JsonProperty("ano")]
        public int Ano { get; set; }
        [JsonProperty("descricao")]
        public string Descricao { get; set; }
        [JsonProperty("update")]
        public DateTime Update { get; set; }
        [JsonProperty("creat")]
        public DateTime Creat { get; set; }
        [JsonProperty("vendido")]
        public bool Vendido { get; set; }
    }

    public class Frota
    {
        public List<veiculos> veiculos { get; set; }
    }

}
