using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    [Table("RolOpcion")]
    public class RolOpcion
    {
        [Key]
        public int RolOpcionId { get; set; }

        public int OpcionId { get; set; }

        public int RolId { get; set; }

    }
}
