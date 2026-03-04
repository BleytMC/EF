namespace _009_Films
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int StudioId { get; set; }

        public Studio Studio { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
