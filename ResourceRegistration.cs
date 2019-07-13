using Orchard.UI.Resources;

namespace Codesanook.FacebookConnect {
    public class ResourceRegistration: IResourceManifestProvider  {
        public void BuildManifests(ResourceManifestBuilder builder) {

            var manifest = builder.Add();
            var  imagePath = "~/Modules/Modules/Orchard.Resources/Styles/images";
            manifest.DefineResource("image", "logo-small").SetBasePath(imagePath).SetUrl("logo_small.png");

        }
    }
}