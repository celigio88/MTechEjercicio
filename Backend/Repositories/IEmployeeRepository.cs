using Backend.Models;

namespace Backend.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> Add(Employee emp);
        Task<bool> Update(Employee emp);
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetByName(string name);
        Task<bool> Delete(int id);
        Task<IEnumerable<Employee>> GetAll();
    }
}