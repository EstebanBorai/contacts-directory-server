using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ContactsDirectory.Core
{
    public class Date
    {
        public Guid Id { get; set; }
        public DateTime DateValue { get; set; }
        public string Label { get; set; }

        public Guid ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }
    }
}
