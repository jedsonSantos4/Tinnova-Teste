using System;

namespace AppCore.Model.Montadora
{
    public class Automovel
    {
        public Automovel()
        {
        }
        public string Id { get; set; }
        public string Veiculo { get; set; }

        public string Marca { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
        public bool Vendido { get; set; }
        public DateTime Update { get; set; }
        public DateTime Creat { get; set; }
    }
}
