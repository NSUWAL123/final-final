using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Shared
{
    public abstract class BaseEntity
    {
        public DateTime CreatedTime { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime DeletedTime { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public int DeletedBy { get; set; }
        public bool isDeleted { get; set; }
    }

    //public class ApplicationUser : IdentityUser
    //{
      //  public BaseEntity BaseEntity { get; set; }
    //}
}
