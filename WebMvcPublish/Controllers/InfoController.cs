using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublishBLL;
using Model;

namespace MvcPublish.Controllers
{
    // /Info/
    public class InfoController : Controller
    {
        //
        // GET: //Info/Index
        [Route("Index/{id}/{page}")]
        public JsonResult Index(int id=0,int page=0)
        {
            List<_Information> infolist = new PublishBLL.InformationBll().infoSelect(id,page);
            return Json(infolist, JsonRequestBehavior.AllowGet);
        }
        //[Route("IndexId/{id}")]
        public JsonResult IndexId(int id)
        {
            List<_Information> infolist = new PublishBLL.InformationBll().infoSelect(id);
            return Json(infolist, JsonRequestBehavior.AllowGet);
        }
        [Route("info/type")]
        public JsonResult typeselect()
        {
            List<infotype> typelist = new PublishBLL.InfotypeBll().typeselect();
            return Json(typelist, JsonRequestBehavior.AllowGet);
        }
    }
}
