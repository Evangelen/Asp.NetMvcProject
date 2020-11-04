using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company.DomainModels
{
    public class LeaveStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StatusId { get; set; }


        public string StatusName { get; set; }


        public string StatusDescription { get; set; }


        public List<Leave> LeaveList { get; set; }
    }
}
