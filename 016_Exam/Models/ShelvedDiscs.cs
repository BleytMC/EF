namespace _016_Exam.Models
{
    public class ShelvedDiscs
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int DiscId { get; set; }

        public virtual User User { get; set; }
        public virtual Disc Disc { get; set; }

        public int Amount { get; set; }
    }
}
