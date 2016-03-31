using Owin;

namespace Sitecore.Owin
{
  using Sitecore.Owin.Pipelines.InitializeOwinMiddleware;
  using Sitecore.Pipelines;

  public class Startup
  {
    public virtual void Configuration(IAppBuilder app)
    {
      CorePipeline.Run("initializeOwinMiddleware", new InitializeOwinMiddlewareArgs(app));
    }
  }
}
