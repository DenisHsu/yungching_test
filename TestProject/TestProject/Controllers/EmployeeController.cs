using Microsoft.AspNetCore.Mvc;
using TestProject.Repositories;
using TestProject.Models;
using TestProject.Repositories.Interfaces;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// 取得所有員工資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        /// <summary>
        /// 取得單一員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        /// <summary>
        /// 新增員工資訊
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeModel employee)
        {
            var employeeId = await _employeeRepository.AddAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = employeeId }, employee);
        }

        /// <summary>
        /// 修改員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeModel employee)
        {
            if (id != employee.EmployeeID) return BadRequest();
            var result = await _employeeRepository.UpdateAsync(employee);
            return result > 0 ? NoContent() : NotFound();
        }

        /// <summary>
        /// 刪除員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeRepository.DeleteAsync(id);
            return result > 0 ? NoContent() : NotFound();
        }
    }
}
