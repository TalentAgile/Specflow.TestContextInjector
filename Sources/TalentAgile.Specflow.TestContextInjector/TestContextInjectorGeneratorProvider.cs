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


            var msTestContextGeneration =
                new CodeExpressionStatement(
                    new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression("testRunner.ScenarioContext"),
                        "Add",
                        new CodeExpression[]
                        {
                            new CodePrimitiveExpression("TestContext"),
                            new CodeArgumentReferenceExpression("_testContext")
                        }));


            generationContext.ScenarioInitializeMethod.Statements.Add(msTestContextGeneration);


            var msTestAssignment =
                new CodeAssignStatement(
                    new CodeVariableReferenceExpression("_testContext"),
                    new CodeVariableReferenceExpression("testContext"));
            generationContext.TestClassInitializeMethod.Statements.Add(msTestAssignment);


            var mstestContextFiled = new CodeMemberField
            {
                Attributes = MemberAttributes.Private | MemberAttributes.Static | MemberAttributes.Final,
                Name = "_testContext",
                Type = new CodeTypeReference(TESTCONTEXT_TYPE),
            };


            generationContext.TestClass.Members.Add(mstestContextFiled);


        }

       
    }
}
