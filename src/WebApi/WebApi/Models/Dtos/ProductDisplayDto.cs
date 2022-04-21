namespace WebApi.Models.Dtos
{
    public class ProductDisplayDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
    }
}
