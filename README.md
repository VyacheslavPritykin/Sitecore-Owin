# Sitecore Owin
Sitecore module that provides OWIN support by adding an extension point to use OWIN middlewares through the Sitecore pipeline.

## How to install?
### Via Nuget package
The easiest way is to install a nuget package:
```
Install-Package Sitecore.Owin
```
It will install all necessary dependencies as well as patch your _web.config_ by adding:
```xml
<appSettings>
  ...    
  <add key="owin:appStartup" value="Sitecore.Owin.Startup, Sitecore.Owin" />
</appSettings>
``` 
### Via Sitecore package

1. If you don't have configured OWIN in your Sitecore instance, then you need to add a new setting into the _web.config_ `configuration/appSettings` (otherwise, it will conflict with `SolrNet.Startup` class from the _SolrNet.dll_):

  ```xml
  <appSettings>
    ...    
    <add key="owin:appStartup" value="Sitecore.Owin.Startup, Sitecore.Owin" />
  </appSettings>
  ```
2. Follow the link [Sitecore Owin](https://marketplace.sitecore.net/en/Modules/S/Sitecore_OWIN.aspx) to download the package from the Sitecore Marketplace and install it via Sitecore Installation Wizard

## How to use?
1. Add reference to the _Sitecore.Owin.dll_ (this step could be skipped if you installed the nuget package)
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

## Finally
If you already have your own OWIN `Startup` class and wish to have a pipeline based middleware setup, then you could easily inherit the `Sitecore.Owin.Startup` class and use all its benefits.

Copyright 2016 Vyacheslav Pritykin
