using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TestCountry
    {
        public static bool GetCountryByID(int ID , ref string CountryName) { 

            bool isFound = false;
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            string Query = "Select * from Countries Where CountryID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string) reader["CountryName"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            
            return isFound;
        }
    }
}
