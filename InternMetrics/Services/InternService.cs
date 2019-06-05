using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using InternMetrics.Models;


namespace InternMetrics.Services
{
    
    public class InternService
    {
        static string connectionString = "";
        public InternService(){}

        public IEnumerable<Intern> GetInterns()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var interns = new List<Intern>();
                string queryString = "SELECT ID,Name,Email,HomeStateEnum,DesiredSkill FROM Intern";
                SqlCommand cmd = new SqlCommand(queryString,connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        interns.Add(new Intern{
                            ID = (int)reader["ID"],
                            Name =(string)reader["Name"],
                            Email =(string)reader["Email"],
                            HomeStateEnum = (int)reader["HomeStateEnum"],
                            DesiredSkill = (string)reader["DesiredSkill"]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    reader.Close();
                }
                return interns;
            }
            
        }

        public void CreateIntern(string Name, string Email, string HomeState, string DesiredSkill)
        {
            string queryString = $@"INSERT INTO Intern (Name, Email, YearsExp, HomeStateEnum, DesiredSkill)
                VALUES('{Name}','{Email}', {0}, {10}, '{DesiredSkill}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}