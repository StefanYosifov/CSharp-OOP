using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Attack_Loses_1_Durability()
        {
            Axe axe = new Axe(10, 9);
            Dummy dummy = new Dummy(10, 5);

            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints == 8);
        }

        public void Test_Attack_With_Zero_Durability()
        {
            Axe axe = new Axe(100, 1);
            Dummy dummy = new Dummy(100, 100);
            axe.Attack(dummy);
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            });

        }
    }
}