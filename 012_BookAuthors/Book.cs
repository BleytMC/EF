namespace _012_BookAuthors
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public float Price { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }
        public List<Author> Authors { get; set; }
    }
}
