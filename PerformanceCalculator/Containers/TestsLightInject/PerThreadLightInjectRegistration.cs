﻿using LightInject;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadLightInjectRegistration : LightInjectRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<TFrom, TTo>(new PerScopeLifetime());
        }
    }
}