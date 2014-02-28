using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Model;

namespace TaskManager.Pages.PersonPages
{
    public partial class PersonList : BasePage
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
        public IEnumerable<Person> PersonListView_GetData()
        {
            try
            {
                return Service.GetAllUsers();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occured while fetching data.");
                return null;
            }
        }

        protected void chooseUser_Command(object sender, CommandEventArgs e)
        {
            try
            {
                PersonId = int.Parse((string)e.CommandArgument);
                ProjectId = Service.GetNewestProject(PersonId);
                Page.SetTemp("message", "You are now logged in.");
                Response.RedirectToRoute("Projects");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Login failed.");
            }
        }
    }
}