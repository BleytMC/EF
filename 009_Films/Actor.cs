namespace _009_Films
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Film> Films { get; set; }
    }
}
