using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Model;

namespace TaskManager.Pages
{
    public partial class PageHelper : System.Web.UI.Page
    {
        private Service _service;

        protected Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }
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
        }
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
        }
    }
}