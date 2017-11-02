using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
