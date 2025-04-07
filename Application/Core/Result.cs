namespace Application.Core;

public class Result<T>
{
	public int StatusCode { get; set; }
	public T? Value { get; set; }

	public static Result<T> Success(int statusCode, T value) => new()
	{
		StatusCode = statusCode,
		Value = value,
	};

	public static Result<T> Failure(int statusCode) => new()
	{
		StatusCode = statusCode,
	};
}
