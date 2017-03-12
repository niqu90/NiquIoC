﻿using Autofac;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class PerThreadAutofacRegistration : AutofacRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TTo>().As<TFrom>().InstancePerLifetimeScope();
        }
    }
}