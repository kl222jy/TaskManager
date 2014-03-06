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
        /// <summary>
        /// Handles presentation of success messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLiteral.Text = Page.GetTemp("message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        /// <summary>
        /// Fetches list of persons
        /// </summary>
        /// <returns>List of persons</returns>
        public IEnumerable<Person> PersonListView_GetData()
        {
            try
            {
                return Service.GetAllUsersCached();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occured while fetching data.");
                return null;
            }
        }

        /// <summary>
        /// Mark user as active, saves personid in session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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