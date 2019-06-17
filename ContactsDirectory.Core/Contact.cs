using System;
using System.Collections.Generic;

namespace ContactsDirectory.Core
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Avatar { get; set; }
        public bool Favorite { get; set; }
        public ICollection<Slot> Slots { get; set; }
        public ICollection<Date> Dates { get; set; }
    }
}
