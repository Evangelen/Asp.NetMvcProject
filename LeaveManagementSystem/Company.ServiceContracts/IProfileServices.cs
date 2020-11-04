using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.ViewModels;


namespace Company.ServiceContracts
{
    public interface IProfileServices
    {
        Employees GetEmployee();

        void Edit(Employees currentEmployee, Employees newEmployee);

        string ChangePassword(Employees emp, ChangePassword model);

        List<Employees> SearchByRole(string search);
        List<Employees> SearchByName(string search);

    }
}
