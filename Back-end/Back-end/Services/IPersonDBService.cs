using Back_end.Models.DTO;

namespace Back_end.Services
{
    public interface IPersonDBService
    {
        Task<IList<PersonDTO>> GetPersonList();
        Task<PersonDTO> GetPersonById(int id);
        Task<bool> DeletePerson(int id);
        Task<bool> PostPerson(PersonDTO person);
        Task<bool> PutPerson(PersonDTO person);
    }
}
