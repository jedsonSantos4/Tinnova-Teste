using System.Threading.Tasks;
using Web.Model.Models;

namespace WebModel.Interface.Repos
{
    public interface ILogarRepo
    {
        Task<string> Casdastro(Register use);
        Task<string> Update(veiculos veic);
        Task<Frota> GetAll();
        Task<veiculos> GetId(string id);
        Task<Frota> GetId(string marca, string cor, string ano);
        Task<string> Delete(string id);
    }
}
