using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;


namespace webdev.Controllers
{
    public class Link : Controller
    {
        
        public ActionResult SendToURL(string address)
        {
                var segment = string.Join(" ", address);
                var baseFormat = "https://{0}/";
                var url = string.Format(baseFormat, segment);
                return Redirect(url);
        }
        

    }
}