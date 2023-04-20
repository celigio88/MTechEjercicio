using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Pages
{
    [BindProperties]
    public class Edit : PageModel
    {
        private readonly EmployeeContext _db;
    
        public Employee Employee { get; set; }

        public Edit(EmployeeContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Employee = _db.dsEmployees.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var emp = _db.dsEmployees.Find(Employee.ID);
            
            if(emp != null)
            {
                _db.dsEmployees.Update(emp);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            
            return Page();
        }
    }
}