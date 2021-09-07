using CommonInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonInterfaces.Interfaces
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(Employee employee);

        Employee CreateEmployee(Employee employee);

        bool UpdateEmployee(Employee employee);

        bool DeleteEmployee(Employee employee);
    }
}
