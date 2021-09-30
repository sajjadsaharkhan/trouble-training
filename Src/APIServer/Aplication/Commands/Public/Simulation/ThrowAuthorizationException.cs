using MediatR;
using System.Threading;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIServer.Persistence;
using SharedCore.Aplication.Shared.Attributes;
using Aplication.Payload;

namespace APIServer.Aplication.Commands.WebHooks {

    /// <summary>
    /// Command for testing authorization exception
    /// </summary>
    [Authorize(Roles ="NotExistingRole")]
    public class ThrowAuthorizationException : IRequest<ThrowAuthorizationExceptionPayload> {
        public ThrowAuthorizationException() {

        }
    }

    /// <summary>
    /// ThrowAuthorizationException Validator
    /// </summary>
    public class ThrowAuthorizationExceptionValidator : AbstractValidator<ThrowAuthorizationException> {

        private readonly IDbContextFactory<ApiDbContext> _factory;

        public ThrowAuthorizationExceptionValidator(IDbContextFactory<ApiDbContext> factory){
            _factory = factory;
        }

    }

    /// <summary>
    /// IThrowAuthorizationExceptionError
    /// </summary>
    public interface IThrowAuthorizationExceptionError { }

    /// <summary>
    /// ThrowAuthorizationExceptionPayload
    /// </summary>
    public class ThrowAuthorizationExceptionPayload : BasePayload<ThrowAuthorizationExceptionPayload, IThrowAuthorizationExceptionError> {

    }

    /// <summary>Handler for <c>ThrowAuthorizationException</c> command </summary>
    public class ThrowAuthorizationExceptionHandler : IRequestHandler<ThrowAuthorizationException, ThrowAuthorizationExceptionPayload> {

        private static bool IsEnabled = true;

        /// <summary>
        /// Main constructor
        /// </summary>
        public ThrowAuthorizationExceptionHandler() {

        }

        /// <summary>
        /// Command handler for <c>ThrowAuthorizationException</c>
        /// </summary>
        public async Task<ThrowAuthorizationExceptionPayload> Handle(ThrowAuthorizationException request, CancellationToken cancellationToken) {
            
                return ThrowAuthorizationExceptionPayload.Success();
        }
    }
}