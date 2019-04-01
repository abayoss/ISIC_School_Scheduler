using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentitiyTransferISTA1.Models
{
    public class CycleSpecialisation
    {
        //    public CycleSpecialisation()
        //    {
        //        this.Groups = new HashSet<Groups>();
        //    }
        [Key]
        public int idCyclSpecial { get; set; }
        public int idCycle { get; set; }
        public int idSpecialisation { get; set; }

        //public virtual Cycles Cycles { get; set; }
        //public virtual Specialisations Specialisations { get; set; }
        //public virtual ICollection<Groups> Groups { get; set; }

    }
}