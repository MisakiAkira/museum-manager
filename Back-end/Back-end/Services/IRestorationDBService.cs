using Back_end.Models.DTO;

namespace Back_end.Services
{
    public interface IRestorationDBService
    {
        Task<IList<RestorationDTO>> GetRestorationList();
        Task<RestorationDTO> GetRestorationById(int restorerId, int paintingId);
        Task<bool> DeleteRestoration(int restorerId, int paintingId);
        Task<bool> PostRestoration(RestorationDTO restoration);
        Task<bool> PutRestoration(RestorationDTO restoration);
    }
}
