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

        public void deleteTask(int taskId, int projectId)
        {
            TaskDAL.deleteTask(taskId, projectId);
        }

        public void doneTask(int taskId, int projectId)
        {
            TaskDAL.doneTask(taskId, projectId);
        }

        public IEnumerable<Task> getDoneTasks(int projectId)
        {
            return TaskDAL.getDoneTasks(projectId);
        }

        public Task getTaskById(int taskId, int projectId)
        {
            return TaskDAL.getTaskById(taskId, projectId);
        }

        public IEnumerable<Task> getTasks(int projectId)
        {
            return TaskDAL.getTasks(projectId);
        }

        public IEnumerable<Task> getUserTasks(int personId, int projectId)
        {
            return TaskDAL.getUserTasks(personId, projectId);
        }

        public void joinTask(int personId, int projectId, int taskId)
        {
            TaskDAL.joinTask(personId, projectId, taskId);
        }

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

        public IEnumerable<Person> GetAllUsers()
        {
            return PersonDAL.GetAllUsers();
        }

        public void CreateProject(Project project, int personId)
        {
            ProjectDAL.CreateProject(project, personId);
        }

        public void DeleteProject(int projectId)
        {
            ProjectDAL.DeleteProject(projectId);
        }

        public Project GetProjectByID(int projectId)
        {
            return ProjectDAL.GetProjectById(projectId);
        }

        public IEnumerable<Project> GetProjects(int personId)
        {
            return ProjectDAL.GetProjects(personId);
        }

        public int GetNewestProject(int personId)
        {
            return ProjectDAL.GetNewestProject(personId);
        }

        public void UpdateProject(Project project)
        {
            ProjectDAL.UpdateProject(project);
        }
    }
}