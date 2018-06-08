# Developer Notes

This is how I created this .NET standard library.

1. First I went to the [NOAA website](https://www.ncdc.noaa.gov/cdo-web/webservices/v2#gettingStarted).
2. Next I used the petstore example on the [Open Api website](http://editor.swagger.io) as a starting point to model the NOAA REST api.
3. From the editor, I choose Generate Client->csharp-dotnet2 menu option,
4. I also saved the yaml and json files,
5. I created a github repo called Dskow.Weather with MIT license and VisualStudio ignore files,
6. I opened solution in VS2017 15.7.3

In VS 2017, I did the following:

1.  I created a new project Visual C#->.NET Standard->Class Library (.NET Standard)
2. In VS 2017, I created three folders: Api, Client, and Model
3. In VS 2017, I right click each folder and Add->Existing Item... and point to src/main/CsharpDotNet2/IO/Swagger files,
4. In VS 2017, I updated the namespace and using statements (ie. IO.Swagger.Api to Dskow.Weather.Api)
5. In VS 2017, I right click the Project and select Manage nuget Packages...
6. In VS 2017, I added the RestSharp and Newtosoft.Json packages.
7. In VS 2017, I fixed two compile errors in ApiClient.cs by commenting two lines and changing RestSharp.Contrib.HttpUtility.UrlEncode to HttpUtility.UrlEncode

Here is more info on the nuget packages.

* RestSharp by John Sheehan, RestSharp Community v106.3.0
* Newtonsoft.Json by James Newton-King v11.0.2

Here are the lines I commented out

```
   foreach(var param in fileParams)
      request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentType);
```
Here is the line that I modified.
```
   public string EscapeString(string str)
   {
      return RestSharp.Contrib.HttpUtility.UrlEncode(str);
   }
```  

Then it was ready to plublish and iterate on by adding features like:

* Add webhook on github to have travis ci auto build, test, and deploy nuget package on commit.
* Rest Exception handling.
* Help documentation
* Unit tests project
