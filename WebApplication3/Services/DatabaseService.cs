using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;  
public class DatabaseService
   {
       private readonly string _connectionString;

       public DatabaseService(string connectionString)
       {
           _connectionString = connectionString;
       }

       public List<Dictionary<string, object>> RunStoredProcedure()
       {
           var results = new List<Dictionary<string, object>>();

           using var connection = new SqlConnection(_connectionString);
           using var command = new SqlCommand("GetResponseFluctuations", connection)
           {
               CommandType = CommandType.StoredProcedure
           };

           connection.Open();
           using var reader = command.ExecuteReader();

           while (reader.Read())
           {
               var row = new Dictionary<string, object>();
               for (int i = 0; i < reader.FieldCount; i++)
               {
                   row[reader.GetName(i)] = reader.GetValue(i);
               }
               results.Add(row);
           }

           return results;
       }
   }
   