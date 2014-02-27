using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Model;

namespace TaskManager.Pages.TaskPages
{
    public partial class CreateTask : PageHelper //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FormView1_InsertItem(Task task)
        {
            task.ProjectID = ProjectId;
            task.TaskStatusID = 1;

            if (ModelState.IsValid)
            {
                try
                {
                    Service.newTask(task);
                    Page.SetTemp("message", "Task was created.");
                    Response.RedirectToRoute("Tasks");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "An unexpected error occured while the task was being created.");
                }
            }
        }
    }
}