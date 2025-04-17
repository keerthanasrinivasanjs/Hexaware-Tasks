using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class SqlException:Exception
    {
        public SqlException(string message, SqlException e) : base(message)
        {
        }
    }
}
