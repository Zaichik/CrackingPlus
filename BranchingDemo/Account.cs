using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Account
    {

        // FYI good: never create a Balance var that doesn't come with associated currency var.
        // FYI better: Don't keep money as Decimal.  Introduce special Money 
        //class to keep amount and currency together.
        public decimal Balance { get; private set; } 
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }
        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;

        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if(!this.IsVerified)
                return;
            if (this.IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            //withdraw money
            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }
        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (!this.IsVerified)
                return;
            if (this.IsClosed)
                return;
            this.IsFrozen = true;
        }
    }
}
