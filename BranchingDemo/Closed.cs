using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Closed : IAccountState
    {
        public IAccountState Deposit() => this;

        public IAccountState Withdraw() => this;

        public IAccountState Deposit(Action addToBalance)
        {
            throw new NotImplementedException();
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            throw new NotImplementedException();
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}
