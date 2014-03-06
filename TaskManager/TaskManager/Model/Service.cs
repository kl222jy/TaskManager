using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManager.Model.DAL;

namespace TaskManager.Model
{
    public class Service
    {
        private PersonDAL _personDAL;
        private ProjectDAL _projectDAL;
        private TaskDAL _taskDAL;

        private PersonDAL PersonDAL
        {
            get
            {
                try
                {
                    return _personDAL ?? (_personDAL = new PersonDAL());
                }
                catch (Exception)
                {

                    throw new ApplicationException("An unexpected error occured in the service layer.");
                }
            }
        }
        private ProjectDAL ProjectDAL
        {
            get
            {
                try
                {
                    return _projectDAL ?? (_projectDAL = new ProjectDAL());
                }
                catch (Exception)
                {

                    throw new ApplicationException("An unexpected error occured in the service layer.");
                }
            }
        }

        private TaskDAL TaskDAL
        {
            get
            {
                try
                {
                    return _taskDAL ?? (_taskDAL = new TaskDAL());
                }
                catch (Exception)
                {

                    throw new ApplicationException("An unexpected error occured in the service layer.");
                }
            }
        }

        /// <summary>
        /// Delete task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        public void deleteTask(int taskId, int projectId)
        {
            TaskDAL.deleteTask(taskId, projectId);
        }

        /// <summary>
        /// Mark task as done
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        public void doneTask(int taskId, int projectId)
        {
            TaskDAL.doneTask(taskId, projectId);
        }

        /// <summary>
        /// Fetch list of completed tasks
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IEnumerable<Task> getDoneTasks(int projectId)
        {
            return TaskDAL.getDoneTasks(projectId);
        }

        /// <summary>
        /// Fetch task by id
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Task getTaskById(int taskId, int projectId)
        {
            return TaskDAL.getTaskById(taskId, projectId);
        }

        /// <summary>
        /// Fetch list of tasks for project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IEnumerable<Task> getTasks(int projectId)
        {
            return TaskDAL.getTasks(projectId);
        }

        /// <summary>
        /// Fetch list of tasks specified user is working on
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IEnumerable<Task> getUserTasks(int personId, int projectId)
        {
            return TaskDAL.getUserTasks(personId, projectId);
        }

        /// <summary>
        /// Set specified user as working on task, sets status to in progress
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        public void joinTask(int personId, int projectId, int taskId)
        {
            TaskDAL.joinTask(personId, projectId, taskId);
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="task"></param>
        public void newTask(Task task)
        {
            ICollection<ValidationResult> validationResults;

            if (!task.Validate(out validationResults))
            {
                var ex = new ValidationException("");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            else
            {
                TaskDAL.newTask(task);
            }
        }

        /// <summary>
        /// Fetch all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllUsers()
        {
            return PersonDAL.GetAllUsers();
        }

        /// <summary>
        /// Cached list of users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllUsersCached()
        {
            var users = HttpContext.Current.Cache["users"] as IEnumerable<Person>;

            if (users == null)
            {
                users = GetAllUsers();
                HttpContext.Current.Cache.Insert("users", users);
            }

            return users;
        }

        /// <summary>
        /// Create project, set specified user as member of project
        /// </summary>
        /// <param name="project"></param>
        /// <param name="personId"></param>
        public void CreateProject(Project project, int personId)
        {
             ICollection<ValidationResult> validationResults;

             if (!project.Validate(out validationResults))
             {
                 var ex = new ValidationException("");
                 ex.Data.Add("ValidationResults", validationResults);
                 throw ex;
             }
             else
             {
                 ProjectDAL.CreateProject(project, personId);
             }
        }

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId"></param>
        public void DeleteProject(int projectId)
        {
            ProjectDAL.DeleteProject(projectId);
        }

        /// <summary>
        /// Fetch project by id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Project GetProjectByID(int projectId)
        {
            return ProjectDAL.GetProjectById(projectId);
        }

        /// <summary>
        /// Fetch list of projects specified user is a member of
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects(int personId)
        {
            return ProjectDAL.GetProjects(personId);
        }

        /// <summary>
        /// Fetch the most newly created project a specified user is a member of
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public int GetNewestProject(int personId)
        {
            return ProjectDAL.GetNewestProject(personId);
        }

        /// <summary>
        /// Update project
        /// </summary>
        /// <param name="project"></param>
        public void UpdateProject(Project project)
        {
             ICollection<ValidationResult> validationResults;

             if (!project.Validate(out validationResults))
             {
                 var ex = new ValidationException("");
                 ex.Data.Add("ValidationResults", validationResults);
                 throw ex;
             }
             else
             {
                 ProjectDAL.UpdateProject(project);
             }
        }

        /// <summary>
        /// Mark task as not completed
        /// </summary>
        /// <param name="taskId"></param>
        public void notDoneTask(int taskId)
        {
            TaskDAL.notDoneTask(taskId);
        }

        /// <summary>
        /// Set specified user as no longer working on specified task, mark task as not in progress if noone is left working on it
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="personId"></param>
        /// <param name="projectId"></param>
        public void leaveTask(int taskId, int personId, int projectId)
        {
            TaskDAL.leaveTask(taskId, personId, projectId);
        }

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(Task task)
        {
            ICollection<ValidationResult> validationResults;

            if (!task.Validate(out validationResults))
            {
                var ex = new ValidationException("");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            else
            {
                TaskDAL.UpdateTask(task);
            }
        }
    }
}