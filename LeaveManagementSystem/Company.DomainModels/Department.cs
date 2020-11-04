using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Company.DomainModels
{
    public class Department
    {
        [Key]
        public long DeptId { get; set; }


        [Display(Name = "Department Name")]
        public string DeptName { get; set; }


        public virtual List<Employees> EmpList { get; set; }
    }
}
