using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Employees>>>GetEmployees()
        {
            var employees = _context.Employee.ToListAsync();
             return await employees;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Employees>>GetEmployeesById(int id)
        {
            var employee = _context.Employee.FindAsync(id);
            return await employee;
        }

    }
}