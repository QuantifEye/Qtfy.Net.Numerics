namespace Qtfy.Net.Numerics.Tests.Random.RandomNumberEngines
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random;

    public abstract class EngineTester<TEngine>
        where TEngine : IRandomNumberEngine
    {
        protected void Compare<T>(T[] expected, Func<TEngine, T> func)
        {
            var engine = this.GetEngine();
            var actual = Enumerable.Repeat(engine, expected.Length).Select(func).ToArray();
            Assert.AreEqual(expected, actual);
        }

        protected abstract TEngine GetEngine();
    }
}
