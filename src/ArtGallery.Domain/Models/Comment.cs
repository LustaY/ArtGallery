using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Models
{
    public class Comment : Entity
    {
        public int ItemId { get; set; }
        public string Author { get; set; }
        public string CommentValue { get; set; }

        public Item Item { get; set; }
    }
}
