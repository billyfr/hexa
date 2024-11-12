
using MonProjet.Core.Interfaces;
using MonProjetHexagonal.Core;

namespace MonProjetHexagonal.Application.Services
{
    public class FDESService : IFDESService
    {
        private readonly IFDESRepository _fdesRepository;

        public FDESService(IFDESRepository fdesRepository)
        {
            _fdesRepository = fdesRepository;
        }

        public async Task<FDESData> GetFDESDataAsync(string catalogVersion, string schemaElementId, string projectVersionId)
        {
            // Appel au repository pour récupérer les données FDES
            var fdes = await _fdesRepository.GetFDESDataAsync(catalogVersion, schemaElementId, projectVersionId);

            return new FDESData
            {
                CatalogVersion = fdes.CatalogVersion,
                SchemaElementId = fdes.SchemaElementId,
                ProjectVersionId = fdes.ProjectVersionId,
                Data = fdes.Data
            };
        }
    }
}
