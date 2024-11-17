using Back_end.Models.DTO;

namespace Back_end.Services
{
    public interface IRestorerDBService
    {
        Task<IList<RestorerDTO>> GetRestorerList();
        Task<RestorerDTO> GetRestorerById(int id);
        Task<bool> DeleteRestorer(int id);
        Task<bool> PostRestorer(RestorerDTO restorer);
        Task<bool> PutRestorer(RestorerDTO restorer);
    }
}
