using AppCore.Entities;
using AppCore.Interface.Repositores;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class MontadoraRepository : BaseRepository<AutomovelEntity>, IMontadoraRepository
    {
        public MontadoraRepository(IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle)
            : base(mongoClient, clientSessionHandle, "fabrica")
        {
        }


    }


}

