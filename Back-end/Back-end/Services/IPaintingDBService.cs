using Back_end.Models.DTO;

namespace Back_end.Services
{
    public interface IPaintingDBService
    {
        Task<IList<PaintingDTO>> GetPaintingList();
        Task<PaintingDTO> GetPaintingById(int id);
        Task<bool> PostPainting(PaintingDTO painting);
        Task<bool> PutPainting(PaintingDTO painting);
        Task<bool> DeletePainting(int id);
    }
}
