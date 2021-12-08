﻿using System;
using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(note => note.Title).NotEmpty().MaximumLength(250);
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }
    }
}
