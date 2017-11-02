using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class AccountStateDesignPatternPart2
    {

        // FYI good: never create a Balance var that doesn't come with associated currency var.
        // FYI better: Don't keep money as Decimal.  Introduce special Money 
        //class to keep amount and currency together.
        public decimal Balance { get; private set; } 

        //private Action OnUnfreeze { get; }
        private IAccountState State { get; set; }

        public AccountStateDesignPatternPart2(Action onUnfreeze)
        {
            this.State = new NotVerified(onUnfreeze);
        }

        // #1 (Interaction): Deposit was invoked on the State
        // #2 (Behavior): Result of State.Deposit is new State
        // #5 (Behavior): Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            this.State = this.State.Deposit(() => { this.Balance += amount; });
        }

        // #3 (Interaction): Withdraw was invoked on the State
        // #4 (Behavior): Result of State.Deposit is new State
        // #6 (Behavior): Deposit 10, Verify, Withdraw 1 - Balance == 9
        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() => { this.Balance -= amount; });
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerified();
        }
        public void Close()
        {
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();
        }
    }
}
