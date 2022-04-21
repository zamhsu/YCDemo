namespace WebApi.Models.Dtos
{
    public class ProductCreateDto
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
    }
}
