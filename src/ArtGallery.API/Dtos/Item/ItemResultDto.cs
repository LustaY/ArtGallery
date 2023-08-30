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
        public string? PictureUrl { get; set; }
        public string? MiniPictureUrl { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }  
    }
}
