using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongodbWithApi.Model
{
    [BsonIgnoreExtraElements]
    public class Students
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? StudentName{ get; set; }

        public int Age { get; set; }

        public string? Education { get; set; }

        public bool FurtherEducation { get; set; }
    }
}
