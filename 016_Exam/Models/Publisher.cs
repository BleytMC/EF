namespace _016_Exam.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Disc> Discs { get; set; } = new();
    }
}
