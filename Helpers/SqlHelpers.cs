using System;
using Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Helpers
{
    public static class SqlHelpers
    {
        // -----------------------------------------------------
        // Edit the values below to connect to your local MySQL server.
        // -----------------------------------------------------
        private static string Server = "SERVER PORT HERE";
        private static string UID = "USER ID HERE";
        private static string Password = "PASSWORD HERE";
        private static string Database = "DATABASE NAME HERE";
        private static MySqlConnection? SqlConnection;


        // -----------------------------------------------------
        // -----------------------------------------------------
        static SqlHelpers()
        {
            string myConnectionString = 
		        "server=" + Server +
		        ";uid=" + UID +
		        ";pwd=" + Password +
		        ";database=" + Database;

            try
            {
                SqlConnection = new MySqlConnection(myConnectionString);
                SqlConnection.Open();

                Console.WriteLine("Sql connection successful.");
            }
            catch (MySqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


        // -----------------------------------------------------
        // -----------------------------------------------------
        public static List<Habit> GetAllHabits()
        {
            MySqlCommand command = new MySqlCommand("SELECT * from habits;", SqlConnection);
            MySqlDataReader dataReader = command.ExecuteReader();

            List<Habit> output = new List<Habit>();
            while (dataReader.Read())
            {
                Habit currHabitData = new Habit();
                currHabitData.Id = dataReader["id"].ToString();
                currHabitData.Name = dataReader["name"].ToString();
                currHabitData.Comments = dataReader["comments"].ToString();
                currHabitData.Start = Int32.Parse(dataReader["start"].ToString());

                output.Add(currHabitData);
            }

            dataReader.Close();

            return output;
        }


        // -----------------------------------------------------
        // -----------------------------------------------------
        public static Habit GetHabitByHashedID(string inHashedID)
        {
            try {
                string commandString = "SELECT * FROM habits WHERE id = " + "'" + inHashedID + "'";
		        MySqlCommand sqlCommand = new MySqlCommand(commandString, SqlConnection);
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                Habit outputHabit = new Habit();
                while (sqlDataReader.Read())
                {
                    outputHabit.Id = sqlDataReader["id"].ToString();
                    outputHabit.Name = sqlDataReader["name"].ToString();
                    outputHabit.Comments = sqlDataReader["comments"].ToString();
                    outputHabit.Start = Int32.Parse(sqlDataReader["start"].ToString());
                }

                sqlDataReader.Close();

                return outputHabit;
            }
            catch
            {
                Console.WriteLine("Failed to find inHashID.");
                return null;
	        }
        }


        // -----------------------------------------------------
        // -----------------------------------------------------
        public static bool CreateNewHabit(Habit inHabit)
        {
            if (inHabit.IsEmpty())
            {
                Console.WriteLine("inHabit in CreateNewHabit was null.");
                return false;
            }

            try
            {
                string commandString = "INSERT INTO habits VALUES(" + "\"" + 
                    inHabit.Id + "\", \"" + 
                    inHabit.Name + "\", \"" + 
                    inHabit.Comments + "\"," + inHabit.Start + ");";
		        MySqlCommand sqlCommand = new MySqlCommand(commandString, SqlConnection);
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Close();

                return true;
            }
            catch
            {
                Console.WriteLine("Failed to create new habit entry.");
                return false;
	        }
        }


        // -----------------------------------------------------
        // -----------------------------------------------------
        public static bool DeleteHabit(string inID)
        {
            try
            {
                string commandString = "DELETE FROM habits WHERE id = '" + inID + "'";
		        MySqlCommand sqlCommand = new MySqlCommand(commandString, SqlConnection);
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Close();

                return true;
            }
            catch
            {
                Console.WriteLine("Failed to create new habit entry.");
                return false;
	        }
        }
    }
}