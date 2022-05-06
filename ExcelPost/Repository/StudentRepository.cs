using ExcelPost.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelPost.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<Student> dbSet;
        public StudentRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Student>();
        }
        public Task<List<Student>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> InsertAsync(Student student)
        {
            var result = (await dbSet.AddAsync(student)).Entity;
            await context.SaveChangesAsync();
            return result;
        }
    }
}
