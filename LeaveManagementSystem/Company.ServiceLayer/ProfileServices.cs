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


namespace Company.ServiceLayer
{
    public class ProfileServices : IProfileServices
    {
        IProfileRepository profileRepository;

        public ProfileServices(IProfileRepository repository)
        {
            this.profileRepository = repository;
        }

        public string ChangePassword(Employees emp, ChangePassword model)
        {
            string status=profileRepository.ChangePassword(emp, model);
            return status;
        }

        public void Edit(Employees currentEmployee, Employees newEmployee)
        {
            profileRepository.Edit(currentEmployee, newEmployee);
        }

        public Employees GetEmployee()
        {
            Employees currentUser = profileRepository.GetEmployee();
            return currentUser;
        }

        public List<Employees> SearchByName(string search)
        {
            var empList = profileRepository.SearchByName(search);
            return empList;
        }

        public List<Employees> SearchByRole(string search)
        {
            var empList = profileRepository.SearchByRole(search);
            return empList;
        }
    }
}
