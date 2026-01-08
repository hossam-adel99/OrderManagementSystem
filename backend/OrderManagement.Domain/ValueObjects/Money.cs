using OrderManagement.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.ValueObjects
{
    public sealed class Money
    {
        public decimal Amount { get; private set; }

        private Money() { }

        public Money(decimal amount)
        {
            if (amount < 0)
                throw new DomainException("Amount cannot be negative");

            Amount = amount;
        }
        public Money Multiply(int quantity)
        {
            if (quantity <= 0)
                throw new DomainException("Quantity must be greater than zero");

            return new Money(Amount * quantity);
        }
    }
}
