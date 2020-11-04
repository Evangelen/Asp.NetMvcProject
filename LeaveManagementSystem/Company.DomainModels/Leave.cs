using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company.DomainModels
{
    public class Leave
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LeaveId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public int NoOfDays { get; set; }
        
        public string Cause { get; set; }



        public virtual long LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual TypeOfLeave TypeOfLeave { get; set; }


        
        public virtual long StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual LeaveStatus LeaveStatus { get; set; }


        
        //public virtual string EmpId { get; set; }
        
        //[ForeignKey("EmpId")]
        public virtual Employees Employees { get; set; }
    }
}
