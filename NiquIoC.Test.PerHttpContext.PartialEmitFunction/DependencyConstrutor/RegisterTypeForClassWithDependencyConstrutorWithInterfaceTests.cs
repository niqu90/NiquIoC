﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorWithInterfaceTests
    {
        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>(c,
                        ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>(c,
                        ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void
            RegisterClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>(c,
                        ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}