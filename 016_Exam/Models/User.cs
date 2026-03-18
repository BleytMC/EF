namespace _016_Exam.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public List<ShelvedDiscs> ShelvedDiscs { get; set; } = new();
        public List<Purchase> Purchases { get; set; } = new();
    }
}
