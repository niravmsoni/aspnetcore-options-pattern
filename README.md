# aspnetcore-options-pattern
Options Pattern implementation with .NET Core

2 ways to read configuration:
1. Using IConfiguration
2. Using IOptions

1. Using IConfiguration:
	Pros:
		It's easier. Need to inject this service in required Controller/Service.
	
	Cons:
		Validation: IConfiguration does not perform any validation over the configuration values, which might be fatal during the application runtime.
		Type-Safety: The interface reads configurations as strings that have to be parsed manually. This also increases the chances of configuration-related issues.
		No Default values: In case the required key is empty / not found in appsettings, there is no built-in way to return a default value that can be used throughout the application.
		
2. Using IOptions(Options Pattern)

//Bind configurations in the startup
builder.Services.AddOptions<WeatherOptions>().BindConfiguration(nameof(WeatherOptions))

From the class that wants to use the value, inject IOptions<Type> and access the values using .Value property.

Pros:
	Validations - Easy
		1. Data-Annotations
		2. Custom Validations using .Validate() method.
		
	Gives type-safety
	
Enhancements to IOptions:
	2 additional interfaces:
		IOptionsSnapshot
		IOptionsMonitor
		
	Use-case - If we want changes in configuration values to be reflected immediately without re-starting the application. These are great candidates for that use-case.
	
	If we run the application, change configuration value in back-end and then save it and request the value again. Both IOptionsSnapshot and IOptionsMonitor would give us the latest value.
	IOptions would still return us older value.
	
	IOptionsMonitor vs IOptionsSnapshot - Difference
	Lifetime.
	IOptionsMonitor = Singleton
	IOptionsSnapshot = Scoped
	
When to use what?
	IOptions => Configuration value does not change
	IOptionsSnapshot => When one expects your values to change, but want them to be uniform for the entire request cycle.
	IOptionsMonitor => When one needs real-time options data.


	
	