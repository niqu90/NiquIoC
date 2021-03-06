﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType(container => new SampleClass(emptyClass));

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            var sampleClass = new SampleClass(emptyClass);
            c.RegisterType(container => sampleClass);

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType(container => new EmptyClass());
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType(container => emptyClass);
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}