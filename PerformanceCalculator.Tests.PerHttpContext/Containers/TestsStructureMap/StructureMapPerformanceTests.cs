﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsStructureMap;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsStructureMap
{
    [TestClass]
    public class StructureMapPerformanceTests
    {
        private IPerformance GetPerformance()
        {
            return new StructureMapPerformance();
        }

        [TestMethod]
        public void DoTestA_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTestA(1, true);
        }

        [TestMethod]
        public void DoTestA_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTestA(1, false);
        }

        [TestMethod]
        public void DoTestB_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTestB(1, true);
        }

        [TestMethod]
        public void DoTestB_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTestB(1, false);
        }

        [TestMethod]
        public void DoTestC_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTestC(1, true);
        }

        [TestMethod]
        public void DoTestC_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTestC(1, false);
        }
    }
}
