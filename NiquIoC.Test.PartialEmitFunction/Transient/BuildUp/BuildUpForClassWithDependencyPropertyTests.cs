﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.BuildUp
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void ClassWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass1 = new SampleClassWithClassDependencyProperty();
            var sampleClass2 = new SampleClassWithClassDependencyProperty();

            c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
            c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithCycleInConstructorWithClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithCycleInConstructorWithClassDependencyProperty(null);

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithClassDependencyProperty")]
        public void ResolveClassWithCycleInConstructorWithClassDependencyMethod_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithCycleInConstructorWithClassDependencyProperty>();

            var sampleClass =
                c
                    .Resolve<SampleClassWithCycleInConstructorWithClassDependencyProperty>(ResolveKind
                        .PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutClassDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            var sampleClass = new SampleClassWithManyClassDependencyProperties();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            var sampleClass1 = new SampleClassWithManyClassDependencyProperties();
            var sampleClass2 = new SampleClassWithManyClassDependencyProperties();

            c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
            c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            var sampleClass = new SampleClassWithNestedClassDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            var sampleClass1 = new SampleClassWithNestedClassDependencyProperty();
            var sampleClass2 = new SampleClassWithNestedClassDependencyProperty();

            c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
            c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty,
                sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithClassDependencyPropertyWithoutSetMethod();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}