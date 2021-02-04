namespace Martenio.Infrastructure.Users.CommandHandlers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Marten;
    using Martenio.Application.Users.Commands;
    using Martenio.Core.Users;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal sealed class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        private readonly ILogger<DeleteUserHandler> logger;
        private readonly IDocumentStore store;

        public DeleteUserHandler(ILogger<DeleteUserHandler> logger, IDocumentStore store) =>
            (this.logger, this.store) = (logger, store);

        public Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            using var session = this.store.LightweightSession();
            var user = session.Query<UserEntity>().Where(u => u.Id == request.Id).Single();

            session.Delete(request.Id);
            session.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
