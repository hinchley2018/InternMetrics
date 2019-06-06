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
                string queryString = "SELECT ID,Name,Email,HomeState,DesiredSkill FROM Intern";
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
                            HomeState = (string)reader["HomeState"],
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

        public Intern GetIntern(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Intern intern;
                string queryString = $"SELECT ID,Name,Email,HomeState,DesiredSkill FROM Intern WHERE ID = {id}";
                SqlCommand cmd = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    reader.Read();
                    intern = (new Intern
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Email = (string)reader["Email"],
                        HomeState = (string)reader["HomeState"],
                        DesiredSkill = (string)reader["DesiredSkill"]
                    });
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
                return intern;
            }
        }

        public void CreateIntern(string Name, string Email, string HomeState, string DesiredSkill)
        {
            string queryString = $@"INSERT INTO Intern (Name, Email, YearsExp, HomeState, DesiredSkill)
                VALUES('{Name}','{Email}', {0}, {10}, '{DesiredSkill}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void EditIntern(int id, string Name, string Email, string HomeState, string DesiredSkill)
        {
            string queryString = $"UPDATE Intern SET Name='{Name}', Email='{Email}', YearsExp='{HomeState}', DesiredSkill='{DesiredSkill}' WHERE ID = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}