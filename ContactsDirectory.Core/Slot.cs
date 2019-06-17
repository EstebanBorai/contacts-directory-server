using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ContactsDirectory.Core
{
    public class Slot
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public SlotType Type { get; set; }
        public string CustomSlotType { get; set; }

        public Guid ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get;set; }
  }

    public enum SlotType
    {
        Mobile = 1,
        Work = 2,
        Home = 3,
        Main = 4,
        WorkFax = 5,
        HomeFax = 6,
        Pager = 7,
        Other = 8,
        Custom = 9
    }
}
