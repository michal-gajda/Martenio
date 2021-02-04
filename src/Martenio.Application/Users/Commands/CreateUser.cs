namespace Martenio.Application.Users.Commands
{
    using MediatR;

    public sealed record CreateUser : IRequest
    {
        public string FirstName { get; init; }
        public string MiddleName { get; init; } = null;
        public string LastName { get; init; }
    }
}
