using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilleComm.Common;

namespace TilleComm.Helpers
{
    public class SessionHelper
    {
        public static void SetSession(SessionModel objCommonSession)
        {
            HttpContext.Current.Session["CommonSession"] = objCommonSession;//= userresult.access_token;
        }
        public static void ClearSession()
        {
            HttpContext.Current.Session["CommonSession"] = null;
        }
        public static SessionModel GetSession()
        {
            SessionModel objCommon = new SessionModel();
            if (HttpContext.Current.Session["CommonSession"] == null)
            {
                return objCommon;
            }
            else
            {
                objCommon = (SessionModel)HttpContext.Current.Session["CommonSession"];
                return objCommon;
            }
        }
        public static int GetUserID()
        {
            SessionModel obj = GetSession();
            if (obj != null && obj.UserDetails == null)
            {
                return 0;
            }
            return obj.UserDetails.UserId;
        }
    }
}