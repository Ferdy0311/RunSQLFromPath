
using System;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace RunSQLQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connString = ConfigurationManager.ConnectionStrings["KALBE_CONN_STRING"].ToString();
            string path = Console.ReadLine();
            string[] sqlFiles = Directory.GetFiles(@path, "*.sql");
            Console.WriteLine(sqlFiles.ToString());

            foreach(string i in sqlFiles)
            {
                string script = File.ReadAllText(@i);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = script;
                        cmd.ExecuteNonQuery();
                    }
                }
                
            }

            Console.ReadLine();
        }
    }
}
