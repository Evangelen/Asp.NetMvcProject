using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeaveManagementSystem.Models
{
    public class Education
    {
        [Key]
        public long EduId { get; set; }
        

        [Display(Name = "Level of Education")]
        public string EduLevel { get; set; }
        
        
        [Display(Name = "Year Of Passing")]
        public int EduYOP { get; set; }
        
        
        public List<Employees> EmpList { get; set; }
       
    }
}