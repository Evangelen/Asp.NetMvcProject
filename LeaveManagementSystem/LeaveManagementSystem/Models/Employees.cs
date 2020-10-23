using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeaveManagementSystem.Models
{
    public class Employees
    {
        public Employees()
        {
            this.EmpEdu = new List<Education>();
        }


        [Key]
        public long EmpId { get; set; }


        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }
 
        
        [Display(Name = "Employee Role")]
        public string EmpRole { get; set; }


        [Display(Name = "Employee Email ID")]
        [EmailAddress(ErrorMessage ="Should be a valid email ID")]
        public string EmpEmailId { get; set; }


        public virtual long DepartmentId { get; set; }


        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }


        public virtual List<Education> EmpEdu { get; set; }
    }
}