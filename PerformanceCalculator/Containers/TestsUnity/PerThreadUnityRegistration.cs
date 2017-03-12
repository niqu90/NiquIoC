﻿using Microsoft.Practices.Unity;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class PerThreadUnityRegistration : UnityRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<TFrom, TTo>(new PerThreadLifetimeManager());
        }
    }
}