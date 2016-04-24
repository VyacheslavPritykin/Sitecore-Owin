# Sitecore Owin
Sitecore module that provides OWIN support by adding an extension point to use OWIN middlewares through the Sitecore pipeline.

## How to install?
Sitecore Owin is available as a nuget package https://www.nuget.org/packages/Sitecore.Owin:
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
## How to use?
1. Implement a class with a public method `void Process(InitializeOwinMiddlewareArgs args)`

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

2. Patch the `sitecore/pipelines/initializeOwinMiddleware` pipeline to add your processor

Copyright 2016 Vyacheslav Pritykin
