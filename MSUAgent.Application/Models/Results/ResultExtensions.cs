namespace MSUAgent.Application.Models.Results;

public static class ResultExtensions
{
    public static IResult<T> Success<T>(this T value)
    {
        return new Result<T>
        {
            Value = value
        };
    }

    public static IResult<T> Failure<T>(
        ErrorType errorType,
        string errorMessage)
    {
        return new Result<T>
        {
            ErrorType = errorType,
            ErrorMessage = errorMessage
        };
    }
    public static IResult<T> NotFound<T>(string errorMessage)
    {
        return Failure<T>(
            ErrorType.NotFound,
            errorMessage);
    }
}