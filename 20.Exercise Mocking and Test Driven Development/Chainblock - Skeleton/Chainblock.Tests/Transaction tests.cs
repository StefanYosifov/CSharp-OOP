namespace Chainblock.Tests
{
    using Chainblock.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

using Chainblock.Models;
    using NUnit.Framework;

    public class Transaction_tests
    {
        public void ConstructorShoudlInitializeCorrectly()
        {
            int expectedId = 1;
            TransactionStatus status = new TransactionStatus();
            string expectedSender = "Pesho";
            string expectedReceiver = "Gosho";
            decimal expectedAmount = 50;

            ITransaction transaction = new Transaction(expectedId,status,expectedSender,expectedReceiver,expectedAmount);

            Assert.AreEqual(expectedId,transaction.Id);
            Assert.AreEqual(status, transaction.Status);
            Assert.AreEqual(expectedSender, transaction.From);
            Assert.AreEqual(expectedReceiver, transaction.To);
            Assert.AreEqual(expectedAmount, transaction.Amount);
        }


        [TestCase()]
        [TestCase(" ")]
        [TestCase("                     ")]
        public void CreateatingTransactionWithEmptySender(string sender)
        {
            Assert.Throws<ArgumentException>(()=>
            {
                ITransaction transaction = new Transaction(5, TransactionStatus.Aborted, sender, "Pesho", 50);
            });
        }

        [TestCase()]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("                     ")]
        public void CreateatingTransactionWithEmptyReceiver(string receiver)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(5, TransactionStatus.Aborted, "Pesho", receiver, 50);
            });
        }

        [TestCase(-100)]
        [TestCase(-0.1)]
        [TestCase(-0.0001)]
        public void CreatingTransactionWithZeroOrNegativeAmount(decimal amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(5, TransactionStatus.Aborted, "Pesho", "Gosho", amount);
            });
        }

    }
}
