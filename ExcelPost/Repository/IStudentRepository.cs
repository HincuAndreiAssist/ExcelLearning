using ExcelPost.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelPost.Repository
{
    public interface IStudentRepository
    {
        Task<Student> InsertAsync(Student user);
        Task<List<Student>> GetAllUsersAsync();
    }
}
