using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
