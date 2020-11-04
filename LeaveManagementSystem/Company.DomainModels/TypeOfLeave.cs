using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company.DomainModels
{
    public class TypeOfLeave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LeaveTypeId { get; set; }


        public string LeaveTypeName { get; set; }
        
        
        public int LeavesPerYear { get; set; }


        public List<Leave> LeaveList { get; set; }
    }
}
