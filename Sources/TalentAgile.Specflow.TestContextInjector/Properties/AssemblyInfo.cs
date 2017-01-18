using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TalentAgile.Specflow.TestContextInjector;
using TechTalk.SpecFlow.Infrastructure;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MS Test TestContext Injector Generator")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("TalentAgile")]
[assembly: AssemblyProduct("TalentAgile")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: GeneratorPlugin(typeof(TestContextInjectorPlugin))]