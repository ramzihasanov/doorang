using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Core.Entities
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength:50)]
        public string Fullname { get; set; }
    }
}
