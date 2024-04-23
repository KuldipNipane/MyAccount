using MyAccount.Models;

namespace MyAccount.Contracts
{
    public interface IStudentRepository
    {
        Task<StudentProfile?> GetAsync(int? categoryId);

        Task<List<StudentProfile>> GetAllAsync();

        Task<StudentProfile> CreateOrUpdateAsync(StudentProfile category);

        Task DeleteAsync(int categoryId);
    }
}
