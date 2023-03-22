using VulcanizationAPI.Core.Entities.Abstract;

namespace VulcanizationAPI.Core.Entities
{
    public class User
        : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
