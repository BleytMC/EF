namespace _016_Exam.Models
{
    public class ShelvedDiscs
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int DiscId { get; set; }

        public User User { get; set; }
        public Disc Disc { get; set; }

        public int Amount { get; set; }
    }
}
