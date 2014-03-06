using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskManager.Model.DAL
{
    public class TaskDAL : DALBase
    {
        /// <summary>
        /// Delete task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        public void deleteTask(int taskId, int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_deleteTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = taskId;
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

        /// <summary>
        /// Mark task as done
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        public void doneTask(int taskId, int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_doneTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = taskId;
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

        /// <summary>
        /// Fetch list of tasks that are completed
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>list of completed tasks</returns>
        public IEnumerable<Task> getDoneTasks(int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var tasks = new List<Task>(100);
                    var cmd = new SqlCommand("task.usp_getDoneTasks", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var taskIdIndex = reader.GetOrdinal("TaskID");
                        var taskDescriptionIndex = reader.GetOrdinal("TaskDescription");
                        var projectIdIndex = reader.GetOrdinal("ProjectID");
                        var taskStatusIdIndex = reader.GetOrdinal("TaskStatusID");

                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                TaskID = reader.GetInt32(taskIdIndex),
                                TaskDescription = reader.GetString(taskDescriptionIndex),
                                ProjectID = reader.GetInt32(projectIdIndex),
                                TaskStatusID = reader.GetInt32(taskStatusIdIndex)
                            });
                        }
                    }
                    tasks.TrimExcess();

                    return tasks;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Fetch task by id
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Task getTaskById(int taskId, int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_getTaskById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = taskId;
                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var taskIdIndex = reader.GetOrdinal("TaskID");
                            var taskDescriptionIndex = reader.GetOrdinal("TaskDescription");
                            var projectIdIndex = reader.GetOrdinal("ProjectID");
                            var taskStatusIdIndex = reader.GetOrdinal("TaskStatusID");

                            return new Task
                            {
                                TaskID = reader.GetInt32(taskIdIndex),
                                TaskDescription = reader.GetString(taskDescriptionIndex),
                                ProjectID = reader.GetInt32(projectIdIndex),
                                TaskStatusID = reader.GetInt32(taskStatusIdIndex)
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

        /// <summary>
        /// Fetch tasks of active project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IEnumerable<Task> getTasks(int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var tasks = new List<Task>(100);
                    var cmd = new SqlCommand("task.usp_getTasks", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var taskIdIndex = reader.GetOrdinal("TaskID");
                        var taskDescriptionIndex = reader.GetOrdinal("TaskDescription");
                        var projectIdIndex = reader.GetOrdinal("ProjectID");
                        var taskStatusIdIndex = reader.GetOrdinal("TaskStatusID");

                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                TaskID = reader.GetInt32(taskIdIndex),
                                TaskDescription = reader.GetString(taskDescriptionIndex),
                                ProjectID = reader.GetInt32(projectIdIndex),
                                TaskStatusID = reader.GetInt32(taskStatusIdIndex)
                            });
                        }
                    }
                    tasks.TrimExcess();

                    return tasks;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Fetch tasks of current user
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IEnumerable<Task> getUserTasks(int personId, int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var tasks = new List<Task>(100);
                    var cmd = new SqlCommand("task.usp_getUserTasks", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personId;
                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var taskIdIndex = reader.GetOrdinal("TaskID");
                        var taskDescriptionIndex = reader.GetOrdinal("TaskDescription");
                        var projectIdIndex = reader.GetOrdinal("ProjectID");
                        var taskStatusIdIndex = reader.GetOrdinal("TaskStatusID");

                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                TaskID = reader.GetInt32(taskIdIndex),
                                TaskDescription = reader.GetString(taskDescriptionIndex),
                                ProjectID = reader.GetInt32(projectIdIndex),
                                TaskStatusID = reader.GetInt32(taskStatusIdIndex)
                            });
                        }
                    }
                    tasks.TrimExcess();

                    return tasks;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Set user as working on task with taskId
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        public void joinTask(int personId, int projectId, int taskId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_joinTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personId;
                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = projectId;
                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = taskId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="task"></param>
        public void newTask(Task task)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_newTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskDescription", SqlDbType.VarChar, 500).Value = task.TaskDescription;
                    cmd.Parameters.Add("@ProjectID", SqlDbType.Int, 4).Value = task.ProjectID;
                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    task.TaskID = (int)cmd.Parameters["@TaskID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Mark task as not done
        /// </summary>
        /// <param name="taskId"></param>
        public void notDoneTask(int taskId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_notDoneTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = taskId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Set user as not working on specific task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="personId"></param>
        /// <param name="projectId"></param>
        public void leaveTask(int taskId, int personId, int projectId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_leaveTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = taskId;
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personId;
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

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(Task task)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("task.usp_updateTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskID", SqlDbType.Int, 4).Value = task.TaskID;
                    cmd.Parameters.Add("@TaskDescription", SqlDbType.VarChar, 500).Value = task.TaskDescription;

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