namespace _003_OneToMany
{
    class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
