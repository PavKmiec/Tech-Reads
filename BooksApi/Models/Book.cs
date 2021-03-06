using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Book
    {
        [BsonId]
        public string _id { get; set; }

        //public string book_id { get; set; }

        public string[] authors { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string publisher { get; set; }

        public string year { get; set; }

        public string isbn { get; set; }

        public string coverImageUrl { get; set; }

        public string category { get; set; }

        //public decimal Price { get; set; }

        public decimal[] ratings { get; set; }

        public reviews[] reviews { get; set; }

    }

    public class reviews
    {
        public string reviewer { get; set; }
        public string review { get; set; }

    }
}
