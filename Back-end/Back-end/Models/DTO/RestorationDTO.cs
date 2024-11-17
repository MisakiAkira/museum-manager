namespace Back_end.Models.DTO
{
    public class RestorationDTO
    {
        public int restorerId { get; set; }

        public int paintingId { get; set; }

        public float cost { get; set; }

        public DateOnly startDate { get; set; }

        public DateOnly endDate { get; set; }
    }
}
