using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.ViewModels;


namespace Company.RepositoryContracts
{
    public interface ILeaveApplicationsRepository
    {
        List<Leave> GetLeaveApplications();

        void CreateNewLeave(Leave newLeave);

        List<LeaveStatus> GetStatuses();

        List<TypeOfLeave> GetTypeOfLeaves();

        void EditLeave(long id, Leave newLeave);

        Leave GetLeaveWithId(long id);

        void DeleteLeave(long id);
    }
}
