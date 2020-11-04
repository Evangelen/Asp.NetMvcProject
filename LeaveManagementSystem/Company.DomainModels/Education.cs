using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Company.DomainModels;

namespace Company.DomainModels
{
    public class Education
    {
        [Key]
        public long EduId { get; set; }


        [Display(Name = "Level of Education")]
        public string EduLevel { get; set; }


        [Display(Name = "Year Of Passing")]
        public int EduYOP { get; set; }


        public virtual Employees EmpList { get; set; }

    }
}
