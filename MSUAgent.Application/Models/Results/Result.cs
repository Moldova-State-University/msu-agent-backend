namespace MSUAgent.Application.Models.Results;

public class Result<T> : IResult<T>
{
    public T? Value { get; init; }
    public bool IsError => ErrorType is not null;
    public ErrorType? ErrorType { get; init; }
    public string? ErrorMessage { get; init; }
}