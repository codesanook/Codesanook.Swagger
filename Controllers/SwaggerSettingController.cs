using CodeSanook.Swagger.Models;
using Orchard;
using Orchard.Data;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Themes;
using Orchard.UI.Admin;
using Orchard.UI.Notify;
using System.Linq;
using System.Web.Mvc;

namespace CodeSanook.Swagger.Controllers
{
    [Themed, Admin]
    public class SwaggerSettingController : Controller
    {
        private readonly IRepository<SwaggerSetting> repository;
        private readonly IOrchardServices orchardService;

        //property injection
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }

        public SwaggerSettingController(IRepository<SwaggerSetting> repository,
            IOrchardServices orchardService)
        {
            this.repository = repository;
            this.orchardService = orchardService;

            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }

        public ActionResult Index()
        {
            var settings = repository.Table.ToList();
            return View(settings);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SwaggerSetting setting)
        {
            repository.Create(setting);
            orchardService.Notifier.Add(NotifyType.Information, T("created"));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var setting = repository.Get(id);
            return View(setting);
        }

        [HttpPost]
        public ActionResult Edit(int id, SwaggerSetting newSetting)
        {
            //update new values
            var existingSetting = repository.Get(id);
            existingSetting.ApiVersion = newSetting.ApiVersion;
            existingSetting.ControllerNamespace = newSetting.ControllerNamespace;
            existingSetting.DefaultUrlTemplate = newSetting.DefaultUrlTemplate;   

            repository.Update(existingSetting);
            orchardService.Notifier.Add(NotifyType.Information, T("updated"));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var setting = repository.Get(id);
            return View(setting);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            var setting = repository.Get(id);
            repository.Delete(setting);
            orchardService.Notifier.Add(NotifyType.Information, T("delete"));
            return RedirectToAction("Index");
        }


    }
}