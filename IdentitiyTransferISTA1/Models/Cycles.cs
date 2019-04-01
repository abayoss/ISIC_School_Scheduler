using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Web;
using System.ComponentModel;

namespace IdentitiyTransferISTA1.Models
{
    public class Cycles
    {
        public Cycles()
        {
            this.groups = new HashSet<Groups>();
        }
        [Key]
        [DisplayName("cycle d'etude")]
        public int id { get; set; }
        [DisplayName("Cycle d'etude")]
        public string Type_Cycle { get; set; }
        public virtual ICollection<Groups> groups { get; set; }
        //public virtual ICollection<CycleSpecialisation> CycleSpecialisations { get; set; }

    }
}