using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class NotFoundException(string message)
	: ServiceException(StatusCodes.Status404NotFound, message)
{
}
