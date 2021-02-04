namespace Martenio.Infrastructure.Users.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Marten;
    using Martenio.Application.Users.Commands;
    using Martenio.Core.Users;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal sealed class CreateUserHandler : IRequestHandler<CreateUser>
    {
        private readonly ILogger<CreateUserHandler> logger;
        private readonly IDocumentStore store;

        public CreateUserHandler(ILogger<CreateUserHandler> logger, IDocumentStore store) =>
            (this.logger, this.store) = (logger, store);

        public Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new UserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
            };

            using var session = this.store.LightweightSession();
            session.Store(user);
            session.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}