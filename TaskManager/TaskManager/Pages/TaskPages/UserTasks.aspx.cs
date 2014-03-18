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
        /// <summary>
        /// Presents a message for successful operations
        /// </summary>
        /// <param name="sender">sender info</param>
        /// <param name="e">event info</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLiteral.Text = Page.GetTemp("message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        /// <summary>
        /// Fetches a list of tasks that the user is currently working on.
        /// </summary>
        /// <returns>List of tasks.</returns>
        public IEnumerable<Task> TaskListView_GetData()
        {
            return Service.getUserTasks(PersonId, ProjectId);
        }

        /// <summary>
        /// Removes the user from users working on the task and if this would result in noone working on the task, it will also change the status of the task.
        /// </summary>
        /// <param name="sender">sender info</param>
        /// <param name="e">event info</param>
        protected void StopWorkingOnTaskLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.leaveTask(int.Parse((string)e.CommandArgument), PersonId, ProjectId);
                    Page.SetTemp("message", "You stopped working on the task, in case you were the only one working on it, it should no longer be in progress.");
                    Response.RedirectToRoute("UserTasks");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured.");
                }
            }
        }

        /// <summary>
        /// Changes status of the task to done.
        /// </summary>
        /// <param name="sender">sender info</param>
        /// <param name="e">event info</param>
        protected void MarkAsDoneLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.doneTask(int.Parse((string)e.CommandArgument), ProjectId);
                    Page.SetTemp("message", "Task is now marked as done.");
                    Response.RedirectToRoute("UserTasks");
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