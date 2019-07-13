using Orchard.Data.Migration;
using Codesanook.Swagger.Models;
using Codesanook.Swagger.Handlers;

namespace Codesanook.Swagger
{
    public class Migrations : DataMigrationImpl
    {
        private readonly ISwaggerEventHandler swaggerEventHandler;

        public Migrations(ISwaggerEventHandler swaggerEventHandler)
        {
            this.swaggerEventHandler = swaggerEventHandler;
        }

        public int Create()
        {
            //Create SwaggerSetting table
            SchemaBuilder.CreateTable(typeof(SwaggerSetting).Name,
                table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<string>("ApiVersion")
                .Column<string>("ControllerNamespace")
                .Column<string>("DefaultUrlTemplate")
            );

            //Fired OnSettingTableCreated event
            swaggerEventHandler.OnSettingTableCreated();
            return 1;
        }
    }
}