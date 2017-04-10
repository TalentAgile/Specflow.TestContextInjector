#MSTest2010 generator extension.

This generator injects the TestContext object in the ScenarioContext. You can now use runsettings file to store specflow parameters and change update the parameters value at runtime

![Build Status](https://avacloudtfs.visualstudio.com/_apis/public/build/definitions/aaf70729-3a79-4d44-a947-faf568ebd8db/5/badge)
## How to 

Install the related nuget package: https://www.nuget.org/packages/TalentAgile.Specflow.TestContextInjector/

Regenerate the feature generated files

In your steps, you can now access the TestContext:

```C#
var context = ScenarioContext.Current["TestContext"] as TestContext;
```

## Credits

This code comes from all other the web from people having the same issues.  Consider it as a ready to use solution for your current projects.

