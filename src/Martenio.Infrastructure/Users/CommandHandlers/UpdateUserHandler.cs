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

    internal sealed class UpdateUserHandler : IRequestHandler<UpdateUser>
    {
        private readonly ILogger<UpdateUserHandler> logger;
        private readonly IDocumentStore store;

        public UpdateUserHandler(ILogger<UpdateUserHandler> logger, IDocumentStore store) =>
            (this.logger, this.store) = (logger, store);

        public Task<Unit> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            using var session = this.store.LightweightSession();
            var user = session.Query<UserEntity>().Where(u => u.Id == request.Id).Single();

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.MiddleName = request.MiddleName;

            session.Store(user);
            session.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
