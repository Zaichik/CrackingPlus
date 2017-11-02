using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.SpecialCaseDemo
{
    public static class Claim
    {
        internal  static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;
            if (
                //isInGoodCondition && !isBroken &&
                //article.MoneyBackGuarantee != null &&
                article.MoneyBackGuarantee.IsValidOn(now))
            {
                Console.WriteLine("Offer money back.");
            }

            if (
                //isBroken &&
                //article.ExpressTimeLimitedWarranty != null &&
                article.ExpressWarranty.IsValidOn(now))
            {
                Console.WriteLine("Offer repair.");
            }
        }

        static void TestClaim()
        {
            DateTime sellingDate = new DateTime(2016, 8, 9);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            IWarranty warranty = new TimeLimitedWarranty(sellingDate, warrantySpan);

            SoldArticle goods = new SoldArticle(moneyBack, warranty);
            ClaimWarranty(goods);

            //IWarranty noMoneyBack = new VoidWarranty();
            //goods = new SoldArticle(noMoneyBack, warranty);
            goods = new SoldArticle(VoidWarranty.Instance, warranty);
            ClaimWarranty(goods);
        }
    }
}
