using MonProjetHexagonal.Core;

namespace MonProjetHexagonal.Application
{
    public interface IFDESService
    {
        Task<FDESData> GetFDESDataAsync(string catalogVersion, string schemaElementId, string projectVersionId);
    }
}
