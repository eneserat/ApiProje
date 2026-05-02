namespace ApiProje.WebApi.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }

        public  string CategoryName { get; set; }
    }
}

