using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EcommerceNEIN.Tools
{
    public class Connection
    {
        static string connectionString = @"Data Source=(LocalDB)\EcommerceDB;Integrated Security=True";
        
        public static SqlConnection New { get => new SqlConnection(connectionString); }

    }
}
