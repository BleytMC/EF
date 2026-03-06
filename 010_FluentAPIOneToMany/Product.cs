namespace _010_FluentAPIOneToMany
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Info { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
