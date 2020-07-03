using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OktaSolution.Models
{
    public class SubMission
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
