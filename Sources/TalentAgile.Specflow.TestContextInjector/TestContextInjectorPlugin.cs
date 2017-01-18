using BoDi;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace TalentAgile.Specflow.TestContextInjector
{
    public class TestContextInjectorPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {
        }


        public void Initialize(GeneratorPluginEvents generatorPluginEvents,
            GeneratorPluginParameters generatorPluginParameters)
        {
            generatorPluginEvents.CustomizeDependencies += CustomizeDependencies;
        }

        public void CustomizeDependencies(object sender, CustomizeDependenciesEventArgs eventArgs)
        {
            eventArgs.ObjectContainer.RegisterTypeAs<TestContextInjectorGeneratorProvider, IUnitTestGeneratorProvider>();
        }
    }
}