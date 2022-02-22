# WorkerService
Worker service as windows service with asp.net core and serilog.

Step
Worker service as windows service with asp.net core and serilog.



---------------------------start working create process----------------------


Step
1. Create a new asp.net core or .net 5 worker service
2. apply your business logic to worker.cs or create service
3. if you are not called another class as a service avoid this section.
     a. register your service in program.cs class
         example:  
         ```
         services.AddScoped<IMyDependency, MyDependency>(); 
         ```
     b. use this service initiate with the contractor
4. if you want LogInformation as txt file then 
5. install - Serilog
6. change program.cs file
     a.  
     ``` 
     .UseSerilog()  
     ```
     b.  
     ``` 
     Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger(); 
     ```
now modified total program.cs file

``` public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
                    services.AddHostedService<Worker>();
                });
```

7. add config in appsetting.json
 ``` "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning",
        "System.Net.Http.HttpClient": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "D:\\Pactice\\SchedulerTest\\SchedulerTest\\log.txt"
        }
      }
    ]
  } 
  ```
8. install using Microsoft.Extensions.Hosting.WindowsServices
9. change config file with 
 ``` 
 .UseWindowsService() 
 
```
14. publish this file 
15. open addminstator powershell and run this commund 
   ```
   New-Service -Name {SERVICE NAME} -BinaryPathName {EXE FILE PATH} -Description "{DESCRIPTION}" -DisplayName "{DISPLAY NAME}" -StartupType Automatic 
   
   ```
12. open windows service and find out your service and run to start.
13. Now it's working done



-----------------------Thanks you----------------------
