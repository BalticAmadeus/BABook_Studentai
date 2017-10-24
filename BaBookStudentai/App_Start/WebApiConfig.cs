using System.Web.Http;

namespace BaBookStudentai
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            // Web API routes
            config.MapHttpAttributeRoutes();

        }
    }
}
