using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TaskManager.Model.DAL
{
    public abstract class DALBase
    {
        /// <summary>
        /// Saves the connectionstring
        /// </summary>
        private static string _connectionString;

        /// <summary>
        /// Creates an sql connection
        /// </summary>
        /// <returns>SqlConnection object</returns>
        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Fetches the connectionstring from webconfig and saves it
        /// </summary>
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["TaskManagerConnectionString"].ConnectionString;
        }
    }
}