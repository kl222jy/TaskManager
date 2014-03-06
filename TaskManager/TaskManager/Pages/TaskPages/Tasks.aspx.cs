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
        /// <summary>
        /// Presents a message for successful operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLiteral.Text = Page.GetTemp("message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        /// <summary>
        /// Fetches a list of task that noone is currently working on
        /// </summary>
        /// <returns>List of tasks(not in progress)</returns>
        public IEnumerable<Task> TaskListView_GetData()
        {
            return Service.getTasks(ProjectId);
        }

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RemoveTaskLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.deleteTask(int.Parse((string)e.CommandArgument), ProjectId);
                    Page.SetTemp("message", "Task was successfully deleted.");
                    Response.RedirectToRoute("Tasks");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured.");
                }
            }
        }


        /// <summary>
        /// Sets the current user as working on the task, changes status of task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WorkOnTaskLinkButton_Command(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.joinTask(PersonId, ProjectId, int.Parse((string)e.CommandArgument));
                    Page.SetTemp("message", "Task updated, you are now assigned to work on this task.");
                    Response.RedirectToRoute("Tasks");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured while the task was being assigned.");
                }
            }
        }

        /// <summary>
        /// Updates changes med to the task
        /// </summary>
        /// <param name="TaskID"></param>
        public void TaskListView_UpdateItem(int TaskID)
        {
            //Try to find the specified task
            var task = Service.getTaskById(TaskID, ProjectId);

            //Show error and stop if no task was found
            if (task == null)
            {
                ModelState.AddModelError(String.Empty, "Task was not found.");
                return;
            }
            //Otherwise save
            TryUpdateModel(task);
            if (ModelState.IsValid)
            {
                Service.UpdateTask(task);
            }
        }
    }
}