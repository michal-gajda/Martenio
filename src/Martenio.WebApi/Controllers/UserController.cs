namespace Martenio.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Martenio.Application.Users.Commands;
    using Martenio.Application.Users.Queries;
    using Martenio.Core.Users;
    using Martenio.WebApi.Models;

    [ApiController]
    [Route("[controller]")]
    public sealed class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _ = await this.mediator.Send(new CreateUser { FirstName = user.FirstName, LastName = user.LastName, MiddleName = user.MiddleName, });
            return await Task.FromResult(this.Ok());
        }

        [HttpGet("{id:guid}")]
        public async Task<UserEntity> Get(Guid id) =>
            await this.mediator.Send(new ReadUser { Id = id, });

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, User user)
        {
            _ = await this.mediator.Send(new UpdateUser { FirstName = user.FirstName, Id = id, LastName = user.LastName, MiddleName = user.MiddleName, });
            return await Task.FromResult(this.Ok());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _ = await this.mediator.Send(new DeleteUser { Id = id, });
            return await Task.FromResult(this.Ok());
        }
    }
}
