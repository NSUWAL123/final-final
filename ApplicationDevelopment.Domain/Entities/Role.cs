using ApplicationDevelopment.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{
    public class Role : IdentityRole
    {

        public ICollection<UserRole> UserRole { get; set; }
    }
}
