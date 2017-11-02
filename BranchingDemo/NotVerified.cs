using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }
        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountState Close() => new Closed();
    }
}
