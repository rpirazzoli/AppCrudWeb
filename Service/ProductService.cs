using AppCrudWeb.Model;
using AppCrudWeb.Dto;


namespace AppCrudWeb.Service
{
    public class ProductService : CrudServiceBase<Product, ProductDto>
    {
        private static List<Product> repository = new List<Product>
    {
        new Product { Id = 1, Name = "Prodotto 1", Price = 10 },
        new Product { Id = 2, Name = "Prodotto 2", Price = 20 }
    };

        private int _idCounter = repository.Max(x => x.Id) + 1;

        protected override Product Insert(Product product)
        {
            product.Id = _idCounter++;
            repository.Add(product);
            return product;
        }
        protected override Product Get(int id)
        {
            var entity = repository.FirstOrDefault(x => x.Id == id);
            return entity != null ? entity : default;
        }

        protected override Product Modifica(Product entity, ProductDto dto)
        {
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            return entity;
        }
        protected override bool Cancella(int id)
        {
            var entity = Get(id);

            repository.Remove(entity);
            return true;

        }
        protected override IEnumerable<Product> OttieniTutti()
        {
            return repository;
        }

        //---------------------- 

        protected override Product MapToEntity(ProductDto dto)
        {
            return new Product
            {

                Name = dto.Name,
                Price = dto.Price
            };
        }

        protected override ProductDto MapToDto(Product entity)
        {
            return new ProductDto
            {

                Name = entity.Name,
                Price = entity.Price
            };
        }

    }
}
