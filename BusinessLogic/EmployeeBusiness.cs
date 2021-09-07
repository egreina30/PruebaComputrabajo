using CommonInterfaces.Entities;
using CommonInterfaces.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class EmployeeBusiness : IEmployee
    {
        EmployeeData data = new EmployeeData();
        public List<Employee> GetEmployees()
        {
            return data.GetEmployees();
        }

        public Employee GetEmployeeById(Employee employee)
        {
            if (employee == null)
                throw new Exception("Datos de empleado invalidos");
            if (employee.EmployeeId.Equals(0))
                throw new Exception("Id de empleado invalido");

            return data.GetEmployeeById(employee); ;
        }

        public Employee CreateEmployee(Employee employee)
        {
            if (employee == null)
                throw new Exception("Datos de empleado invalidos");
            if (employee.CompanyId.Equals(0))
                throw new Exception("Id de compañia invalido");
            if (employee.Email == null || employee.Email.Equals(string.Empty))
                throw new Exception("Email invalido");
            if (employee.Name == null || employee.Name.Equals(string.Empty))
                throw new Exception("Nombre invalido");
            if (employee.Password == null || employee.Password.Equals(string.Empty))
                throw new Exception("Password invalido");
            if (employee.PortalId.Equals(0))
                throw new Exception("Id de portal invalido");
            if (employee.RoleId.Equals(0))
                throw new Exception("Id de rol invalido");
            if (employee.Username == null || employee.Username.Equals(string.Empty))
                throw new Exception("Username invalido");

            return data.CreateEmployee(employee); ;
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new Exception("Datos de empleado invalidos");
            if (employee.EmployeeId.Equals(0))
                throw new Exception("Id de empleado invalido");
            if (employee.CompanyId.Equals(0))
                throw new Exception("Id de compañia invalido");
            if (employee.Email == null || employee.Email.Equals(string.Empty))
                throw new Exception("Email invalido");
            if (employee.Name == null || employee.Name.Equals(string.Empty))
                throw new Exception("Nombre invalido");
            if (employee.Password == null || employee.Password.Equals(string.Empty))
                throw new Exception("Password invalido");
            if (employee.PortalId.Equals(0))
                throw new Exception("Id de portal invalido");
            if (employee.RoleId.Equals(0))
                throw new Exception("Id de rol invalido");
            if (employee.StatusId.Equals(0))
                throw new Exception("Estado invalido");
            if (employee.Username == null || employee.Username.Equals(string.Empty))
                throw new Exception("Username invalido");
            if (GetEmployeeById(employee) == null)
                throw new Exception("Empleado no existente");

            return data.UpdateEmployee(employee); ;
        }

        public bool DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new Exception("Datos de empleado invalidos");
            if (employee.EmployeeId.Equals(0))
                throw new Exception("Id de empleado invalido");
            if (GetEmployeeById(employee) == null)
                throw new Exception("Empleado no existente");

            return data.DeleteEmployee(employee); ;
        }
    }
}
