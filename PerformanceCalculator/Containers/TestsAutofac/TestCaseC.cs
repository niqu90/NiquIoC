﻿using Autofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public abstract class TestCaseC : ITestCaseC
    {
        public abstract object Register(object container);

        public void Resolve(object container, int testCasesNumber)
        {
            var c = (IContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestC>();
            }
        }
    }
}