namespace Chainblock.Tests
{
    using Chainblock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Chainblock.Models;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new ChainBlock();
        }


        [Test]
        public void ChainBlockShouldStoreTransactionsInPrivateCollection()
        {
            Type type = typeof(ChainBlock);
            FieldInfo[] privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.IsPrivate)
                .ToArray();

            bool transactionsCollectionExists = privateFields.Any(fi => fi.FieldType == typeof(ICollection<ITransaction>));
            Assert.IsTrue(transactionsCollectionExists);
        }

        [Test]
        public void ConstructorShouldInitializeCollectionAndCountProperty()
        {
            Type type = typeof(ChainBlock);
            FieldInfo collectionField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.IsPrivate && f.FieldType==typeof(ICollection<ITransaction>));


            IChainblock chainblock = new ChainBlock();
            object actualFieldValue = collectionField.GetValue(chainblock);
            int actualCount = chainblock.Count;
            int expectedCount = 0;   



            Assert.AreEqual(actualCount,expectedCount);
            Assert.IsNotNull(actualFieldValue);
        }


        [Test]
        public void AddingTransactionShouldBeWorking()
        {

        }
    }
}
