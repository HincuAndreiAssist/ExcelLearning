using ExcelPost.Core;
using ExcelPost.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelPost.Service
{
    public interface IStudentService
    {
        Task<ResponseMessage> ImportExcel(IFormFile user);
    }
}
