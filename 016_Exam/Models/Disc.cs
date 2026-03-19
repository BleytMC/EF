namespace _016_Exam.Models
{
    public class Disc
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }
        public double Price { get; set; }

        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public int GanreId { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual Author Author { get; set; }
        public virtual Ganre Ganre { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int SongsCount { get; set; }

        public int Amount { get; set; }
        public int Sold { get; set; }
        public int Shelved { get; set; }

        public virtual List<Sale> Sales { get; set; } = new();
        public virtual List<ShelvedDiscs> ShelvedDiscs { get; set; } = new();
        public virtual List<Purchase> Purchases { get; set; } = new();
    }
}
