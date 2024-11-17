using System.ComponentModel.DataAnnotations;

namespace Back_end.Models.DTO
{
    public class PaintingDTO
    {
        public int id { get; set; }

        public int authorId { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public DateOnly paintingDate { get; set; }

        [StringLength(255)]
        public string description { get; set; }
    }
}
