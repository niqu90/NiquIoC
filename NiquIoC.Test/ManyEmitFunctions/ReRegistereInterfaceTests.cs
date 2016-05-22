﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class ReRegistereInterfaceTests
    {
        [TestMethod]
        public void InterfaceReRegisteredFromSingletonToSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromSingletonToTransient_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass, EmptyClass>().AsTransient();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromTransientToSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            IEmptyClass emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3);
            var emptyClass4 = c.Resolve<IEmptyClass>();
            var emptyClass5 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass);
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(() => new EmptyClass());
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromSingletonToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromTransientToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }
        
        [TestMethod]
        public void InterfaceReRegisteredAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<ISampleClass>();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOtherSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsTransient();

            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            c.RegisterType<ISampleClass, SampleClassOther>().AsSingleton();
            var sampleClass3 = c.Resolve<ISampleClass>();
            var sampleClass4 = c.Resolve<ISampleClass>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass3, sampleClass4);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOtherTransient_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsTransient();

            c.RegisterType<ISampleClass, SampleClass>().AsTransient();
            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            c.RegisterType<ISampleClass, SampleClassOther>().AsTransient();
            var sampleClass3 = c.Resolve<ISampleClass>();
            var sampleClass4 = c.Resolve<ISampleClass>();

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass3, sampleClass4);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
        }
    }
}