namespace _007_HW2
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
