namespace _007_HW2
{
    public class House
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public int StreetId { get; set; }

        public Street Street { get; set; }
    }
}
