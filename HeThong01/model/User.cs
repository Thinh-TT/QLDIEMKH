using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    public class User   
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        // Quan hệ n-n với Role
        public virtual ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }
    }
}
