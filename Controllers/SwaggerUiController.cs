using CodeSanook.Swagger.Models;
using NSwag.SwaggerGeneration.WebApi;
using Orchard;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Orchard.Data;
using Orchard.Logging;
using Orchard.Localization;

namespace CodeSanook.Swagger.Controllers
{
    //https://github.com/RSuter/NSwag/wiki/WebApiToSwaggerGenerator
    public class SwaggerUiController : Controller
    {
        private readonly IOrchardServices orchardService;
        private readonly IRepository<SwaggerSetting> repository;

        //property injection
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }

        public SwaggerUiController(IOrchardServices orchardService, IRepository<SwaggerSetting> repository)
        {
            this.orchardService = orchardService;
            this.repository = repository;

            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }

        // GET: Swagger
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Docs(string apiVersion)
        {
            var setting = repository.Get(s => s.ApiVersion == apiVersion);
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(a => setting.ControllerNamespace.Contains(a.FullName));

            assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ApiController)));
            var typeFullName = "CaptureTheFracture.Api.V1.Controllers.UsersController";
            var type = assembly.GetType(typeFullName);

            Type[] controllers = new[] { type };
            var settings = new WebApiToSwaggerGeneratorSettings
            {
                DefaultUrlTemplate = setting.DefaultUrlTemplate
            };

            var generator = new WebApiToSwaggerGenerator(settings);
            var document = Task.Run(async () => await generator.GenerateForControllersAsync(controllers))
                .GetAwaiter().GetResult();

            var json = document.ToJson();
            return Content(json, "application/json", Encoding.UTF8);
        }
    }
}