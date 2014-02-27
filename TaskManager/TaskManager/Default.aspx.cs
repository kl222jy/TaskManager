using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Flyttad till site.master page load.. lägga något arv mellan page och själva sidorna kanske? typ _default:authpage:page
            //Det här är iaf en smidig lösning tillsvidare.
            //Session["PersonID"] = 4;
        }
    }
}