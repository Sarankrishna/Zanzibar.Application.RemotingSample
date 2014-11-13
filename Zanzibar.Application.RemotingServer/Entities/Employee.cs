using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanzibar.Application.Common.EntityInterface;

namespace Zanzibar.Application.RemotingServer.Entities
{
    [Serializable]
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
