
using NFluent;
using NUnit.Framework;
using System;

namespace Kata.Bank.Domain.Tests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void Should_raise_exception_when_balance_is_negatif_on_deposit_file()
        {
            var account = Account.Empty();
            Check.ThatCode(() => account.Debit(-10)).Throws<Exception>();
        }

        [Test]
        public void Should_raise_exception_when_credit_negatif_amount()
        {
            var account = Account.Empty();
            Check.ThatCode(() => account.Credit(-10)).Throws<Exception>();
        }
    }
}
