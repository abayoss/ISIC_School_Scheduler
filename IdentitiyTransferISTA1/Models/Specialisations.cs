using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IdentitiyTransferISTA1.Models
{
    public class Specialisations
    {
        public Specialisations()
        {
            this.groups = new HashSet<Groups>();
        }
        [Key]
        [DisplayName("Spécialité")]
        public int id { get; set; }
        [DisplayName("Spécialité")]
        public string nomSpecialisation { get; set; }
        public virtual ICollection<Groups> groups { get; set; }

    }
}