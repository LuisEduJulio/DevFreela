using DevFreela.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Core
{
    public class MediatorPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly IEnumerable<IValidator> _validators;

        public MediatorPipeline(
            IRequestHandler<TRequest, TResponse> inner,
            IEnumerable<IValidator<TRequest>> validators)
        {
            _inner = inner;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(v => v.Validate((IValidationContext)request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null).ToList();

            if (failures.Any())
                throw new CustomException(failures.First().ErrorMessage);

            return await _inner.Handle(request, cancellationToken);
        }
    }
}