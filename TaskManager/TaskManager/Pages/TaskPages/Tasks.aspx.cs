using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Model;

namespace TaskManager.Pages.TaskPages
{
    public partial class Tasks : BasePage //System.Web.UI.Page
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
        public IEnumerable<Task> TaskListView_GetData()
        {
            return Service.getTasks(ProjectId);
        }

        protected void RemoveTaskLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)     //Hyfsat onödigt?
            {
                try
                {
                    Service.deleteTask(int.Parse((string)e.CommandArgument), ProjectId);
                    Page.SetTemp("message", "Task was successfully deleted.");
                    Response.RedirectToRoute("Tasks");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured.");
                }
            }
        }

        protected void WorkOnTaskLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)     //Hyfsat onödigt?
            {
                try
                {
                    Service.joinTask(PersonId, ProjectId, int.Parse((string)e.CommandArgument));
                    Page.SetTemp("message", "Task updated, you are now assigned to work on this task.");
                    Response.RedirectToRoute("Tasks");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured while the task was being assigned.");
                }
            }
        }
    }
}