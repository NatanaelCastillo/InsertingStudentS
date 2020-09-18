using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertingStudentS
{
    class ConnectSQLite
    {
        public static string GetConnect()
        {
            return "Data Source=student.db;Version=3;New=False;Compress=True;";
        }
    }
}
