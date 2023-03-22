namespace VulcanizationAPI.Core.Models.DTOs
{
    public class VulcanizationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<ServiceDto> Services { get; set; }

    }
}
