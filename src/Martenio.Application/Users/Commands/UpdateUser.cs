namespace Martenio.Application.Users.Commands
{
    using System;
    using System.Text.Json.Serialization;
    using MediatR;

    public sealed class UpdateUser : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string FirstName { get; init; }
        public string MiddleName { get; init; } = null;
        public string LastName { get; init; }
    }
}
