using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Model;

namespace TaskManager.Pages.TaskPages
{
    public partial class UserTasks : BasePage //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Task> TaskListView_GetData()
        {
            return Service.getUserTasks(PersonId, ProjectId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void TaskListView_UpdateItem(int TaskId)
        {

        }

        protected void StopWorkingOnTaskLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)     //Hyfsat onödigt?
            {
                try
                {
                    Service.leaveTask(int.Parse((string)e.CommandArgument), PersonId, ProjectId);
                    Page.SetTemp("message", "You stopped working on the task, in case you were the only one working on it, it should no longer be in progress.");
                    Response.RedirectToRoute("Tasks");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured.");
                }
            }
        }

        protected void MarkAsDoneLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)     //Hyfsat onödigt?
            {
                try
                {
                    Service.doneTask(int.Parse((string)e.CommandArgument), ProjectId);
                    Page.SetTemp("message", "Task is now marked as done.");
                    Response.RedirectToRoute("Tasks");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured while the task was being marked as done.");
                }
            }
        }
    }
}