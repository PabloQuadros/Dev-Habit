namespace DevHabit.Api.DTOs.Auth;

public sealed record LoginUserDto
{
    public required string Email { get; init; }
    public string Password { get; init; }
}
