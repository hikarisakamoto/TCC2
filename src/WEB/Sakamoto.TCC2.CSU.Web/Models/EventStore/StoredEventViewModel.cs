using System;
using Newtonsoft.Json;

namespace Sakamoto.TCC2.CSU.Web.Models.EventStore
{
    public class StoredEventViewModel
    {
        private string _data;

        public Guid AggregateId { get; set; }

        public string Data
        {
            //get => JsonSerializer.(_data, Formatting.Indented);
            //set => _data = value;

            get;
            set;
        }

        public Guid Id { get; set; }

        public string MessageType { get; set; }

        public string User { get; set; }
    }
}