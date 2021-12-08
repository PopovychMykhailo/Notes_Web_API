using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Notes.Application.Common.Behavior
{
    public class ValidationBehavior<TRequst, TResponse> : 
        IPipelineBehavior<TRequst, TResponse> where TRequst : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequst>> _validators;


        public ValidationBehavior(IEnumerable<IValidator<TRequst>> validators)
            => _validators = validators;

        public Task<TResponse> Handle(TRequst requst, 
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequst>(requst);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}
