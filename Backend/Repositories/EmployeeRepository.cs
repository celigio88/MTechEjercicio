using Backend.Data;
using Backend.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _db;
        const string ValidaRFC = "^[A-Za-zñÑ&]{3,4}\\d{6}\\w{3}$ ";

        public EmployeeRepository(EmployeeContext db)
        {
            _db = db;
        }
        public async Task<bool> Add(Employee emp)
        {
            if(!Regex.IsMatch(emp.RFC, ValidaRFC))
                return false;
            
            try
            {
                _db.Add(emp);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var emp = await GetById(id);
                if (emp == null)
                {
                    return false;
                }

                _db.dsEmployees.Remove(emp);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return (IEnumerable<Employee>)_db.dsEmployees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            var emp =  await _db.dsEmployees.FindAsync(id);
            return emp;
        }

        public async Task<IEnumerable<Employee>> GetByName(string name)
        {
            var emp =  await _db.dsEmployees.Where(x => x.Name.Contains(name))
                                            .ToListAsync();
            return emp;
        }

        public async Task<bool> Update(Employee emp)
        {
            if(!Regex.IsMatch(emp.RFC, ValidaRFC))
                return false;
            
            try
            {
                _db.Update(emp);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}