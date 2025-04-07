using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
	private IMediator? _mediator;

	protected IMediator Mediator => _mediator ??=
		HttpContext.RequestServices.GetService<IMediator>()
		?? throw new InvalidOperationException("IMediator service is unavailable");

	// protected ActionResult HandleResult(Result<Game> result) {

	// }

	protected ActionResult HandleResult<T>(Result<T> result)
    {
        return result.StatusCode switch
        {
            200 => Ok(result.Value),
            201 => result.Value != null
                ? Created("", result.Value)
                : StatusCode(201),
            204 => NoContent(),
            400 => BadRequest(),
            404 => NotFound(),
            500 => StatusCode(500),
            _ => BadRequest("Unhandled response status")
        };
    }
}
