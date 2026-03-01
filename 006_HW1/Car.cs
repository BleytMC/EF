namespace _006_HW1
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Color { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public override string ToString()
        {
            return $"Id: {Id,-3}Name: {Name,-10}Price: {Price,-8}Color: {Color,-8}Release date: {ReleaseDate,-10}";
        }
    }
}
