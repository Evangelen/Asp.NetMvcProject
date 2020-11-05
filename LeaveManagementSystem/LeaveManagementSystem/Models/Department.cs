using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementSystem.Models
{
    public class Department
    {
        [Key]
        public long DeptId { get; set; }

        
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        
        public List<Employees> EmpList { get; set; }
    }
}