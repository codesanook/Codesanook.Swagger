using Orchard.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSanook.Swagger.Handlers
{
    public interface ISwaggerEventHandler:IEventHandler
    {
        void OnSettingTableCreated();
    }
}