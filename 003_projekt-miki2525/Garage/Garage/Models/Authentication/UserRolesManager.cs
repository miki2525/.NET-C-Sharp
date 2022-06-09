using System.Collections.Generic;

namespace Garage.Models.Authentication
{
    public class UserRolesManager
    {
        public string UserId { get; set; }
        public IList<UserRoles> UserRoles { get; set; }
    }
    public class UserRoles
    {
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
