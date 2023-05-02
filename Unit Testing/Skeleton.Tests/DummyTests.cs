using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Loses_Health_If_Attack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(30, 15);

            int dummyHealthBeforeAttack = 30;


            axe.Attack(dummy);
            Assert.That(dummyHealthBeforeAttack != dummy.Health);
        }

        [Test]
        public void Dead_Dummies_Throws_An_Exception_If_Attacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(15, 15);



            dummy.TakeAttack(20);
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                axe.Attack(dummy);

            });
                
        }

        [Test]
        public void Dead_Dummies_Can_Give_Experience()
        {
            Axe axe = new Axe(200, 200);
            Dummy dummy = new Dummy(10, 50);


            dummy.TakeAttack(10);
            dummy.GiveExperience();
            Assert.AreEqual(dummy.Health, 0);
        }

        [Test]
        public void Alive_Dummies_Cant_Give_Experience()
        {
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(1, 1);

            axe.Attack(dummy);
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
            
        }

    }
}