using BusinessLogic;
using CommonInterfaces.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebComputrabajo.Controllers
{
    [Route("api/redarbor")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeBusiness business = new EmployeeBusiness();
        private readonly ILogger logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("Test")]
        public string GetTest()
        {
            return "OK - Service Up";
        }

        [HttpGet]
        public ObjectResult Get()
        {
            List<Employee> employees = null;
            try
            {
                employees = business.GetEmployees();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ObjectResult GetById(int id)
        {
            Employee employee = new Employee() { EmployeeId = id }; 
            Employee result = null;
            try
            {
                result = business.GetEmployeeById(employee);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public ObjectResult Post([FromBody]Employee employee)
        {
            Employee result = null;
            try
            {
                result = business.CreateEmployee(employee);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ObjectResult Put([FromBody] Employee employee, int id)
        {
            bool result = false;
            employee.EmployeeId = id;
            try
            {
                result = business.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            Employee employee = new Employee() { EmployeeId = id};
            bool result = false;
            try
            {
                result = business.DeleteEmployee(employee);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }
    }
}
