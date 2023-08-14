using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Models
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Author { get; set; }
        public double? Price { get; set; }
        public double? Location { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Category Category { get; set; }
    }
}
