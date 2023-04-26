using Backend.Challenge.CQRS.Nomad;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Backend.Challenge.CQRS.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IResolver _resolver;

        public CommandDispatcher(IResolver resolver)
        {
            _resolver = resolver;
        }

        public async Task<Either<IAmAnError, TResult>> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : ICommandResult
        {
            // Find validator
            var validatorType = typeof(ICommandValidator<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var validator = (ICommandValidator<TCommand, TResult>?)_resolver.ResolveOptional(validatorType);

            // If validator found, validate the command
            if (validator != null)
            {
                var validationResult = validator.Verify(command);

                if (validationResult.Any()) return new ValidationErrorResult { ValidationErrors = validationResult };
            }

            // Find command handler
            ICommandHandler<TCommand, TResult> handler;
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            try
            {
                handler = (ICommandHandler<TCommand, TResult>)_resolver.Resolve(handlerType);
            }
            catch (Exception ex)
            {
                throw new CommandHandlerNotFoundException(command, ex);
            }

            // Execute command handler
            return await handler.Handle(command);
        }
    }
}
