﻿using System.ComponentModel.DataAnnotations;

namespace ArtGallery.API.Dtos.Item
{
    public class ItemAddDto
    {
        [Required(ErrorMessage ="The field {0} is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field{0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        [RegularExpression(@"^(?![0-9]{4}).+",ErrorMessage ="Correct name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field{0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }
        
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string? Author { get; set; }
        public string? PictureUrl { get; set; }
        public string? MiniPictureUrl { get; set; }
        public double? Location { get; set; }
        public double? Price { get; set; }
        
    }
}
