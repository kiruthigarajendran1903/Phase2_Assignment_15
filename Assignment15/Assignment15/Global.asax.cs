using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assignment15
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.ClearError();

            //Log the exception if needed

            //Redirect to the appropriate error page based on the exception

            if (ex is HttpException)
            {
                HttpException httpEx = ex as HttpException;
                int statusCode = httpEx.GetHttpCode();
                if (statusCode == 404)
                {
                    Response.Redirect("~/Error404.aspx");
                }
                else
                {
                    Response.Redirect("~/Error500.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }

        }
    }
}