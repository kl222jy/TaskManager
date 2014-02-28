using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace TaskManager
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("TasksDone",
                "tasks/done",
                "~/Pages/TaskPages/TasksDone.aspx");

            routes.MapPageRoute("UserTasks",
                "tasks/current",
                "~/Pages/TaskPages/UserTasks.aspx");

            routes.MapPageRoute("CreateTask",
                "task/create",
                "~/Pages/TaskPages/CreateTask.aspx");

            routes.MapPageRoute("Tasks",
                "tasks",
                "~/Pages/TaskPages/Tasks.aspx");

            routes.MapPageRoute("Contact",
                "about",
                "~/About.aspx");

            routes.MapPageRoute("Projects",
                "projects",
                "~/Pages/ProjectPages/ProjectList.aspx");

            routes.MapPageRoute("Default",
                "",
                "~/Pages/PersonPages/PersonList.aspx");
        }
    }
}
