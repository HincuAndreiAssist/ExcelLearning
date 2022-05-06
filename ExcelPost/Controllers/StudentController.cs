using ExcelPost.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelPost.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;



        public StudentController(IConfiguration configuration, IStudentService studentService)
        {
            this.studentService = studentService;

        }

        [HttpPost]
        [Route("import-excel")]
        public async Task<ActionResult> PostStudents(IFormFile excel)
        {
            var response = await studentService.ImportExcel(excel);

            return Ok(response);
        }
    }
}
