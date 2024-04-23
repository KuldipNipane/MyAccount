using Microsoft.EntityFrameworkCore;
using MyAccount.Contracts;
using MyAccount.Data;
using MyAccount.Models;

namespace MyAccount.Repository
{
    #region Student Repository
    public class StudentRepository : IStudentRepository
    {
        #region Declaration
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region AddOrUpdate Student
        public async Task<StudentProfile> CreateOrUpdateAsync(StudentProfile student)
        {
            if (student != null && student.Id > 0)
            {
                _applicationDbContext.StudentProfiles.Update(student);
                await _applicationDbContext.SaveChangesAsync();
                return student;
            }
            else
            {
                _applicationDbContext.StudentProfiles.Add(student);
                await _applicationDbContext.SaveChangesAsync();
                return student;
            }
        }
        #endregion

        #region Delete Student
        public async Task DeleteAsync(int studentId)
        {
            _applicationDbContext.StudentProfiles.Remove(_applicationDbContext.StudentProfiles.Find(studentId));
            await _applicationDbContext.SaveChangesAsync();
        }
        #endregion

        #region Get Students

        public async Task<List<StudentProfile>> GetAllAsync()
        {
            return await _applicationDbContext.StudentProfiles.ToListAsync();
        }

        public async Task<StudentProfile?> GetAsync(int? studentId)
        {
            return await _applicationDbContext.StudentProfiles.FirstOrDefaultAsync(s => s.Id == studentId);
        }
        #endregion
    } 
    #endregion
}
