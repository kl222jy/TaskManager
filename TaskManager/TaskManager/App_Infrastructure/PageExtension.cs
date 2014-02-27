using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TaskManager
{
    public static class PageExtension
    {
        public static object GetTemp(this Page page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);
            return value;
        }

        public static object PeekTemp(this Page page, string key)
        {
            return page.Session[key];
        }

        public static void SetTemp(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}