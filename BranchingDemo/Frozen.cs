using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    // State Pattern - Object of the state class represents one state.
    // Change the object when you want to change the state.
    class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; set; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = OnUnfreeze;
            
        }
        public IAccountState Deposit()
        {
            this.OnUnfreeze();
            return new Active(OnUnfreeze);

        }

        public IAccountState Withdraw()
        {
            this.OnUnfreeze();
            return new Active(OnUnfreeze);
        }

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnfreeze();
            addToBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnfreeze();
            subtractFromBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}
