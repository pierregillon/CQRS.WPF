using System;

namespace Try4Real.EndPoint.WCF
{
    public class Global : System.Web.HttpApplication
    {
        public static DomainGate CurrentDomainGate;

        protected void Application_Start(object sender, EventArgs e)
        {
            CurrentDomainGate = new DomainGate();
        }

        protected void Session_Start(object sender, EventArgs e) { }

        protected void Application_BeginRequest(object sender, EventArgs e) { }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) { }

        protected void Application_Error(object sender, EventArgs e) { }

        protected void Session_End(object sender, EventArgs e) { }

        protected void Application_End(object sender, EventArgs e) { }
    }
}