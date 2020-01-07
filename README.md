# CP.UI.VueWeb.Cli
### dotnet coe &amp; vue scaffolding  

### 配置及相关说明:
- 第一次运行将会在ClientApp下自动生成包文件node_modules,需要花费一定时间;
- 如果修改vue程序所在目录(当前为ClientApp),需要额外在项目文件.csproj中修改 <SpaRoot>节内容为修改后的新目录名称;
- 前后端分离:
    - 后端开发可使用vs打开下载的项目进行后端编码;
    - 前端开发可直接使用vsc打开vue程序所在目录(当前为ClientApp)进行开发调试;
- 前端插件配置: 前端开发可以使用 vue ui 进行插件配置;
- 环境模式: asp.net core 提供了 Development,Staging和Production 等三种环境模式,可通过[ASPNETCORE_ENVIRONMENT]节进行设置,如果未设置此节,则默认为Production模式;
- 热更新:
    - 前端:框架项目已默认支持vue的热更新;
    - 后端:
        ```bash
        添加 watcher.tools:
        > dotnet add package Microsoft.DotNet.Watcher.Tools --version 2.0.0
        在项目目录执行:
        > dotnet watch run --verbose 
        可以以监视模式启动程序,支持热部署并可以在输出窗口看到运行明细信息
        ```
- Https配置:
    - 在appsettings中添加顶级条目：
    ```bash
      >{
         "https_port": 443,
         "Logging": {
             "LogLevel": {
                 "Default": "Information",
                 "Microsoft": "Warning",
                 "Microsoft.Hosting.Lifetime": "Information"
             }
         },
         "AllowedHosts": "*"
       } 
    ```
    - 配置Https选项:
    ```bash
      > app.UseHttpsRedirection();
    ```
    - 配置中间件选项:
    ```bash
      > public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });
        }
    ```
    - 参考: https://docs.microsoft.com/zh-cn/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio
