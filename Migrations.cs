using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using CodeSanook.Swagger.Models;

namespace CodeSanook.Swagger
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookPageRecord 
            SchemaBuilder.CreateTable(typeof(SwaggerSetting).Name,
                table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<string>("ApiVersion")
                .Column<string>("ControllerNamespace")
                .Column<string>("DefaultUrlTemplate")
            );

            ContentDefinitionManager.AlterPartDefinition(
                typeof(SwaggerSetting).Name, cfg => cfg.Attachable(false)
            );
            return 1;
        }
    }
}