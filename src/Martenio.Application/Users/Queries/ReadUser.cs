namespace Martenio.Application.Users.Queries
{
    using System;
    using MediatR;
    using Martenio.Core.Users;

    public sealed class ReadUser : IRequest<UserEntity>
    {
        public Guid Id { get; init; }
    }
}
