namespace Chainblock.Models
{
    using Chainblock.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Transaction : ITransaction

    {

        private string from;
        private string to;
        private decimal amount;

        public Transaction(int id,TransactionStatus status,string from,string to,decimal amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;

        }

        public int Id {get;set;}
        public TransactionStatus Status { get; set; }
        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender cannot be null or whitespace");
                }
                this.from = value;
            }
        }
        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender cannot be null or whitespace");
                }
                this.to = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Transaction must be a positive number");
                }
                this.amount = value;
            }
        }
    }
}
