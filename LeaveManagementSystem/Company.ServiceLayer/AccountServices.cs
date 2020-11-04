using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.ServiceContracts;
using Company.DomainModels;
using Company.ViewModels;
using Company.RepositoryContracts;
using Company.RepositoryLayer;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Company.ServiceLayer
{
    public class AccountServices : IAccountServices
    {
        IAccountRepository accountRepository;

        public AccountServices(IAccountRepository repository)
        {
            this.accountRepository = repository;
        }

        public void DeleteEmployee(Employees emp)
        {
            accountRepository.DeleteEmployee(emp);
        }

        public void EditEmployee(Employees currentEmployee, Employees newEmployee)
        {
            accountRepository.EditEmployee(currentEmployee, newEmployee);
        }

        public List<Employees> GetAllEmployees()
        {
            var EmployeeList = accountRepository.GetAllEmployees();
            return EmployeeList;
        }

        public List<Department> GetDepartments()
        {
            var deptList = accountRepository.GetDepartments();
            return deptList;
        }

        public Employees GetEmployeeById(string id)
        {
            var user = accountRepository.GetEmployeeById(id);
            return user;
        }

        public byte[] GetImage()
        {
            var byteArray= accountRepository.GetImage();
            return byteArray;
        }

        public Employees GetUserForLogin(LoginViewModel lvm)
        {
            Employees User = accountRepository.GetUserForLogin(lvm);
            return User;
        }

        public Employees Register(RegisterViewModel rvm)
        {
            Employees newEmp = accountRepository.Register(rvm);
            return newEmp;
        }

        public void UpdateUser(Employees newEmp)
        {
            accountRepository.UpdateUser(newEmp);
        }
    }
}
