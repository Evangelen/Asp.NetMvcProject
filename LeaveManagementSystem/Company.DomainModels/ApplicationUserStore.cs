using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Company.DomainModels
{
    public class ApplicationUserStore : UserStore<Employees>
    {
        public ApplicationUserStore(CompanyDbContext dbContext) : base(dbContext)
        {

        }
    }
}
