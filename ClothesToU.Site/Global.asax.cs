using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ClothesToU.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //以下內容需要自己手動加入，管理cookie存取流程
        protected void Application_AuthenticateRequest()
        {
            //HttpContext會自動驗證Request.IsAuthenticated
            //因此我們只要驗證(Request.IsAuthenticated == true)的情況
            if (Request.IsAuthenticated == true)
            {
                //先取得該使用者的FormsIndentity
                FormsIdentity id = (FormsIdentity)User.Identity;

                //再取出該使用者的FormsAuthenticationTicket
                FormsAuthenticationTicket ticket = id.Ticket;

                //接者取出儲存在FormsAuthenticationTicket的使用者資料
                string roles = ticket.UserData;

                //Member資料表尚未加入Roles欄位
                IPrincipal currentUser = new GenericPrincipal(
                                            User.Identity,
                                            roles.Split(new char[] { ',' },//Ex: Admin,Editor 則會需要被分割
                                            StringSplitOptions.RemoveEmptyEntries)//刪掉空白?
                                            );
                //把資料存回HTTPContext給MVC之後存取                            
                Context.User = currentUser;
            }
        }
    }
}
