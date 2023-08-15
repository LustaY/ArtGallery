using System.ComponentModel.DataAnnotations;

namespace ArtGallery.API.Dtos.Item
{
    public class ItemResultDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Author { get; set; }
        public double? Location { get; set; }
        public double? Price { get; set; }
    }
}
