﻿using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public abstract class DryIocRegistration : IRegistration
    {
        public abstract void Register<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        public object RegisterCallback(object container)
        {
            return container;
        }
    }
}