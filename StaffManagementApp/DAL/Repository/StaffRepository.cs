using StaffManagementApp.DAL.Interface;
using StaffManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StaffManagementApp.DAL.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private StaffDbContext _context;
        public StaffRepository(StaffDbContext Context)
        {
            this._context = Context;
        }
      
        public Staff GetStaffById(int staffId)
        {
            return _context.Staffs.Find(staffId);
        }

        public IEnumerable<Staff> GetAllStaffs()
        {
            return _context.Staffs.ToList();
        }

        public Staff AddStaff(Staff staff)
        {
            if (staff != null)
            {
                _context.Staffs.Add(staff);
                _context.SaveChanges(); // Save changes to the database
                return staff; // Return the added staff with the updated Id
            }
            else
            {
                // Handle the case where the input staff is null
                throw new ArgumentNullException(nameof(staff), "Staff object cannot be null");
            }
        }


        public Staff UpdateStaff(Staff updatedStaff)
        {
            if (updatedStaff != null)
            {
                var existingStaff = _context.Staffs.Find(updatedStaff.StaffId);

                if (existingStaff != null)
                {
                    // Update properties of the existing staff with the new values
                    _context.Entry(existingStaff).CurrentValues.SetValues(updatedStaff);
                    _context.SaveChanges(); // Save changes to the database
                    return existingStaff;
                }
                else
                {
                    // Handle the case where the staff with the given Id is not found
                    throw new ArgumentException($"Staff with Id {updatedStaff.StaffId} not found", nameof(updatedStaff));
                }
            }
            else
            {
                // Handle the case where the input staff is null
                throw new ArgumentNullException(nameof(updatedStaff), "Updated staff object cannot be null");
            }
        }

        public Staff DeleteStaff(int staffId)
        {
            var staffToDelete = _context.Staffs.Find(staffId);

            if (staffToDelete != null)
            {
                _context.Staffs.Remove(staffToDelete);
                _context.SaveChanges(); // Save changes to the database
                return staffToDelete;
            }
            else
            {
                // Handle the case where the staff with the given Id is not found
                throw new ArgumentException($"Staff with Id {staffId} not found", nameof(staffId));
            }
        }
    }
}
