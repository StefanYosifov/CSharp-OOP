namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void TestConstructor()
        {
            string expectedName = "Bogomil";
            int expectedDamage = 100;
            int expectedHP = 100;

            Warrior warrior = new Warrior("Bogomil", 100, 100);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(actualDamage, expectedDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Pesho";

            Warrior warrior = new Warrior("Pesho", 66, 66);
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);

        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void TestNameSetterValidation(string name)
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 10, 10);
            });
        }

        [Test]
        public void TestDamageGetter()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", expectedDamage, 55);
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }


        [TestCase(-1)]
        [TestCase(-2)]
        public void TestDamageValidationSetter(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 100);
            });
        }


        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(-100)]
        public void TestHPValidationSetter(int HP)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 5, HP);
            });
        }






    }
}