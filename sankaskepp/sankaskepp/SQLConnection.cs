using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace sankaskepp
{
    public static class SQLConnection
    {
        private static string connectionString = "Data Source = localhost; Initial Catalog = battleships; Integrated Security = SSPI";
        public static SqlConnection myConnection = new SqlConnection(connectionString);

        public static List<SavedGame> GetSavedGames()
        {
       
            List<SavedGame> savedGames = new List<SavedGame>();
            try
            {
                //myConnection.ConnectionString = connectionString;
                myConnection.Open();

                SqlCommand myReadCommand = new SqlCommand();
                myReadCommand.Connection = myConnection;
                myReadCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myReadCommand.CommandText = "GetSavedGames";

                SqlDataReader myReader;
                myReader = myReadCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string id = myReader["ID"].ToString();
                    int idInt = Convert.ToInt32(id);
                    string savedString = myReader["savedString"].ToString();
                    string date = myReader["datesaved"].ToString();

                    savedGames.Add(new SavedGame(idInt, savedString, date));
                    //Console.WriteLine(myReader["FirstName"].ToString());
                    //Console.WriteLine(myReader["LastName"].ToString());
                    //Console.WriteLine("----------------");

                };


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                myConnection.Close();
            }
            return savedGames;
        }

        internal static string GetSaveString(int saveIdInt)
        {
            string stringToReturn="";
            try
            {
                myConnection.Open();

                SqlCommand myReadCommand = new SqlCommand();
                myReadCommand.Connection = myConnection;
                myReadCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myReadCommand.CommandText = "GetSaveById";


                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.DbType = System.Data.DbType.Int32;
                paramId.Value = saveIdInt;
                myReadCommand.Parameters.Add(paramId);

                //SqlParameter paramHTML = new SqlParameter();
                //paramHTML.ParameterName = "@HTML";
                //paramHTML.DbType = System.Data.DbType.String;
                //paramHTML.Direction = System.Data.ParameterDirection.Output;
                //paramHTML.Size = 2000000000;
                //myReadCommand.Parameters.Add(paramHTML);

                
                SqlDataReader myReader = myReadCommand.ExecuteReader();
                 myReader.Read();
                stringToReturn = myReader["HTML"].ToString();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                myConnection.Close();
            }

            return System.Uri.UnescapeDataString(stringToReturn);
        }

        public static void SaveGame(string html)
        {
            DateTime date = DateTime.Now;

            try
            {
                myConnection.Open();

                SqlCommand myAddCommand = new SqlCommand();
                myAddCommand.Connection = myConnection;
                myAddCommand.CommandType = System.Data.CommandType.StoredProcedure;

                myAddCommand.CommandText = "SaveGame";

                SqlParameter paramHtml = new SqlParameter();
                paramHtml.ParameterName = "@savedString";
                paramHtml.DbType = System.Data.DbType.String;
                paramHtml.Value = html;
                myAddCommand.Parameters.Add(paramHtml);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "@DateString";
                paramDate.DbType = System.Data.DbType.String;
                paramDate.Value = date.ToShortTimeString();
                myAddCommand.Parameters.Add(paramDate);

                


                //SqlDataReader myReader = myAddCommand.ExecuteReader();
                //Console.WriteLine($"New ID :  {paramID.Value}");


                myAddCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                myConnection.Close();
            }

        }
    }
}