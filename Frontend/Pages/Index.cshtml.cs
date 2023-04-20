using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly EmployeeContext _db;
    public IEnumerable<Employee> Employees { get; set; }
    public IndexModel(EmployeeContext db)
    {
        _db=db;
    }

    public void OnGet()
    {
        Employees = _db.dsEmployees;
    }
}
