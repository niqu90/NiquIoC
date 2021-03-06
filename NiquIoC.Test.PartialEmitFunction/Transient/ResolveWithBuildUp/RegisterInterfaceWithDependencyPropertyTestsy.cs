﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithoutInterfaceDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c
                .RegisterType<ISampleClassWithManyInterfaceDependencyProperties,
                    SampleClassWithManyInterfaceDependencyProperties>();

            var sampleClass =
                c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c
                .RegisterType<ISampleClassWithManyInterfaceDependencyProperties,
                    SampleClassWithManyInterfaceDependencyProperties>();

            var sampleClass1 =
                c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);
            var sampleClass2 =
                c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithNestedInterfaceDependencyProperty>();

            var sampleClass =
                c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithNestedInterfaceDependencyProperty>();

            var sampleClass1 =
                c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            var sampleClass2 =
                c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty,
                sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c
                .RegisterType<ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface,
                    SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface>();

            var sampleClass =
                c.Resolve<ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface>(ResolveKind
                    .PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();

            var sampleClass =
                c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();

            var sampleClass1 =
                c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            var sampleClass2 =
                c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty,
                sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }
    }
}