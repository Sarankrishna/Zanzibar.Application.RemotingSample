using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanzibar.Application.Common.EntityInterface;

namespace Zanzibar.Application.Common.ServiceInterface
{
    public interface IEmployeeService
    {
        List<IEmployee> GetEmployees();

        DataSet LoadEmployees();
        bool UpdateEmployees(DataSet ds);
    }
}
