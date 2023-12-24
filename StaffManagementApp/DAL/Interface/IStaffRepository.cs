
using StaffManagementApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagementApp.DAL.Interface
{
    public interface IStaffRepository
    {
        Staff GetStaffById(int staffId);
        IEnumerable<Staff> GetAllStaffs();
        Staff AddStaff(Staff staff);
        Staff UpdateStaff(Staff staff);
        Staff DeleteStaff(int staffId);
    }
}