using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.ViewModels;

namespace Company.RepositoryContracts
{
    public interface ILeaveRequestsRepository
    {
        List<Leave> GetLeavesWithEmployees();

        Leave Viewdetails(long id);

        void UpdateLeaveStatus(long id,Leave leave);

        List<Leave> GetAllLeaves();
    }
}
