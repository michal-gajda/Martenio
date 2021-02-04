namespace Martenio.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Martenio.Application.Users.Commands;
    using Martenio.Application.Users.Queries;
    using Martenio.Core.Users;

    [ApiController]
    [Route("[controller]")]
    public sealed class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post(CreateUser user)
        {
            _ = await this.mediator.Send(user);
            return await Task.FromResult(this.Ok());
        }

        [HttpGet("{id:guid}")]
        public async Task<UserEntity> Get(Guid id) =>
            await this.mediator.Send(new ReadUser { Id = id, });

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, UpdateUser user)
        {
            user.Id = id;
            _ = await this.mediator.Send(user);
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
