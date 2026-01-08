using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Exceptions
{
    internal class ApplicationException:Exception
    {
        public ApplicationException(string message) : base(message) { }
    }
}
