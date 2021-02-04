namespace Martenio.Core.Users
{
    using System;

    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = null;
        public string LastName { get; set; }
    }
}
