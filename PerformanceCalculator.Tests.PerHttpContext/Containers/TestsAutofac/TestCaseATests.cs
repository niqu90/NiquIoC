﻿using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsAutofac
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseA();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerHttpContextRegister(cb);
            ITestA obj1 = null;
            ITestA obj2 = null;

            
            //var thread = new Thread(() =>
            //{
            //    using (var threadLifetime = c.BeginLifetimeScope())
            //    {
            //        obj1 = threadLifetime.Resolve<ITestA>();
            //        obj2 = threadLifetime.Resolve<ITestA>();
            //    }
            //});
            //thread.Start();
            //thread.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerHttpContextRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseA();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerHttpContextRegister(cb);
            ITestA obj1 = null;
            ITestA obj2 = null;

            
            //var thread1 = new Thread(() =>
            //{
            //    using (var threadLifetime = c.BeginLifetimeScope())
            //    {
            //        obj1 = threadLifetime.Resolve<ITestA>();
            //    }
            //});
            //var thread2 = new Thread(() =>
            //{
            //    using (var threadLifetime = c.BeginLifetimeScope())
            //    {
            //        obj2 = threadLifetime.Resolve<ITestA>();
            //    }
            //});
            //thread1.Start();
            //thread1.Join();
            //thread2.Start();
            //thread2.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}