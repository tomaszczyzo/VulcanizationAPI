namespace VulcanizationAPI.Core.Models.DTOs
{
    public class CreateServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
