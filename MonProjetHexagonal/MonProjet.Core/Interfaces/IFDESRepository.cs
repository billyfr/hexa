// MonProjet.Core/Interfaces/IUserRepository.cs
using MonProjet.Core.Entities;
using MonProjetHexagonal.Core;

namespace MonProjet.Core.Interfaces
{
    public interface IFDESRepository
    {
        Task<FDESData> GetFDESDataAsync(string catalogVersion, string schemaElementId, string projectVersionId);
    }
}
