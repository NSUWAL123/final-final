using ApplicationDevelopment.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{
    public class UserRole
    {

        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }



    }
}
