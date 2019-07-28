using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TilleComm.BusinessServvice.Interfaces;
using TilleComm.Common;
using TilleComm.Helpers;
using TilleComm.Models;
using TilleCommModels;

namespace TilleComm.Controllers
{
    public class LoginController : Controller
    {
        ILoginBusinessService _loginService;
        public LoginController(ILoginBusinessService loginService)
        {
            _loginService = loginService;
        }
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            SessionHelper.ClearSession();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserLogin objLogin)
        {
            
            LoginVM obj = new LoginVM();
            obj.UserDetails = await _loginService.Login(objLogin);
            if (obj.UserDetails.ErrorCode == "0")
            {
                SessionModel objSession = new SessionModel();
                objSession.UserDetails = obj.UserDetails;
                SessionHelper.SetSession(objSession);
                TempData["SelectedProducts"] = null;
                return RedirectToAction("Index", "Home");
            }
            return View(obj.UserDetails);
        }
    }
}