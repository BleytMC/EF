namespace _016_Exam.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public int Discount { get; set; }

        public virtual List<Disc> Discs { get; set; } = new();
    }
}
