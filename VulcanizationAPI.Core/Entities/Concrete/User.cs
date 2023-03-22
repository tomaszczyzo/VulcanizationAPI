using VulcanizationAPI.Core.Entities.Abstract;
using VulcanizationAPI.Core.Entities.Concrete;

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
        public virtual List<UserVulcanization> UserVulcanizations { get; set; }

    }
}
