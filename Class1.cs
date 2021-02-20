using System;
using NUnit.Framework;
using Hedgehog.Linq;
using Range = Hedgehog.Linq.Range;

namespace Hedgehog_test
{
    public class Class1
    {
        protected void Run(Action action) => action();

        [Test]
        public void HH_ExceptionInPropertyVoid()
        {
            var property =
                from x in Property.ForAll(Gen.Int32(Range.Constant(0, 0)))
                select Run(() =>
                {
                    _ = 1 / x != 2; // line 21
                });
            property.Check(); // line 23
        }

        [Test]
        public void HH_ExceptionInPropertyBool()
        {
            var property =
                from x in Property.ForAll(Gen.Int32(Range.Constant(0, 0)))
                select 1 / x != 2; // line 41
            property.Check();
        }

    }
}
