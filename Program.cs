using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.Exceptions;

using CarConnectApp.Entity;
using CarConnectApp.Util;

namespace CaseStudy_CarConnect
{
    class Program
    {
        public static void Main(String[] args)
        {
            dbUtil db = new dbUtil();
            _ = dbUtil.GetDBConn();

            new ApplicationMenu().Start();
        }
    }
}