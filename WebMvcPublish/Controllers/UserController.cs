using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using PublishBLL;

namespace MvcPublish.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        //[Route ("User/Index/{name}")]
        public JsonResult Index(string id)
        {
            relUser userlist = UserBll.getUser(id);
            //return new ReleaseForm(result ? "success" : "error", Json(userlist, JsonRequestBehavior.AllowGet), result ? "获得数据成功！" : "获得数据失败!");
            return Json(userlist, JsonRequestBehavior.AllowGet);
        }
        //POST: /User/UserAdd/
        public int UserAdd(relUser user)
        {
            int count = UserBll.insertUser(user);
            return count;
        }
    }
}
