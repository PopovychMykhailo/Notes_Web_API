using MediatR;
using System;

namespace Notes.Application.Notes.Commands.CreateNote
{
    // CreateNoteCommand - info for creation Note class

    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
