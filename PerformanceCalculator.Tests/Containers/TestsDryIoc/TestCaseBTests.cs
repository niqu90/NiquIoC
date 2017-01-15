﻿using System.Threading;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsDryIoc
{
    [TestClass]
    public class TestCaseBTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new SingletonTestCaseB();


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.Resolve<ITestB>();
            var obj2 = c.Resolve<ITestB>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TransientTestCaseB();


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.Resolve<ITestB>();
            var obj2 = c.Resolve<ITestB>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new PerThreadTestCaseB();

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.Register(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            var thread = new Thread(() =>
            {
                using (var s = c.OpenScope())
                {
                    obj1 = c.Resolve<ITestB>();
                    obj2 = c.Resolve<ITestB>();
                }
            });
            thread.Start();
            thread.Join();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterPerThread_DifferentThreads_Success()
        {
            ITestCase testCase = new PerThreadTestCaseB();

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.Register(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (var s = c.OpenScope())
                {
                    obj1 = c.Resolve<ITestB>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (var s = c.OpenScope())
                {
                    obj2 = c.Resolve<ITestB>();
                }
            });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, false);
        }
    }
}