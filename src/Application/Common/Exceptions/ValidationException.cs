﻿using FluentValidation.Results;

namespace CleanArchitecture.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base(Messages.ValidationException)
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}
