Publishing to Nuget

I followed the [microsoft doc](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-visual-studio) to create the api key and publish to nuget.

Here is the publish command with api key placeholder as oy2mXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
```
cd Dskow.Weather\bin\Release
nuget push Dskow.Weather.1.0.0.nupkg oy2mXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -Source https://api.nuget.org/v3/index.json
https://www.nuget.org/users/account/LogOn?returnUrl=%2F
```
