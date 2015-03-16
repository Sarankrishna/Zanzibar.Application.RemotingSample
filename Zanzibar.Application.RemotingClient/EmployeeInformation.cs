using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using Zanzibar.Application.Common.EntityInterface;
using Zanzibar.Application.Common.ServiceInterface;

namespace Zanzibar.Application.RemotingClient
{
    public class EmployeeInformation
    {
        private TcpChannel tcpChannel;
        private IEmployeeService remoteObject;
        public EmployeeInformation()
        {
            tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, true);
            Type requiredType = typeof(IEmployeeService);
            remoteObject = (IEmployeeService)Activator.GetObject(requiredType,
                "tcp://localhost:1237/EmployeeManager");
        }
        public IList<IEmployee> GetEmployees()
        {

            IList<IEmployee> employees = remoteObject.GetEmployees();
            return employees;
            
        }


        public bool UpdateEmployee()
        {

            var ds = remoteObject.LoadEmployees();

            foreach (DataRow row in ds.Tables["Employee"].Rows)
            {
                row["Name"] = "Saran" + DateTime.Now.ToShortDateString();
            }
            remoteObject.UpdateEmployees(ds);
            return true;
        }
    }
}
