namespace _016_Exam.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Disc> Discs { get; set; } = new();
    }
}
