using HeThong01.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01
{
    public static class AuthorizationHelper
    {
        public static bool IsInRole(User user, string roleName)
        {
            return user?.Roles?.Any(r => r.Name == roleName) == true;
        }

        public static bool IsAdmin(User user)
        {
            return IsInRole(user, "Admin");
        }

        public static bool IsStaff(User user)
        {
            return IsInRole(user, "Staff") || IsAdmin(user);
        }
    }
}
