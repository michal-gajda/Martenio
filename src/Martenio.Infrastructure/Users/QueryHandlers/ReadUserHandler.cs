namespace Martenio.Infrastructure.Users.QueryHandlers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Marten;
    using Martenio.Application.Users.Queries;
    using Martenio.Core.Users;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal sealed class ReadUserHandler : IRequestHandler<ReadUser, UserEntity>
    {
        private readonly ILogger<ReadUserHandler> logger;
        private readonly IDocumentStore store;

        public ReadUserHandler(ILogger<ReadUserHandler> logger, IDocumentStore store) =>
            (this.logger, this.store) = (logger, store);

        public Task<UserEntity> Handle(ReadUser request, CancellationToken cancellationToken)
        {
            using var session = this.store.LightweightSession();
            var user = session.Query<UserEntity>().Where(u => u.Id == request.Id).Single();

            return Task.FromResult(user);
        }
    }
}
