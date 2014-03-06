using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Model;

namespace TaskManager.Pages
{
    /// <summary>
    /// Implements behavior that is used by every page that requires data operations
    /// </summary>
    public partial class BasePage : System.Web.UI.Page
    {
        private Service _service;

        //Service class, bridge to datalayer methods
        protected Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }

        //Handles id of currently logged in user
        protected int PersonId
        {
            get
            {
                if (Session["PersonID"] == null)
                {
                    Session["PersonID"] = 4;
                }
                return (int)Session["PersonID"];
            }
            set
            {
                Session["PersonID"] = value;
            }
        }

        //Handles id of the currently active project
        protected int ProjectId
        {
            get
            {
                if (Session["ProjectID"] == null)
                {
                    Session["ProjectID"] = 1;
                }
                return (int)Session["ProjectID"];
            }
            set
            {
                Session["ProjectID"] = value;
            }
        }
    }
}