using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Company.DomainModels;

namespace Company.DomainModels
{
    public class Employees : IdentityUser
    {
        public Employees()
        {
            this.EmpEdu = new List<Education>();
        }


        [Display(Name = "Employee Name")]
        public string EmpName { get; set; }


        [Display(Name = "Employee Designation")]
        public string EmpPosition { get; set; }


        public string EmpRole { get; set; }


        [Display(Name = "Employee Email ID")]
        [EmailAddress(ErrorMessage = "Should be a valid email ID")]
        public string EmpEmailId { get; set; }



        [Column(TypeName = "varchar(MAX)")]
        public string ImageUrl { get; set; }


        public bool IsSpecialPermission { get; set; }


        public virtual long DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }


        public virtual List<Education> EmpEdu { get; set; }
    }
}