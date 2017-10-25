using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace CodeSanook.Swagger
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
            return new[] {

                new RouteDescriptor {
                    Name = "SwaggerUI",
                    Priority = 100,
                    Route = new Route(
                        "swagger",
                        new RouteValueDictionary {
                            {"area", "CodeSanook.Swagger"},
                            {"controller", "Swagger"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "CodeSanook.Swagger"}
                        },
                        new MvcRouteHandler())
                },

                new RouteDescriptor {
                    Name = "SwaggerDoc",
                    Priority = 9,
                    Route = new Route(
                        "swagger/doc/{version}",
                        new RouteValueDictionary {
                            {"area", "CodeSanook.Swagger"},
                            {"controller", "Swagger"},
                            {"action", "GenerateDocument"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "CodeSanook.Swagger"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}