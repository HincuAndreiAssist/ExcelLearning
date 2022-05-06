using ExcelPost.Core;
using ExcelPost.Dtos;
using ExcelPost.Repository;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelPost.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<ResponseMessage> ImportExcel(IFormFile batchStudents)
        {
            if(batchStudents?.Length >0)
            {
                var stream = batchStudents.OpenReadStream();

                List<Student> students = new List<Student>();

                try
                {
                    using(var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;

                        for (var row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                var name = worksheet.Cells[row, 1].Value?.ToString();
                                var surname = worksheet.Cells[row, 2].Value?.ToString();
                                var age = worksheet.Cells[row, 3].Value?.ToString();
                                var city = worksheet.Cells[row, 4].Value?.ToString();

                                var student = new Student()
                                {
                                    Name = name,
                                    Surname = surname,
                                    Age = int.Parse(age),
                                    City = city
                                };

                                //students.Add(student);
                                await studentRepository.InsertAsync(student);


                            }
                            catch (Exception)
                            {

                                throw new NotImplementedException();
                            }
                        }
                    }
                    ResponseMessage _response = new ResponseMessage()
                    {
                        Message = "SuperDuper"
                    };

                    return _response;
                }
                catch (Exception ex)
                {

                    throw new NotImplementedException();
                }
            }

            ResponseMessage response = new ResponseMessage()
            {
                Message = "SuperDuper"
            };

            return response;

        }
    }
}
