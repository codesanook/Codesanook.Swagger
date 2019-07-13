using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Codesanook.Swagger
{
    public class Routes : IRouteProvider
    {

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            const string area = "CodeSanook.Swagger";
            return new[] {

                new RouteDescriptor {
                    Name = "SwaggerUI",
                    Priority = 100,
                    Route = new Route(
                        "swagger",
                        new RouteValueDictionary {
                            {"area", area},
                            {"controller", "SwaggerUi"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", area}
                        },
                        new MvcRouteHandler())
                },

                new RouteDescriptor {
                    Name = "SwaggerDoc",
                    Priority = 100,
                    Route = new Route(
                        "swagger/doc/{apiVersion}",
                        new RouteValueDictionary {
                            {"area", area},
                            {"controller", "SwaggerUi"},
                            {"action", "GenerateDocument"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", area}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}