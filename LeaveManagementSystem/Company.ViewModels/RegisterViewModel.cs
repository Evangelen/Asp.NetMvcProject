using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Company.DomainModels;

namespace Company.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Password { get; set; }


        [Required]
        [Compare("Password", ErrorMessage = "Does not match")]
        public string ConfirmPassword { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Designation { get; set; }

        public string Role { get; set; }


        public bool IsSpecialPermission { get; set; }

        public List<Education> EmpEdu { get; set; }

        public string ImageUrl { get; set; }


        [Display(Name = "Department")]
        public long DepartmentID { get; set; }

    }
}
