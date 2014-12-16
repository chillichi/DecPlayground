using DecPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DecPlayground.Filters
{
    public class ContentHeaderActionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {

            switch (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName) { 
                case "Vote":
                    filterContext.Controller.ViewBag.backgroundPic = "~/Content/img/contact-bg.jpg";
                    filterContext.Controller.ViewBag.header = "MVC Form Voting";
                    filterContext.Controller.ViewBag.subHeader = "this page is a simple MVC page, doing dependency injection, Entity framework, Google Chart(Ajax)";
                    break;
                case "Home":
                default:
                    if (filterContext.ActionDescriptor.ActionName == "Angular")
                    {
                        filterContext.Controller.ViewBag.backgroundPic = "~/Content/img/about-bg.jpg";
                        filterContext.Controller.ViewBag.header = "Angular To Do List";
                        filterContext.Controller.ViewBag.subHeader = "this page is using 'angularJS' ";
                    }
                    else
                    {
                        filterContext.Controller.ViewBag.backgroundPic = "~/Content/img/home-bg.jpg";
                        filterContext.Controller.ViewBag.header = "Chi's playground";
                        filterContext.Controller.ViewBag.subHeader = "Index Page";
                    }
                    break;
            }



            this.OnActionExecuting(filterContext);
        }

    }
}