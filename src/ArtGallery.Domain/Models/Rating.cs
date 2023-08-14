namespace ArtGallery.Domain.Models
{
    public class Rating : Entity
    {
        public int? RatingValue { set; get; }
        public int ItemId { set; get; }

        public Item Item { set; get; }

    }
}
