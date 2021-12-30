using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Productstore.Core
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public string Price { get; set; } = null!;

        public List<Image> Images { get; set; }

        public int TotalNumber { get; set; }

        public List<Booking> BookingInfo { get; set; }

        public int Availability { get; set; }
    }
}
