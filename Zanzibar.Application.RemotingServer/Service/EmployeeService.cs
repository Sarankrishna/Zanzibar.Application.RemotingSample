using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanzibar.Application.Common.EntityInterface;
using Zanzibar.Application.Common.ServiceInterface;
using Zanzibar.Application.RemotingServer.Entities;

namespace Zanzibar.Application.RemotingServer.Service
{
    public class EmployeeService :MarshalByRefObject, IEmployeeService
    {
        public List<IEmployee> GetEmployees()
        {

            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new Employee { Id = 1, Name = "Saran" });
            employees.Add(new Employee { Id = 2, Name = "Ranga" });

            return employees;
        }
    }
}
