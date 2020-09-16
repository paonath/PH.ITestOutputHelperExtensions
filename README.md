# PH.ITestOutputHelperExtensions [![NuGet Badge](https://buildstats.info/nuget/PH.ITestOutputHelperExtensions)](https://www.nuget.org/packages/PH.ITestOutputHelperExtensions/)

TestOutputHelper Extensions: simply extensions methods for provide a ILogger or ILogger<T> from ITestOutputHelper.


## Example

```csharp
//Output is an instance of ITestOutputHelper
ILogger logger = Output.GetOnlyStateLogger();
ILogger<OnlyStateLoggerTest> loggerTyped = Output.GetOnlyStateLogger<OnlyStateLoggerTest>();

//you can use logger as in other part of your code: simply in test method is a wrapper for ITestOutputHelper

```