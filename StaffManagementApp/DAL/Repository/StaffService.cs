using StaffManagementApp.DAL.Interface;
using StaffManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffManagementApp.DAL.Repository
{
    public class StaffManagementService : IStaffInterface
    {
        private IStaffRepository _repo;
        public StaffManagementService(IStaffRepository repo)
        {
            this._repo = repo;
        }

        public Staff AddStaff(Staff staff)
        {
            return _repo.AddStaff(staff);
        }

        public Staff DeleteStaff(int staffId)
        {
            return _repo.DeleteStaff(staffId);
        }

        public IEnumerable<Staff> GetAllStaffs()
        {
            return _repo.GetAllStaffs();
        }

        public Staff GetStaffById(int staffId)
        {
            return _repo.GetStaffById(staffId);
        }

        public Staff UpdateStaff(Staff staff)
        {
            return _repo.UpdateStaff(staff);
        }
    }
}