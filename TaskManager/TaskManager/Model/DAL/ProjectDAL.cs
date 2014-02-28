using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskManager.Model.DAL
{
    public class ProjectDAL : DALBase
    {
        public void CreateProject(Project project, int personId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("project.usp_createProject", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProjectName", SqlDbType.VarChar, 30).Value = project.ProjectName;
                    cmd.Parameters.Add("@ProjectDescription", SqlDbType.VarChar, 500).Value = project.ProjectDescription;
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void DeleteProject(int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("project.usp_deleteProject", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public int GetNewestProject(int personId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var projects = new List<Project>(100);
                    var cmd = new SqlCommand("project.usp_getNewestProject", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personId;
                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)cmd.Parameters["@ProjectID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public Project GetProjectById(int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("project.usp_getProjectByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var projectIdIndex = reader.GetOrdinal("ProjectID");
                            var projectNameIndex = reader.GetOrdinal("ProjectName");
                            var projectDescriptionIndex = reader.GetOrdinal("ProjectDescription");

                            return new Project
                            {
                                ProjectId = reader.GetInt32(projectIdIndex),
                                ProjectName = reader.GetString(projectNameIndex),
                                ProjectDescription = reader.GetString(projectDescriptionIndex)
                            };
                        }
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public IEnumerable<Project> GetProjects(int personId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var projects = new List<Project>(100);
                    var cmd = new SqlCommand("project.usp_getProjects", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personId;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var projectIdIndex = reader.GetOrdinal("ProjectID");
                        var projectNameIndex = reader.GetOrdinal("ProjectName");
                        var projectDescriptionIndex = reader.GetOrdinal("ProjectDescription");

                        while (reader.Read())
                        {
                            projects.Add(new Project
                            {
                                ProjectId = reader.GetInt32(projectIdIndex),
                                ProjectName = reader.GetString(projectNameIndex),
                                ProjectDescription = reader.GetString(projectDescriptionIndex)
                            });
                        }
                    }
                    projects.TrimExcess();

                    return projects;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void UpdateProject(Project project)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("project.usp_createProject", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = project.ProjectId;
                    cmd.Parameters.Add("@ProjectName", SqlDbType.VarChar, 30).Value = project.ProjectName;
                    cmd.Parameters.Add("@ProjectDescription", SqlDbType.VarChar, 500).Value = project.ProjectDescription;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}