using System.Threading.Tasks;
using Web.Model.Models;

namespace Web.Model.Interface.Service
{
    public interface ILogarServ
    {

        Task<string> Casdastro(Register use);
        Task<string> Update(veiculos veic);
        Task<Frota> GetAll();
        Task<veiculos> GetId(string id);
        Task<Frota> GetId(string marca, string cor, string ano);
        Task<string> Delete(string id);

    }
}
