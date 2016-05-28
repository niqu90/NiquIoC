﻿using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal interface ISampleClassWithClassMethod
    {
        EmptyClass EmptyClass { get; }

        void FillEmptyClass(EmptyClass emptyClass);
    }

    internal class SampleClassWithClassDependencyMethod : ISampleClassWithClassMethod
    {
        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal class SampleClassWithoutClassDependencyMethod : ISampleClassWithClassMethod
    {
        public EmptyClass EmptyClass { get; private set; }
        
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal interface ISampleClassWithClassMethodWithReturnType
    {
        EmptyClass EmptyClass { get; }

        bool FillEmptyClass(EmptyClass emptyClass);
    }

    internal class SampleClassWithClassDependencyMethodWithReturnType : ISampleClassWithClassMethodWithReturnType
    {
        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    internal interface ISampleClassWithManyClassDependencyMethods
    {
        EmptyClass EmptyClass { get; set; }

        void FillEmptyClass(EmptyClass emptyClass);

        SampleClass SampleClass { get; set; }

        void FillSampleClass(SampleClass emptyClass);
    }

    internal class SampleClassWithManyClassDependencyMethods : ISampleClassWithManyClassDependencyMethods
    {
        public EmptyClass EmptyClass { get; set; }
        
        public SampleClass SampleClass { get; set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        [DependencyMethod]
        public void FillSampleClass(SampleClass sampleClass)
        {
            SampleClass = sampleClass;
        }
    }
    
    internal interface ISampleClassWithManyClassParametersInDependencyMethod
    {
        EmptyClass EmptyClass { get; set; }

        SampleClass SampleClass { get; set; }

        void FillClasses(EmptyClass emptyClass, SampleClass sampleClass);
    }

    internal class SampleClassWithManyClassParametersInDependencyMethod : ISampleClassWithManyClassParametersInDependencyMethod
    {
        public EmptyClass EmptyClass { get; set; }

        public SampleClass SampleClass { get; set; }

        [DependencyMethod]
        public void FillClasses(EmptyClass emptyClass, SampleClass sampleClass)
        {
            EmptyClass = emptyClass;
            SampleClass = sampleClass;
        }
    }

    internal interface ISampleClassWithNestedClassDependencyMethod
    {
        SampleClassWithClassDependencyMethod SampleClassWithClassDependencyMethod { get; set; }

        void FillSampleClassWithClassDependencyMethod(SampleClassWithClassDependencyMethod emptyClass);
    }

    internal class SampleClassWithNestedClassDependencyMethod : ISampleClassWithNestedClassDependencyMethod
    {
        public SampleClassWithClassDependencyMethod SampleClassWithClassDependencyMethod { get; set; }

        [DependencyMethod]
        public void FillSampleClassWithClassDependencyMethod(SampleClassWithClassDependencyMethod sampleClassWithClassDependencyMethod)
        {
            SampleClassWithClassDependencyMethod = sampleClassWithClassDependencyMethod;
        }
    }

    internal interface ISampleClassWithClassMethodWithInterface
    {
        IEmptyClass EmptyClass { get; }

        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithClassDependencyMethodWithInterface : ISampleClassWithClassMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal class SampleClassWithoutClassDependencyMethodWithInterface : ISampleClassWithClassMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal interface ISampleClassWithClassMethodWithInterfaceWithReturnType
    {
        IEmptyClass EmptyClass { get; }

        bool FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithClassDependencyMethodWithInterfaceWithReturnType : ISampleClassWithClassMethodWithInterfaceWithReturnType
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }
}