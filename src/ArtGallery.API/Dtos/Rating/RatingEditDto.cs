using System.ComponentModel.DataAnnotations;

namespace ArtGallery.API.Dtos.Rating
{
    public class RatingEditDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "The field{0} is required")]
        public int RatingValue { get; set; }
    }
}
