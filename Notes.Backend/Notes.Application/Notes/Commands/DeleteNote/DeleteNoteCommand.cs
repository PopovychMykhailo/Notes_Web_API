using System;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
