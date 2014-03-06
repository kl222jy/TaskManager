using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskManager.Model.DAL
{
    public class PersonDAL : DALBase
    {
        /// <summary>
        /// Fetch all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllUsers()
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var users = new List<Person>(100);
                    var cmd = new SqlCommand("person.usp_getAllUsers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var personIdIndex = reader.GetOrdinal("PersonID");
                        var fNameIndex = reader.GetOrdinal("FName");
                        var lNameIndex = reader.GetOrdinal("Lname");
                        var emailIndex = reader.GetOrdinal("Email");

                        while (reader.Read())
                        {
                            users.Add(new Person
                            {
                                PersonId = reader.GetInt32(personIdIndex),
                                FName = reader.GetString(fNameIndex),
                                LName = reader.GetString(lNameIndex),
                                Email = reader.GetString(emailIndex)
                            });
                        }
                    }
                    users.TrimExcess();

                    return users;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}