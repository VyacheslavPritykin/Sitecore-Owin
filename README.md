# Sitecore Owin
Sitecore module that provides OWIN support by adding an extension point to use OWIN middlewares through the Sitecore pipeline.

## How to install?
1. If you don't have configured OWIN in your Sitecore instance, then you need to add a new setting into the _web.config_ `configuration/appSettings` (otherwise, it will conflict with `SolrNet.Startup` class from the _SolrNet.dll_):

  ```xml
  <appSettings>
    ...    
    <add key="owin:appStartup" value="Sitecore.Owin.Startup, Sitecore.Owin" />
  <appSettings>
  ```
2. If you already have you own OWIN `Startup` class, then you should:
  1. Inherit `Sitecore.Owin.Startup` class by your implementation.
  2. Add the `override` keyword to your `Configuration` method and call it's base implementation anywhere inside:

    ```C#
    public override void Configuration(IAppBuilder app)
    {
      base.Configuration(app);
      ...
    }
    ```
3. Follow the link [Sitecore Owin _(link will be updated later)_](https://marketplace.sitecore.net/#) to download the package from the Sitecore Marketplace and install it via Sitecore Installation Wizard

## How to use?
1. Add reference to the _Sitecore.Owin.dll_
2. Implement a class with a public method `void Process(InitializeOwinMiddlewareArgs args)`

  ```C#
  public class SampleOwinMiddleware
  {
    public void Process(InitializeOwinMiddlewareArgs args)
    {
      args.App.Use((context, next) =>
      {
        context.Response.Headers.Append("Yes", "it works");
        return next();
      });
    }
  }
  ```

3. Patch the `sitecore/pipelines/initializeOwinMiddleware` pipeline to add your processor

Copyright 2016 Vyacheslav Pritykin
