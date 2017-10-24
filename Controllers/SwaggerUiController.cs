using Orchard.DisplayManagement;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptureTheFracture.User.Controllers
{
    //[Themed]
    public class SwaggerUiController : Controller
    {
        private readonly IShapeFactory shapeFactory;

        public SwaggerUiController(IShapeFactory shapeFactory)
        {
            this.shapeFactory = shapeFactory;
        }


        // GET: SwaggerUi
        public ActionResult Index()
        {
            return View();
        }
    }
}