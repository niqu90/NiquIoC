﻿using StructureMap;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TransientStructureMapRegistration : StructureMapRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Configure(x => { x.For<TFrom>().Use<TTo>().AlwaysUnique(); });
        }
    }
}