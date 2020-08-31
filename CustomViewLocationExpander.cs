using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CustomViews
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            
            if(context.Values["Device"] == null)
            {
                return viewLocations;
            }

            if(context.Values["Device"] == "Mobile")
            {
                viewLocations = new[] {
                    $"/Views/{{1}}/{{0}}.mobile.cshtml",
                    $"/Views/Shared/{{0}}.mobile.cshtml",
                    $"/Views/Shared/Components/{{0}}.mobile.cshtml"
                }
                .Concat(viewLocations);
            }

            if(context.Values["Device"] == "Tablet")
            {
                viewLocations = new[] {
                    $"/Views/{{1}}/{{0}}.tablet.cshtml",
                    $"/Views/Shared/{{0}}.tablet.cshtml",
                    $"/Views/Shared/Components/{{0}}.mobile.cshtml"
                }
                .Concat(viewLocations);
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var device = context.ActionContext.HttpContext.Session.GetString("Device");

            context.Values["Device"] = device;
        }
    }
}