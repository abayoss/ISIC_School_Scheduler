using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentitiyTransferISTA1.Models
{
    public class Groups
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Numero du Group")]
        public string numGroup { get; set; }
        [DisplayName("Schedule Url")]
        public string urlSched { get; set; }

        [DisplayName("Cycle d'etude")]
        public int idCycle { get; set; }

        [DisplayName("Spécialité")]
        public int idSpesialisation { get; set; }
        //public virtual CycleSpecialisation CycleSpecialisation { get; set; }

        [ForeignKey("idCycle")]
        public virtual Cycles Cycles { get; set; }

        [ForeignKey("idSpesialisation")]
        public virtual Specialisations Specialisations { get; set; }

        public Groups()
        {
            this.User = new HashSet<ApplicationUser>();
        }
        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}