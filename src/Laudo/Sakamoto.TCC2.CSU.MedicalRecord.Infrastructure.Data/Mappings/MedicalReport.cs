using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Mappings
{
    public class MedicalRecords
    {
        [BsonElement("Date")] [BsonRequired] public DateTime Date { get; set; }

        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("image")] public byte[] Image { get; set; }

        [BsonElement("LongDescription")]
        [BsonRequired]
        public string LongDescription { get; set; }

        [BsonElement("PatientId")]
        [BsonRequired]
        public Guid PatientId { get; set; }

        [BsonElement("PatientName")]
        [BsonRequired]
        public string PatientName { get; set; }

        [BsonElement("PractitionerId")]
        [BsonRequired]
        public Guid PractitionerId { get; set; }

        [BsonElement("PractitionerName")]
        [BsonRequired]
        public string PractitionerName { get; set; }

        [BsonElement("ShortDescription")]
        [BsonRequired]
        public string ShortDescription { get; set; }
    }
}