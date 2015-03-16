using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=CTS;Integrated Security=True";

        public List<IEmployee> GetEmployees()
        {

            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new Employee { Id = 1, Name = "Saran" });
            employees.Add(new Employee { Id = 2, Name = "Ranga" });

            return employees;
        }


        public DataSet LoadEmployees()
        {
            DataSet ds = new DataSet();

            var da = new SqlDataAdapter("SELECT * FROM Employee",
                connectionString);


            DataTable orderTable = new DataTable("Employee");
            da.FillSchema(orderTable, SchemaType.Source);
            da.Fill(orderTable);
            ds.Tables.Add(orderTable);
            
            return ds;

        }

        public bool UpdateEmployees(DataSet ds)
        {
            var da = new SqlDataAdapter("SELECT * FROM Employee",
             connectionString);
            SqlCommandBuilder cbOrders = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Employee"].Select(null, null, DataViewRowState.ModifiedCurrent));
            return true;
        }
    }
}
