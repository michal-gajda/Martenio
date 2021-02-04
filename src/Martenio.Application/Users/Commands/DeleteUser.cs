namespace Martenio.Application.Users.Commands
{
    using System;
    using MediatR;

    public sealed class DeleteUser : IRequest
    {
        public Guid Id { get; set; }
    }
}
