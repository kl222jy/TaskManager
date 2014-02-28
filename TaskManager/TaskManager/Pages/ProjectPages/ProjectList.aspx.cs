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
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLiteral.Text = Page.GetTemp("message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void ProjectListView_UpdateItem(int ProjectId)
        {
            var project = Service.GetProjectByID(ProjectId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (project == null)
            {
                // The item wasn't found
                ModelState.AddModelError(string.Empty, "Project was not found.");
                return;
            }
            TryUpdateModel(project);
            if (ModelState.IsValid)
            {
                try
                {
                    Service.UpdateProject(project);
                    Page.SetTemp("message", "Project was created.");
                    Response.RedirectToRoute("Projects");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An unexpected error occured while updating the project.");
                }

            }
        }

        public void ProjectListView_InsertItem(Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.CreateProject(project, PersonId);
                    Page.SetTemp("message", "Project was created.");
                    Response.RedirectToRoute("Projects");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An unexpected error occured while creating the project.");
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ProjectListView_DeleteItem(int ProjectId)
        {
            try
            {
                Service.DeleteProject(ProjectId);
                Page.SetTemp("message", "Project was created.");
                Response.RedirectToRoute("Projects");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occured while deleting the project.");
            }
        }
    }
}