using Orchard.Localization;
using Orchard.UI.Navigation;

namespace Codesanook.Swagger
{
    public class AdminMenu : INavigationProvider
    {
        public Localizer T { get; set; }

        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Settings"),
                menu => menu.Add(T("Swagger"), "1",
                item => item.Action("Index", "SwaggerSetting", new { area = "CodeSanook.Swagger" })));
        }
    }
}