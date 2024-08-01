using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; } 
        public string Description { get; set; }
        public string Address { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
