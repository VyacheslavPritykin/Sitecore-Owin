using IAppBuilder = Owin.IAppBuilder;

namespace Sitecore.Owin.Pipelines.InitializeOwinMiddleware
{
  using Sitecore.Pipelines;

  public class InitializeOwinMiddlewareArgs : PipelineArgs
  {
    public IAppBuilder App { get; set; }

    public InitializeOwinMiddlewareArgs(IAppBuilder app)
    {
      this.App = app;
    }
  }
}