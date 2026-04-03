using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RazorMongo.Models
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public string? ModelName { get; set; }

        [Required]
        public string? SerialNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }
    }
}
