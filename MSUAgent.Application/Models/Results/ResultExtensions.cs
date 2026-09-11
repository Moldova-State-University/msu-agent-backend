namespace MSUAgent.Application.Models.Results;

public static class ResultExtensions
{
    public static IResult<T> Success<T>(this T value)
    {
        return new Result<T>
        {
            Value = value,
            IsError = false
        };
    }

    public static IResult<T> Failure<T>(
        ErrorType errorType,
        string errorMessage)
    {
        return new Result<T>
        {
            IsError = true,
            ErrorType = errorType,
            ErrorMessage = errorMessage
        };
    }
}