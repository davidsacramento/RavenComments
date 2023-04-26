using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS.Nomad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Challenge.Helpers
{
    public static class CommandResultToActionResultExtensions
    {
        public static Either<IAmAnError, IActionResult> ProcessRightResult(this Either<IAmAnError, GuidCommandResult> result)
        {
            return result.MapRight(x => (IActionResult)new OkObjectResult(x.Value));
        }

        public static Either<IAmAnError, IActionResult> ProcessRightResult(this Either<IAmAnError, EmptyCommandResult> result)
        {
            return result.MapRight(x => (IActionResult)new OkResult());
        }

        public static Either<IAmAnError, IActionResult> ProcessRightResult(this Either<IAmAnError, StringCommandResult> result)
        {
            return result.MapRight(x => (IActionResult)new OkObjectResult(x.Value));
        }

        public static Either<IAmAnError, IActionResult> ProcessValidationErrors(
            this Either<IAmAnError, IActionResult> result)
        {
            // If the left track contains validation errors, convert them to a BadRequest Response and return that
            if (result.GetLeft() is ValidationErrorResult validationErrors)
            {
                return new BadRequestObjectResult(validationErrors.ValidationErrors);
            }

            return result;
        }

        public static IActionResult ProcessOtherErrors(this Either<IAmAnError, IActionResult> result)
        {
            // If we already have an action result defined, we return that
            var actionResult = result.GetRight();
            if (actionResult != null) return actionResult;


            return new ObjectResult(result.GetLeft())
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}