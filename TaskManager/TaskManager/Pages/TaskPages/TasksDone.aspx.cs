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
            return Service.getDoneTasks(ProjectId);
        }

        protected void MarkNotDoneLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)     //Hyfsat onödigt?
            {
                try
                {
                    Service.notDoneTask(int.Parse((string)e.CommandArgument));
                    Page.SetTemp("message", "Task is now in progress again and will now show up in current tasks for users that worked on it when it was marked as done.");
                    Response.RedirectToRoute("Tasks");
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