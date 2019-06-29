using Owin;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Skynet.Base
{
    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.EnsureInitialized();
            appBuilder.UseWebApi(config);
        }
    }
}