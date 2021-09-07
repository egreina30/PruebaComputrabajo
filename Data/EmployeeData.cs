using CommonInterfaces.Entities;
using CommonInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class EmployeeData : IEmployee
    {
        public List<Employee> GetEmployees()
        {
            SqlConnection con = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString"));
            List<Employee> employees = new List<Employee>();
            try
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand("sp_GetEmployees", con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Employee axuEmployee = new Employee()
                            {
                                EmployeeId = (int)reader[0],
                                CompanyId = (int)reader[1],
                                CreatedOn = (DateTime)reader[2],
                                DeletedOn = reader[3].Equals(DBNull.Value) ? null : (DateTime?)reader[3],
                                Email = (string)reader[4],
                                Fax = reader[5].Equals(DBNull.Value) ? null : (string)reader[5],
                                Name = (string)reader[6],
                                Lastlogin = reader[7].Equals(DBNull.Value) ? null : (DateTime?)reader[7],
                                Password = (string)reader[8],
                                PortalId = (int)reader[9],
                                RoleId = (int)reader[10],
                                StatusId = (int)reader[11],
                                Telephone = reader[12].Equals(DBNull.Value) ? null : (string)reader[12],
                                UpdatedOn = reader[13].Equals(DBNull.Value) ? null : (DateTime?)reader[13],
                                Username = (string)reader[14]
                            };
                            employees.Add(axuEmployee);
                        }
                    }
                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return employees;
        }

        public Employee GetEmployeeById(Employee employee)
        {
            Employee result = null;
            try
            {
                SqlConnection con = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString"));
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = new Employee()
                        {
                            EmployeeId = (int)reader[0],
                            CompanyId = (int)reader[1],
                            CreatedOn = (DateTime)reader[2],
                            DeletedOn = reader[3].Equals(DBNull.Value) ? null : (DateTime?)reader[3],
                            Email = (string)reader[4],
                            Fax = reader[5].Equals(DBNull.Value) ? null : (string)reader[5],
                            Name = (string)reader[6],
                            Lastlogin = reader[7].Equals(DBNull.Value) ? null : (DateTime?)reader[7],
                            Password = (string)reader[8],
                            PortalId = (int)reader[9],
                            RoleId = (int)reader[10],
                            StatusId = (int)reader[11],
                            Telephone = reader[12].Equals(DBNull.Value) ? null : (string)reader[12],
                            UpdatedOn = reader[13].Equals(DBNull.Value) ? null : (DateTime?)reader[13],
                            Username = (string)reader[14]
                        };
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Employee CreateEmployee(Employee employee)
        {
            Employee result = null;
            try
            {
                SqlConnection con = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString"));
                SqlCommand cmd = new SqlCommand("sp_CreateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                if (employee.Fax == null)
                    cmd.Parameters.AddWithValue("@Fax", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Fax", employee.Fax);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@PortalId", employee.PortalId);
                cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
                if(employee.Telephone == null)
                    cmd.Parameters.AddWithValue("@Telephone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Telephone", employee.Telephone);
                cmd.Parameters.AddWithValue("@Username", employee.Username);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = new Employee()
                        {
                            EmployeeId = (int)reader[0],
                            CompanyId = (int)reader[1],
                            CreatedOn = (DateTime)reader[2],
                            DeletedOn = reader[3].Equals(DBNull.Value) ? null : (DateTime?)reader[3],
                            Email = (string)reader[4],
                            Fax = reader[5].Equals(DBNull.Value) ? null : (string)reader[5],
                            Name = (string)reader[6],
                            Lastlogin = reader[7].Equals(DBNull.Value) ? null : (DateTime?)reader[7],
                            Password = (string)reader[8],
                            PortalId = (int)reader[9],
                            RoleId = (int)reader[10],
                            StatusId = (int)reader[11],
                            Telephone = reader[12].Equals(DBNull.Value) ? null : (string)reader[12],
                            UpdatedOn = reader[13].Equals(DBNull.Value) ? null : (DateTime?)reader[13],
                            Username = (string)reader[14]
                        };
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                SqlConnection con = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString"));
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                if (employee.Fax == null)
                    cmd.Parameters.AddWithValue("@Fax", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Fax", employee.Fax);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                if (employee.Lastlogin == null)
                    cmd.Parameters.AddWithValue("@Lastlogin", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Lastlogin", employee.Lastlogin);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@PortalId", employee.PortalId);
                cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
                cmd.Parameters.AddWithValue("@StatusId", employee.StatusId);
                if (employee.Telephone == null)
                    cmd.Parameters.AddWithValue("@Telephone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Telephone", employee.Telephone);
                cmd.Parameters.AddWithValue("@Username", employee.Username);
                con.Open();
                int responseBd = cmd.ExecuteNonQuery();
                con.Close();
                if (responseBd == 1)
                    result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool DeleteEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                SqlConnection con = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString"));
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                con.Open();
                int responseBd = cmd.ExecuteNonQuery();
                con.Close();
                if (responseBd == 1)
                    result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
