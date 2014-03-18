using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Model;

namespace TaskManager.Pages.TaskPages
{
    //public partial class TasksDone : System.Web.UI.Page
    public partial class TasksDone : BasePage
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
        /// Fetches a list of tasks that are marked as done.
        /// </summary>
        /// <returns>List of tasks(done)</returns>
        public IEnumerable<Task> TaskListView_GetData()
        {
            return Service.getDoneTasks(ProjectId);
        }

        /// <summary>
        /// Puts task back in progress, will show up under current task for users that were working on it when it was marked as done.
        /// </summary>
        /// <param name="sender">sender info</param>
        /// <param name="e">event info</param>
        protected void MarkNotDoneLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)     //Hyfsat onödigt?
            {
                try
                {
                    Service.notDoneTask(int.Parse((string)e.CommandArgument));
                    Page.SetTemp("message", "Task is now in progress again and will now show up in current tasks for users that worked on it when it was marked as done.");
                    Response.RedirectToRoute("TasksDone");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured.");
                }
            }
        }
    }
}