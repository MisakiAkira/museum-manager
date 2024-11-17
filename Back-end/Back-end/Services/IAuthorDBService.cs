using Back_end.Models.DTO;

namespace Back_end.Services
{
    public interface IAuthorDBService
    {
        Task<IList<AuthorDTO>> GetAuthorList();
        Task<AuthorDTO> GetAuthorById(int id);
        Task<bool> PostAuthor(AuthorDTO author);
        Task<bool> PutAuthor(AuthorDTO author);
        Task<bool> DeleteAuthor(int id);
    }
}
