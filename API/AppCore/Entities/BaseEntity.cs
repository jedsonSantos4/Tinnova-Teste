using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AppCore.Entities
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions]
        [BsonElement("createIndexes")]
        public DateTime Created { get; set; }

        public int __v { get; set; }

        public BaseEntity()
        {
            this.Created = DateTime.UtcNow;
        }
    }
}
