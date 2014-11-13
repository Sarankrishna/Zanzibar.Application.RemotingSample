using System;
using System.Collections.Generic;
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
        public IList<IEmployee> GetEmployees()
        {
            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, true);
            Type requiredType = typeof(IEmployeeService);
            IEmployeeService remoteObject = (IEmployeeService)Activator.GetObject(requiredType,
                "tcp://localhost:1237/EmployeeManager");
            IList<IEmployee> employees = remoteObject.GetEmployees();
            return employees;
            
        }
    }
}
