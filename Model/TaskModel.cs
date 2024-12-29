
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManager.Model
{
    public class TaskModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] 
            
        public String? TaskId { get; set; }
        public String TaskName { get; set; }= null!;
        public String? TaskDescription { get; set; }= null!;
        public Boolean TaskStatus { get; set; } = false;
        
        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}