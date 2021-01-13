using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(Roles.Select(c => c.Value));
            }
            context.SaveChanges();
        }

            // Seed For Roles
        private static Dictionary<string, Role> roles;
        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (roles == null)
                {
                    var roleList = new Role[]
                    {
                        new Role { Name = "User" },
                        new Role { Name = "Admin"}
                    };

                    roles = new Dictionary<string, Role>();

                    foreach (Role role in roleList)
                    {
                        roles.Add(role.Name, role);
                    }
                }
                return roles;
            }
        }
    }

}
