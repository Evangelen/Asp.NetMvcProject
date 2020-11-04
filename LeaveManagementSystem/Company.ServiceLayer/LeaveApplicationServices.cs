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
    public class LeaveApplicationServices:ILeaveApplicationServices
    {
        ILeaveApplicationsRepository leaveApplicationsRepository;

        public LeaveApplicationServices(ILeaveApplicationsRepository repository)
        {
            this.leaveApplicationsRepository = repository;
        }

        public void CreateNewLeave(Leave newLeave)
        {
            leaveApplicationsRepository.CreateNewLeave(newLeave);
        }

        public void DeleteLeave(long id)
        {
            leaveApplicationsRepository.DeleteLeave(id);
        }

        public void EditLeave(long id, Leave newLeave)
        {
            leaveApplicationsRepository.EditLeave(id,newLeave);
        }

        public List<Leave> GetLeaveApplications()
        {
            List<Leave> leaveList = leaveApplicationsRepository.GetLeaveApplications();
            return leaveList;
        }

        public Leave GetLeaveWithId(long id)
        {
            Leave leave = leaveApplicationsRepository.GetLeaveWithId(id);
            return leave;
        }

        public List<LeaveStatus> GetStatuses()
        {
            List<LeaveStatus> leaveStatuses = leaveApplicationsRepository.GetStatuses();
            return leaveStatuses;
        }

        public List<TypeOfLeave> GetTypeOfLeaves()
        {
            List<TypeOfLeave> typeOfLeaves = leaveApplicationsRepository.GetTypeOfLeaves();
            return typeOfLeaves;
        }
    }
}
