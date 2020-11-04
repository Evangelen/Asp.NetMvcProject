using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.ViewModels;

namespace Company.RepositoryContracts
{
    public interface IAccountRepository
    {
        Employees Register(RegisterViewModel rvm);
        Employees GetUserForLogin(LoginViewModel lvm);
        List<Employees> GetAllEmployees();
        Employees GetEmployeeById(string id);
        void EditEmployee(Employees currentEmployee, Employees newEmployee);
        void DeleteEmployee(Employees emp);
        List<Department> GetDepartments();
        byte[] GetImage();
        void UpdateUser(Employees newEmp);
    }
}
