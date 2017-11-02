using System;

namespace BranchingDemo.ImmutableObjects
{
    // *** Aliasing Bug ***
    // Refrain from modifying shared objects (cost in this case).
    // Obj received as an argument is shared with the caller.  Reserve() method can assume that cost obj is an alias.
    // True problem: Having an alias doesn't mean we have a bug!
    // Only sometimes, some Buyer (represented by Buy() here) will not work well with some Seller (represented by Reserve()).
    // Avoid the possibility of aliasing bugs by not modifying shared objs.
    class ImmutableObj
    {
        static bool IsHappyHour { get; set; }

        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            MoneyAmount newCost = cost;
            if (IsHappyHour)
            {
                factor = .5M;
            }
            Console.WriteLine("\nReserving an item that costs {0}.", cost);
            return cost.Scale(factor); // cost * factor;
        }
        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            bool enoughMoney = wallet.Amount >= cost.Amount;

            var finalCost = Reserve(cost);

            bool finalEnough = wallet.Amount >= finalCost.Amount;
            if(enoughMoney && finalEnough)
                Console.WriteLine("You will pay {0} with your {1}.", cost, wallet);
            else if(finalEnough)
                Console.WriteLine("This time, {0} will be enough to pay {1}.", wallet, finalCost);
            else
                Console.WriteLine("You cannot pay {0} with your {1}.", cost, wallet);
        }

        static void Test()
        {
            Buy(new MoneyAmount(12, "USD"),
                new MoneyAmount(10, "USD"));

            Buy(new MoneyAmount(7,  "USD"),
                new MoneyAmount(10, "USD"));

            IsHappyHour = true;
            Buy(new MoneyAmount(7,  "USD"),
                new MoneyAmount(10, "USD"));

            Console.ReadLine();
        }
    }
    //class ImmutableObjBug
    //{
    //    static bool IsHappyHour { get; set; }
    //    static void Reserve(MoneyAmount cost)
    //    {
    //        if (IsHappyHour)
    //            cost.Amount *= .5M;
    //        Console.WriteLine("\nReserving an item that costs {0}.", cost);
    //    }
    //    static void Buy(MoneyAmount wallet, MoneyAmount cost)
    //    {
    //        bool enoughMoney = wallet.Amount >= cost.Amount;

    //        Reserve(cost);

    //        if (enoughMoney)
    //            Console.WriteLine("You will pay {0} with your {1}.", cost, wallet);
    //        else
    //            Console.WriteLine("You cannot pay {0} with your {1}.", cost, wallet);
    //    }

    //    static void Test()
    //    {
    //        Buy(new MoneyAmount() { Amount = 12, CurrencySymbol = "USD" },
    //            new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

    //        Buy(new MoneyAmount() { Amount = 7, CurrencySymbol = "USD" },
    //            new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

    //        IsHappyHour = true;
    //        Buy(new MoneyAmount() { Amount = 7, CurrencySymbol = "USD" },
    //            new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

    //        Console.ReadLine();
    //    }
    //}
}
