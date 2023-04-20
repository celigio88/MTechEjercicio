using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Frontend.Pages
{
    [BindProperties]
    public class Create : PageModel
    {
        private readonly EmployeeContext _db;
    
        public Employee Employee { get; set; }

        public Create(EmployeeContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _db.dsEmployees.AddAsync(Employee);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}