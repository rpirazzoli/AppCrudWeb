namespace AppCrudWeb.Model
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }

    public class ProductDto
    {

        public string Name { get; set; }
        public string Price { get; set; }


    }
}
