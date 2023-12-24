using Microsoft.AspNetCore.Mvc;
using StaffManagementApp.DAL.Interface;
using StaffManagementApp.Models;

namespace StaffManagementApp.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffInterface _staffRepository;

        public StaffController(IStaffInterface staffRepository)
        {
            _staffRepository = staffRepository;
        }

        // GET: /Staff/Index
        public IActionResult Index()
        {
            var staffs = _staffRepository.GetAllStaffs();
            return View(staffs);
        }

        // GET: /Staff/Details/{id}
        public IActionResult Details(int id)
        {
            var staff = _staffRepository.GetStaffById(id);

            if (staff == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(staff);
        }

        // GET: /Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _staffRepository.AddStaff(staff);
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: /Staff/Edit/{id}
        public IActionResult Edit(int id)
        {
            var staff = _staffRepository.GetStaffById(id);

            if (staff == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(staff);
        }

        // POST: /Staff/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Staff updatedStaff)
        {
            if (id != updatedStaff.StaffId)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _staffRepository.UpdateStaff(updatedStaff);
                }
                catch (ArgumentException)
                {
                    return NotFound(); // 404 Not Found
                }

                return RedirectToAction("Index");
            }

            return View(updatedStaff);
        }

        // GET: /Staff/Delete/{id}
        public IActionResult Delete(int id)
        {
            var staff = _staffRepository.GetStaffById(id);

            if (staff == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(staff);
        }

        // POST: /Staff/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deletedStaff = _staffRepository.DeleteStaff(id);

            if (deletedStaff == null)
            {
                return NotFound(); // 404 Not Found
            }

            return RedirectToAction("Index");
        }
    }
}
