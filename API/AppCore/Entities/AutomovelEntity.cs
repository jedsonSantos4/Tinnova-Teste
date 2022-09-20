using System;

namespace AppCore.Entities
{
    public class AutomovelEntity : BaseEntity
    {
        public string Veiculo { get; set; }

        public string Marca { get; set; }

        public int Ano { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public DateTime Updated { get; set; }
        public bool Vendido { get; set; }
    }
}
