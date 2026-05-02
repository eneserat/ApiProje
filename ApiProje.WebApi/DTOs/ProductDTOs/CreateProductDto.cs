using ApiProje.WebApi.Entities;

namespace ApiProje.WebApi.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
      
        public string ProductName { get; set; }
        public int ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
      
    }
}
