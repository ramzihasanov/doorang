using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Updatedate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
