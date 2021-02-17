using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;        // Needed for this example

namespace Example___Database_Stored_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to Database/Server
            string connString = @"Server=SERVERNAME;Database=DATABASENAME;Trusted_Connection=True;";

            // Try to create an instance of an SQL Connection
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // Open the connection
                    conn.Open();

                    // Call a SQL Stored Procedure (uspStoredProcedureName here) and capture the single returned value
                    string spName = @"dbo.[uspStoredProcedureName]";
                    SqlCommand myCmd = new SqlCommand(spName, conn);
                    myCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@CustID";
                    param1.SqlDbType = System.Data.SqlDbType.Int;
                    param1.Value = 123456;
                    myCmd.Parameters.Add(param1);
                    var returnParam = myCmd.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Money);
                    returnParam.Direction = System.Data.ParameterDirection.ReturnValue;
                    myCmd.ExecuteNonQuery();
                    var currBalance = returnParam.Value;
                    Console.WriteLine("CURRENT BALANCE: ${0}", currBalance);

                }// END using SQLConnection - leaving this code block closes the SqlConnection object for us
            }// END - try create connection
            catch (Exception ex)
            {
                // Display any exeptions
                Console.WriteLine("An exception was thrown when trying to connect to the database server: " + ex.Message);
            }

            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
