using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
			/*我这测试两种方式都行的*/
            string strConn = "data source=127.0.0.1;initial catalog=DB;Trusted_Connection=False;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework";
            //string strConn = @"data source=127.0.0.1\SQL2008R2,1433;initial catalog=DB;Trusted_Connection=False;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework";

            SqlConnection ConnAcc = new SqlConnection(strConn);

            ConnAcc.Open();

            Console.WriteLine(ConnAcc.State);

            SqlCommand cmd = ConnAcc.CreateCommand();

            cmd.CommandText = "SELECT * FROM ViewProjectForWeb where id = 1";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(reader.GetOrdinal("name"));
                Console.WriteLine(name);
            }

            ConnAcc.Close(); 
        }
    }
}
