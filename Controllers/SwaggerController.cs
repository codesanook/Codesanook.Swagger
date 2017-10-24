using NSwag.SwaggerGeneration.WebApi;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeSanook.Swagger.Controllers
{
    //https://github.com/RSuter/NSwag/wiki/WebApiToSwaggerGenerator
    public class SwaggerController : Controller
    {
        // GET: Swagger
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Docs()
        {
            //CaptureTheFracture.Api.V1, Version=1.10.2.0, Culture=neutral, PublicKeyToken=null"	string
            var dll = "CaptureTheFracture.Api.V1";
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.FullName.Contains(dll));
            var typeFullName = "CaptureTheFracture.Api.V1.Controllers.UsersController";
            var type = assembly.GetType(typeFullName);

            Type[] controllers = new[] {  type };
            var settings = new WebApiToSwaggerGeneratorSettings
            {
                DefaultUrlTemplate = "api/v1/{controller}/{id}",
            };

            var generator = new WebApiToSwaggerGenerator(settings);

            var document = Task.Run(async () => await generator.GenerateForControllersAsync(controllers))
                .GetAwaiter().GetResult();

            var json = document.ToJson();
            return Content(json, "application/json", Encoding.UTF8);
        }
    }
}