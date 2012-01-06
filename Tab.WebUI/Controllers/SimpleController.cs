using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Web.Script.Serialization;
using MI.Web.Infrastructure;

namespace MI.WebUI.Controllers
{
    public class SimpleController : Controller
    {
        //
        // GET: /Simple///

        public ActionResult Index()
        {
            return View();
           
        }

        [HttpGet]
        public ActionResult GetData()
        {
            dynamic users = new List<dynamic>();

            users.Add(new ExpandoObject());
            users[0].Title = "37signals";

            users.Add(new ExpandoObject());
            users[1].Title = "2012ondazero";

            users.Add(new ExpandoObject());
            users[2].Title = "AgileForAll";

            users.Add(new ExpandoObject());
            users[3].Title = "AkitaOnRails";

            users.Add(new ExpandoObject());
            users[4].Title = "aldonogueira";

            users.Add(new ExpandoObject());
            users[5].Title = "alexandresoli";

            users.Add(new ExpandoObject());
            users[6].Title = "AlvaroGarnero";


            
            return VidpubJSON(users);
        }

        public ActionResult VidpubJSON(dynamic content)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoObjectConverter() });
            var json = serializer.Serialize(content);
            Response.ContentType = "application/json";
            return Content(json);
        }
    }
}
