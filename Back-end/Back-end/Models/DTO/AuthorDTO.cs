using System.ComponentModel.DataAnnotations;

namespace Back_end.Models.DTO
{
    public class AuthorDTO
    {
        public int id { get; set; }

        [StringLength(250)]
        public string description { get; set; }
    }
}
