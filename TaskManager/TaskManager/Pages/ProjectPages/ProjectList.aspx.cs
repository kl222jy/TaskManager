using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Model;

namespace TaskManager.Pages.ProjectPages
{
    public partial class ProjectList : BasePage
    {
        /// <summary>
        /// Presents message from successful operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLiteral.Text = Page.GetTemp("message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        /// <summary>
        /// Fetches a list of projects that the current user is a member of
        /// </summary>
        /// <returns>list of projects</returns>
        public IEnumerable<Project> ProjectListView_GetData()
        {
            try
            {
                return Service.GetProjects(PersonId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occured while fetching data.");
                return null;
            }
        }

        /// <summary>
        /// Updates project
        /// </summary>
        /// <param name="ProjectId">Id of project to update</param>
        public void ProjectListView_UpdateItem(int ProjectId)
        {
            //Try to fetch the project
            var project = Service.GetProjectByID(ProjectId);

            //Show error and stop if no project was found
            if (project == null)
            {
                ModelState.AddModelError(string.Empty, "Project was not found.");
                return;
            }

            //Validate
            TryUpdateModel(project);
            if (ModelState.IsValid)
            {
                //Try to update
                try
                {
                    Service.UpdateProject(project);
                    Page.SetTemp("message", "Project was updated.");
                    Response.RedirectToRoute("Projects");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    //Show error
                    ModelState.AddModelError(string.Empty, "An unexpected error occured while updating the project.");
                }

            }
        }

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="project">Project object</param>
        public void ProjectListView_InsertItem(Project project)
        {
            //Validate
            TryUpdateModel(project);
            if (ModelState.IsValid)
            {
                //Try to create
                try
                {
                    Service.CreateProject(project, PersonId);
                    Page.SetTemp("message", "Project was created.");
                    Response.RedirectToRoute("Projects");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An unexpected error occured while creating the project.");
                }

            }
        }

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="ProjectId">Id of project to delete</param>
        public void ProjectListView_DeleteItem(int ProjectId)
        {
            try
            {
                Service.DeleteProject(ProjectId);
                Page.SetTemp("message", "Project was deleted.");
                Response.RedirectToRoute("Projects");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occured while deleting the project.");
            }
        }

        /// <summary>
        /// Choose active project, sets projectid as a session variable for later use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chooseProject_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ProjectId = int.Parse((string)e.CommandArgument);
                Page.SetTemp("message", "Project activated.");
                Response.RedirectToRoute("Tasks");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Failed to activate project.");
            }
        }
    }
}