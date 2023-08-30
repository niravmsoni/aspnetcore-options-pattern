# .NET Core - Options Pattern

There are 2 ways to read configuration:

    1. Using IConfiguration
    2. Using IOptions

1. Using IConfiguration:

	Pros:
		It's easier. Need to inject this service in required Controller/Service.
	
	Cons:
		1. Validation: IConfiguration does not perform any validation over the configuration values, which might be fatal during the application runtime.
		2. Type-Safety: The interface reads configurations as strings that have to be parsed manually. This also increases the chances of configuration-related issues.
		3. No Default values: In case the required key is empty / not found in appsettings, there is no built-in way to return a default value that can be used throughout the application.
		
2. Using IOptions(Options Pattern) - Require Microsoft.Extensions.Options

//Bind configurations in the startup

builder.Services.AddOptions<WeatherOptions>().BindConfiguration(nameof(WeatherOptions))

From the class that wants to use the value, inject IOptions<Type> and access the values using .Value property:
Pros:

	1. Validations - Easy
		1. Data-Annotations
		2. Custom Validations using .Validate() method.
		
	2. Gives type-safety
	
Enhancements to IOptions:
	There are 2 additional interfaces:
		
		IOptionsSnapshot
		IOptionsMonitor

Use-case - If we want changes in configuration values to be reflected immediately without re-starting the application. These are great candidates for that use-case.
	
If we run the application, change configuration value in back-end and then save it and request the value again. Both IOptionsSnapshot and IOptionsMonitor would give us the latest value.
	IOptions would still return us older value.
	
    IOptionsMonitor vs IOptionsSnapshot - Difference in Lifetime
	IOptionsMonitor = Singleton
	IOptionsSnapshot = Scoped
	
    When to use what?
	
	    IOptions => Configuration value does not change
	    IOptionsSnapshot => When one expects your values to change, but want them to be uniform for the entire request cycle.
	    IOptionsMonitor => When one needs real-time options data.


	
	
