namespace MSUAgent.Application.Models.Results;

public interface IResult<out T>
{
    T? Value { get; }
    bool IsError { get; }
    ErrorType? ErrorType { get; }
    string? ErrorMessage { get; }
}