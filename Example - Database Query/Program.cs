using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;        // Needed for this example

namespace Example___Database_Query
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to Database/Server
            string connString = @"Server=SERVERNAME;Database=DATABASENAME;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // Open the connection
                    conn.Open();

                    // Query Database using established connection
                    string myQuery = "SELECT [Name],[Balance],[Description] FROM[DATABASENAME].[dbo].[TABLENAME]";
                    SqlCommand myCmd = new SqlCommand(myQuery, conn);

                    // Display Top 10 results - You could also loop through the entire result set here
                    // Execute query using a DataReader.  You can use a DataTable if you need to run through the results multiple times or sort the data returned.
                    SqlDataReader myData = myCmd.ExecuteReader();

                    // Check that records were returned
                    if (myData.HasRows)
                    {
                        // Display Top 10 results - You could also loop through the entire result set here
                        //while (myData.Read()) - Full Loop
                        for(int i = 1; i <= 10; i++)
                        {
                            //display retrieved record (first column only/string value)
                            //Console.WriteLine(myData.GetString(0));
                            try
                            {
                                // Read a record of the returned data
                                myData.Read();

                                // Displary record
                                Console.WriteLine("Name: {0} - Description: {1}", (string)myData["Name"], (string)myData["Description"]);

                            }
                            catch(Exception ex)
                            {
                                // Display any exeptions
                                Console.WriteLine("An exception was thrown when trying to read the returned data: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    myData.Close();
                }// end using - leaving this code block closes the SqlConnection object for us
            }
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
