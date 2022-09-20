using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IMontadoraService : IBaseService<AutomovelEntity>
    {
        Task<ValidResult<List<AutomovelEntity>>> Get(string marca, string ano, string cor);
    }
}
