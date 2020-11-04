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
    public class LeaveRequestsServices:ILeaveRequestsServices
    {
        ILeaveRequestsRepository RequestsRepository;

        public LeaveRequestsServices(ILeaveRequestsRepository repository)
        {
            this.RequestsRepository = repository;
        }

        public List<Leave> GetAllLeaves()
        {
            var leaveList = RequestsRepository.GetAllLeaves();
            return leaveList;
        }

        public List<Leave> GetLeavesWithEmployees()
        {
            List<Leave> leaveList = RequestsRepository.GetLeavesWithEmployees();
            return leaveList;
        }

        public void UpdateLeaveStatus(long id, Leave leave)
        {
            RequestsRepository.UpdateLeaveStatus(id, leave);
        }

        public Leave Viewdetails(long id)
        {
            Leave LeaveDet = RequestsRepository.Viewdetails(id);
            return LeaveDet;
        }
    }
}
