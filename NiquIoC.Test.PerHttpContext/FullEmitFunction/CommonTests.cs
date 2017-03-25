﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        [ExpectedException(typeof(HttpContextNoSetException))]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();

            var sampleClass = c.Resolve<EmptyClass>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }
    }
}