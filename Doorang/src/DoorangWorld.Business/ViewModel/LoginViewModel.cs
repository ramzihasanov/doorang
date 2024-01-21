using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string username { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
