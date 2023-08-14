using System.ComponentModel.DataAnnotations;

namespace ArtGallery.API.Dtos.Comment
{
    public class CommentEditDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "The field{0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Author { get; set; }

        [Required(ErrorMessage = "The field{0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string CommentValue { get; set; }
    }
}
