﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TaskManager
{
    public static class PageExtension
    {
        /// <summary>
        /// Fetch tempvalue and delete it
        /// </summary>
        /// <param name="page">page to extend</param>
        /// <param name="key">key to fetch</param>
        /// <returns>value of key</returns>
        public static object GetTemp(this Page page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);
            return value;
        }

        /// <summary>
        /// Fetch tempvalue without removing it
        /// </summary>
        /// <param name="page">page to extend</param>
        /// <param name="key">key to take a look at</param>
        /// <returns>value of key</returns>
        public static object PeekTemp(this Page page, string key)
        {
            return page.Session[key];
        }

        /// <summary>
        /// Set temporary value
        /// </summary>
        /// <param name="page">page to extend</param>
        /// <param name="key">key to set</param>
        /// <param name="value">value of key</param>
        public static void SetTemp(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}