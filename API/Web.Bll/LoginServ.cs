using System.Threading.Tasks;
using Web.Model.Interface.Service;
using Web.Model.Models;
using WebModel.Interface.Repos;

namespace Web.Bll
{
    public class LoginServ : ILogarServ
    {
        private readonly ILogarRepo repo;
        public LoginServ(ILogarRepo logarRepo)
        {
            repo = logarRepo;
        }

        public async Task<string> Casdastro(Register use)
        {
            return await repo.Casdastro(use);
        }

        public async Task<string> Delete(string id)
        {
            return await repo.Delete(id);
        }

        public async Task<Frota> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<veiculos> GetId(string id)
        {
            return await repo.GetId(id);
        }

        public async Task<Frota> GetId(string marca, string cor, string ano)
        {
            return await repo.GetId(validTexto(marca), validTexto(cor), validTexto(ano));
        }

        public async Task<string> Update(veiculos veic)
        {
            return await repo.Update(veic);
        }

        private string validTexto(string val)
        {

            return string.IsNullOrEmpty(val) ? "%20" : val;
        }
    }
}
