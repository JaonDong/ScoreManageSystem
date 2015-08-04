using System.Web;
using System.Web.Routing;

namespace ScoreManageSystem.Core.Route
{
    public class LocationRoute:System.Web.Routing.Route
    {
        #region Ctor
        public LocationRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public LocationRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public LocationRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public LocationRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        } 
        #endregion

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            //在此进行URL匹配   可以进行SEO，伪静态等 

            return base.GetRouteData(httpContext);
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var a = 0;
            return base.GetVirtualPath(requestContext, values);
        }
    }
}