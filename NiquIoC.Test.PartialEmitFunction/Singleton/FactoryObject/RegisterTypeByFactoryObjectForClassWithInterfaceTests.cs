﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Singleton.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassWithInterfaceTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType(container => new SampleClassWithInterfaceAsParameter(emptyClass)).AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            var sampleClass = new SampleClassWithInterfaceAsParameter(emptyClass);
            c.RegisterType(container => sampleClass).AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(container => new EmptyClass()).AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType(container => emptyClass).AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}