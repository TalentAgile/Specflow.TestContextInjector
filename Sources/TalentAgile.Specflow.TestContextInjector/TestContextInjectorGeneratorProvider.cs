using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace TalentAgile.Specflow.TestContextInjector
{
    public class TestContextInjectorGeneratorProvider : MsTest2010GeneratorProvider
    {

        public TestContextInjectorGeneratorProvider(CodeDomHelper codeDomHelper)
            : base(codeDomHelper)
        {
        }

        public override void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            base.FinalizeTestClass(generationContext);



            var mstestContextField = new CodeMemberField
            {
                Attributes = MemberAttributes.Private | MemberAttributes.Final,
                Name = "_testContext",
                Type = new CodeTypeReference(TESTCONTEXT_TYPE),
            };


            generationContext.TestClass.Members.Add(mstestContextField);

            var msTestContextProperty = new CodeMemberProperty()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Type = new CodeTypeReference(TESTCONTEXT_TYPE),
                Name = "TestContext",
                HasGet = true,
                HasSet = true,
            };

            msTestContextProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "_textContext")));

            msTestContextProperty.SetStatements.Add(new CodeAssignStatement(
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_textContext"),
                new CodePropertySetValueReferenceExpression()));

            generationContext.TestClass.Members.Add(msTestContextProperty);

            var msTestContextScenarioInit =
                new CodeExpressionStatement(
                    new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression("testRunner.ScenarioContext"),
                        "Add",
                        new CodeExpression[]
                        {
                            new CodePrimitiveExpression("TestContext"),
                            new CodeArgumentReferenceExpression("TestContext")
                        }));

            generationContext.ScenarioInitializeMethod.Statements.Add(msTestContextScenarioInit);
          



        }

       
    }
}
