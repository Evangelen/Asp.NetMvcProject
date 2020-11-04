using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Company.DomainModels
{
    public class ApplicationUserManager : UserManager<Employees>
    {
        public ApplicationUserManager(IUserStore<Employees> store) : base(store)
        {

        }
    }
}
