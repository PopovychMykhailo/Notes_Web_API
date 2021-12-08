using System;



// Notes.Domain - Description of our essences. Business logic related to entities.

namespace Notes.Domain
{
    public class Note
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
