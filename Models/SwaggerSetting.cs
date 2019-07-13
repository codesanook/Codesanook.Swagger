using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Codesanook.Swagger.Models
{
    public class SwaggerSetting
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string ApiVersion { get; set; }

        [Required]
        public virtual string ControllerNamespace { get; set; }

        [Required]
        public virtual string DefaultUrlTemplate { get; set; }
    }
}