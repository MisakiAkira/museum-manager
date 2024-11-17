using System.ComponentModel.DataAnnotations;

namespace Back_end.Models.DTO
{
    public class PersonDTO
    {
        public int id { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        public char gender { get; set; }
    }
}
