using Orchard.UI.Resources;

namespace CodeSanook.FacebookConnect {
    public class ResourceRegistration: IResourceManifestProvider  {
        public void BuildManifests(ResourceManifestBuilder builder) {

            var manifest = builder.Add();
            //manifest.DefineScript("AngularJs").SetUrl("angular.min.js", "angular.js")
            //    .SetVersion(angularVersion);

            var  imagePath = "~/Modules/Modules/Orchard.Resources/Styles/images";
            manifest.DefineResource("image", "logo-small").SetBasePath(imagePath).SetUrl("logo_small.png");

        }
    }
}