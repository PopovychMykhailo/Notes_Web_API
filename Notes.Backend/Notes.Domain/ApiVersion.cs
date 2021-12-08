using System;

namespace Notes.Domain
{
    public class ApiVersion
    {
        public Guid Id { get; set; }
        public string Version { get; init; }
        public string Description { get; init; }
    }
}
