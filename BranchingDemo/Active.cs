using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Active : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze()=>new Frozen(this.OnUnfreeze);

        public IAccountState HolderVerified() => this;

        public IAccountState Close()=> new Closed();
    }
}
