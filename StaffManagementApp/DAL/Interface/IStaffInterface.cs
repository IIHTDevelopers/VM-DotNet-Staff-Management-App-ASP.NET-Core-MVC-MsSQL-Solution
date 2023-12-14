using StaffManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagementApp.DAL.Interface
{
    public interface IStaffInterface 
    {
        Staff GetStaffById(int staffId);
        IEnumerable<Staff> GetAllStaffs();
        Staff AddStaff(Staff staff);
        Staff UpdateStaff(Staff staff);
        Staff DeleteStaff(int staffId);
    }
}