
using MongoDB.Driver;
using MonProjet.Core.Interfaces;
using MonProjetHexagonal.Core;

namespace MonProjetHexagonal.Infrastructure.Repositories
{
    public class FDESRepository : IFDESRepository
    {
        private readonly IMongoCollection<FDESData> _fdesCollection;

        public FDESRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("MonProjetDb");
            _fdesCollection = database.GetCollection<FDESData>("FDESData");
        }

        public async Task<FDESData> GetFDESDataAsync(string catalogVersion, string schemaElementId, string projectVersionId)
        {
            var filter = Builders<FDESData>.Filter.And(
                Builders<FDESData>.Filter.Eq(x => x.CatalogVersion, catalogVersion),
                Builders<FDESData>.Filter.Eq(x => x.SchemaElementId, schemaElementId),
                Builders<FDESData>.Filter.Eq(x => x.ProjectVersionId, projectVersionId)
            );

            return await _fdesCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
