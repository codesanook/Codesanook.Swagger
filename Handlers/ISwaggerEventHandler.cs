using Orchard.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codesanook.Swagger.Handlers
{
    public interface ISwaggerEventHandler:IEventHandler
    {
        void OnSettingTableCreated();
    }
}